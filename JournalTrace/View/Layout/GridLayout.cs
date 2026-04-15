using JournalTrace.Language;
using JournalTrace.Entry;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using JournalTrace.View.Util;
using System.Collections.Generic;
using System.Linq;

namespace JournalTrace.View.Layout
{
    public partial class GridLayout : UserControl, ILayout
    {
        private EntryManager entryManager;
        private DateTime? filterDateFrom;
        private DateTime? filterDateTo;

        public GridLayout(EntryManager mngr)
        {
            this.entryManager = mngr;

            InitializeComponent();

            comboSearch.SelectedIndex = 1;
            //campos de tradução
            datagJournalEntries.Tag = new string[] { null, "name", "date", "reason", "directory" };
            comboSearch.Tag = new string[] { null, "name", "date", "reason", "directory" };
        }
        public void Clean()
        {
            datagJournalEntries.DataSource = null;
            dataSourceEntries.Clear();
            dataSourceEntries.Dispose();
            datagJournalEntries.Rows.Clear();
            datagJournalEntries.Dispose();
            GC.Collect();
        }

        public Control GetControl()
        {
            return this;
        }

        public DataTable dataSourceEntries;

        public async void LoadData(FormMain frm)
        {
            dataSourceEntries = new DataTable();

            dataSourceEntries.Columns.Add("USN", typeof(long));
            dataSourceEntries.Columns.Add("name", typeof(string));
            dataSourceEntries.Columns.Add("date", typeof(string));
            dataSourceEntries.Columns.Add("reason", typeof(string));
            dataSourceEntries.Columns.Add("directory", typeof(string));

            await Task.Run(() =>
            {
                foreach (var item in entryManager.USNEntries)
                {
                    USNEntry entry = item.Value;
                    dataSourceEntries.Rows.Add(
                        entry.USN, 
                        entry.Name, 
                        entry.Time, 
                        entry.Reason, 
                        entryManager.parentFileReferenceIdentifiers[entry.ParentFileReference].ResolvedID);
                }
            });

            datagJournalEntries.DataSource = dataSourceEntries;

            LanguageManager.INSTANCE.UpdateControl(datagJournalEntries);

            //tamanho das colunas
            int[] widthColumns = new int[] { 88, 200, 115, 300, 500 };

            for (int i = 0; i < widthColumns.Length; i++)
            {
                datagJournalEntries.Columns[i].Width = widthColumns[i];
            }

            frm.ShowLayoutOption(true);
        }
        private void performSearch()
        {
            string filterText = txtSearch.Text.Trim();
            string reasonColumn = "reason";
            string combinedFilter = "";

            if (!string.IsNullOrWhiteSpace(filterText))
            {
                if (filterText.Contains(":") && !IsValidPath(filterText))
                {
                    string[] filterConditions = filterText.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string condition in filterConditions)
                    {
                        string[] parts = condition.Split(new[] { ':' }, 2);
                        if (parts.Length != 2) continue;

                        string columnName = parts[0].Trim();
                        string filterValue = parts[1].Trim();

                        if (!dataSourceEntries.Columns.Contains(columnName) && !IsValidPath(filterValue))
                            continue;

                        string columnFilter = BuildColumnFilter(columnName, filterValue);
                        if (!string.IsNullOrEmpty(columnFilter))
                            combinedFilter = AppendFilter(combinedFilter, columnFilter);
                    }
                }
                else
                {
                    string columnName;
                    string searchValue;

                    if (IsValidPath(filterText))
                    {
                        columnName = "directory";
                        searchValue = filterText;
                    }
                    else if (comboSearch.SelectedIndex > 0)
                    {
                        columnName = dataSourceEntries.Columns[comboSearch.SelectedIndex].ColumnName;
                        searchValue = filterText;
                    }
                    else
                    {
                        dataSourceEntries.DefaultView.RowFilter = "";
                        ApplyColorCoding();
                        return;
                    }

                    string columnFilter = BuildColumnFilter(columnName, searchValue);
                    if (!string.IsNullOrEmpty(columnFilter))
                        combinedFilter = AppendFilter(combinedFilter, columnFilter);
                }
            }

            combinedFilter = AppendCheckBoxFilters(combinedFilter, reasonColumn);
            combinedFilter = AppendAdvancedFilters(combinedFilter);
            dataSourceEntries.DefaultView.RowFilter = combinedFilter;
        }

        private bool IsValidPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            return path.Contains(":\\") ||
                   path.StartsWith("\\\\") ||
                   path.StartsWith("/") ||
                   path.StartsWith("./") ||
                   path.StartsWith("../");
        }

        private string BuildColumnFilter(string columnName, string filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterValue))
                return string.Empty;

            string columnFilter = "";

            if (filterValue.Contains("!!"))
            {
                string[] parts = filterValue.Split(new[] { "!!" }, StringSplitOptions.None);
                if (!string.IsNullOrWhiteSpace(parts[0]))
                    columnFilter = $"{columnName} LIKE '%{parts[0].Trim()}%'";

                for (int i = 1; i < parts.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parts[i]))
                        columnFilter = AppendFilter(columnFilter, $"{columnName} NOT LIKE '%{parts[i].Trim()}%'", "AND");
                }
            }
            else if (filterValue.Contains("&&"))
            {
                var parts = filterValue.Split(new[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                columnFilter = string.Join(" AND ", parts.Select(p => $"{columnName} LIKE '%{p.Trim()}%'"));
            }
            else if (filterValue.Contains("||"))
            {
                var parts = filterValue.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                columnFilter = string.Join(" OR ", parts.Select(p => $"{columnName} LIKE '%{p.Trim()}%'"));
            }
            else
            {
                columnFilter = $"{columnName} LIKE '%{filterValue}%'";
            }

            return !string.IsNullOrEmpty(columnFilter) ? $"({columnFilter})" : string.Empty;
        }

        private string AppendFilter(string existingFilter, string newFilter, string conjunction = "AND")
        {
            if (string.IsNullOrEmpty(existingFilter))
                return newFilter;
            if (string.IsNullOrEmpty(newFilter))
                return existingFilter;
            return $"{existingFilter} {conjunction} {newFilter}";
        }

        private string AppendCheckBoxFilters(string currentFilter, string reasonColumn)
        {
            var checkBoxFilters = new Dictionary<CheckBox, string>
    {
        { CBdeleted, "File delete" },
        { CBrenamednew, "Rename: new name" },
        { CBrenamedold, "Rename: old name" },
        { CBstreamchange, "Stream change" },
        { CBbasicinfochange, "Basic info change" }
    };

            foreach (var checkBox in checkBoxFilters)
            {
                if (checkBox.Key.Checked)
                {
                    string newFilter = $"({reasonColumn} LIKE '%{checkBox.Value}%')";
                    currentFilter = AppendFilter(currentFilter, newFilter);
                }
            }

            return currentFilter;
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            performSearch();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(this, null);
            }
        }

        private void btSearchClear_Click(object sender, EventArgs e)
        {
            dataSourceEntries.DefaultView.RowFilter = "";
            txtSearch.Text = "";
            
            // Clear advanced filters
            filterDateFrom = null;
            filterDateTo = null;
            
            // Uncheck all filter checkboxes
            CBdeleted.Checked = false;
            CBrenamednew.Checked = false;
            CBrenamedold.Checked = false;
            CBstreamchange.Checked = false;
            CBbasicinfochange.Checked = false;
        }

        private void datagJournalEntries_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ContextMenuHelper.INSTANCE.ShowContext(datagJournalEntries, e);
        }

        private void CBdataextend_CheckedChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void CBrenamed_CheckedChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void CBdeleted_CheckedChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void CBrenamedold_CheckedChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void CBbasicinfochange_CheckedChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void datagJournalEntries_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= datagJournalEntries.Rows.Count)
                return;

            DataGridViewRow row = datagJournalEntries.Rows[e.RowIndex];
            
            if (row.Cells["reason"].Value != null)
            {
                string reason = row.Cells["reason"].Value.ToString().ToLower();
                Color foreColor;

                if (reason.Contains("file delete") || reason.Contains("delete"))
                {
                    foreColor = Color.FromArgb(255, 100, 100); // Red
                }
                else if (reason.Contains("file create") || reason.Contains("create"))
                {
                    foreColor = Color.FromArgb(100, 255, 100); // Green
                }
                else if (reason.Contains("rename"))
                {
                    foreColor = Color.FromArgb(255, 220, 100); // Yellow
                }
                else if (reason.Contains("data overwrite") || reason.Contains("data extend") || 
                         reason.Contains("data truncation") || reason.Contains("stream change"))
                {
                    foreColor = Color.FromArgb(100, 180, 255); // Light blue
                }
                else
                {
                    foreColor = Color.FromArgb(245, 245, 245); // White
                }

                e.CellStyle.ForeColor = foreColor;
            }
        }

        private void ApplyColorCoding()
        {
            // Deprecated - now using CellFormatting event for better performance
            // This method is kept for compatibility but does nothing
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (dataSourceEntries == null || dataSourceEntries.DefaultView.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV File (*.csv)|*.csv|JSON File (*.json)|*.json|Text File (*.txt)|*.txt";
                saveDialog.Title = "Export Journal Entries";
                saveDialog.FileName = $"JournalTrace_Export_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string extension = System.IO.Path.GetExtension(saveDialog.FileName).ToLower();
                        
                        switch (extension)
                        {
                            case ".csv":
                                ExportToCSV(saveDialog.FileName);
                                break;
                            case ".json":
                                ExportToJSON(saveDialog.FileName);
                                break;
                            case ".txt":
                                ExportToTXT(saveDialog.FileName);
                                break;
                        }

                        MessageBox.Show($"Successfully exported {dataSourceEntries.DefaultView.Count} entries to:\n{saveDialog.FileName}", 
                            "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Export failed:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                // Write header
                writer.WriteLine("USN,Name,Date,Reason,Directory");

                // Write data
                foreach (DataRowView rowView in dataSourceEntries.DefaultView)
                {
                    DataRow row = rowView.Row;
                    writer.WriteLine($"\"{row["USN"]}\",\"{EscapeCSV(row["name"].ToString())}\",\"{row["date"]}\",\"{EscapeCSV(row["reason"].ToString())}\",\"{EscapeCSV(row["directory"].ToString())}\"");
                }
            }
        }

        private void ExportToJSON(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("[");
                
                bool first = true;
                foreach (DataRowView rowView in dataSourceEntries.DefaultView)
                {
                    DataRow row = rowView.Row;
                    
                    if (!first) writer.WriteLine(",");
                    first = false;

                    writer.WriteLine("  {");
                    writer.WriteLine($"    \"usn\": {row["USN"]},");
                    writer.WriteLine($"    \"name\": \"{EscapeJSON(row["name"].ToString())}\",");
                    writer.WriteLine($"    \"date\": \"{row["date"]}\",");
                    writer.WriteLine($"    \"reason\": \"{EscapeJSON(row["reason"].ToString())}\",");
                    writer.WriteLine($"    \"directory\": \"{EscapeJSON(row["directory"].ToString())}\"");
                    writer.Write("  }");
                }
                
                writer.WriteLine();
                writer.WriteLine("]");
            }
        }

        private void ExportToTXT(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("=".PadRight(120, '='));
                writer.WriteLine($"JournalTrace Export - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine($"Total Entries: {dataSourceEntries.DefaultView.Count}");
                writer.WriteLine("=".PadRight(120, '='));
                writer.WriteLine();

                foreach (DataRowView rowView in dataSourceEntries.DefaultView)
                {
                    DataRow row = rowView.Row;
                    writer.WriteLine($"USN:       {row["USN"]}");
                    writer.WriteLine($"Name:      {row["name"]}");
                    writer.WriteLine($"Date:      {row["date"]}");
                    writer.WriteLine($"Reason:    {row["reason"]}");
                    writer.WriteLine($"Directory: {row["directory"]}");
                    writer.WriteLine("-".PadRight(120, '-'));
                }
            }
        }

        private string EscapeCSV(string value)
        {
            if (value == null) return "";
            return value.Replace("\"", "\"\"");
        }

        private string EscapeJSON(string value)
        {
            if (value == null) return "";
            return value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private void btFilterSettings_Click(object sender, EventArgs e)
        {
            using (FormFilterSettings filterForm = new FormFilterSettings(filterDateFrom, filterDateTo))
            {
                if (filterForm.ShowDialog() == DialogResult.OK && filterForm.FiltersApplied)
                {
                    filterDateFrom = filterForm.DateFrom;
                    filterDateTo = filterForm.DateTo;
                    
                    performSearch();
                }
            }
        }

        private string AppendAdvancedFilters(string currentFilter)
        {
            // Date filter
            if (filterDateFrom.HasValue && filterDateTo.HasValue)
            {
                string dateFilter = BuildDateRangeFilter(filterDateFrom.Value, filterDateTo.Value);
                if (!string.IsNullOrEmpty(dateFilter))
                    currentFilter = AppendFilter(currentFilter, dateFilter);
            }

            return currentFilter;
        }

        private string BuildDateRangeFilter(DateTime from, DateTime to)
        {
            try
            {
                // Use LIKE for date range filtering
                // Format: "dd/MM/yyyy HH:mm:ss" with InvariantCulture
                List<string> dateFilters = new List<string>();
                
                // Generate all dates in range
                for (DateTime date = from.Date; date <= to.Date; date = date.AddDays(1))
                {
                    string dateStr = date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    dateFilters.Add($"date LIKE '{dateStr}%'");
                }

                if (dateFilters.Count > 0)
                {
                    return $"({string.Join(" OR ", dateFilters)})";
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
