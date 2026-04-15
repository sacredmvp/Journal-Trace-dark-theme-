using System;
using System.Windows.Forms;
using JournalTrace.Language;

namespace JournalTrace.View
{
    public partial class FormFilterSettings : Form
    {
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateTo { get; private set; }
        public bool FiltersApplied { get; private set; }

        private DateTime? initialDateFrom;
        private DateTime? initialDateTo;

        public FormFilterSettings()
        {
            InitializeComponent();
            FiltersApplied = false;
            
            // Initialize date pickers
            dateFrom.Value = DateTime.Now.AddMonths(-1);
            dateTo.Value = DateTime.Now;
            
            // Initialize combo boxes
            comboDatePreset.SelectedIndex = 0;
        }

        public FormFilterSettings(DateTime? dateFrom, DateTime? dateTo) : this()
        {
            initialDateFrom = dateFrom;
            initialDateTo = dateTo;

            // Restore previous settings
            if (dateFrom.HasValue && dateTo.HasValue)
            {
                checkEnableDateFilter.Checked = true;
                this.dateFrom.Value = dateFrom.Value;
                this.dateTo.Value = dateTo.Value;
                comboDatePreset.SelectedIndex = 8; // Custom Range
            }
        }

        private void comboDatePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            bool enableCustom = false;

            switch (comboDatePreset.SelectedIndex)
            {
                case 0: // All Time
                    checkEnableDateFilter.Checked = false;
                    break;
                case 1: // Today
                    dateFrom.Value = now.Date;
                    dateTo.Value = now;
                    checkEnableDateFilter.Checked = true;
                    break;
                case 2: // Yesterday
                    dateFrom.Value = now.AddDays(-1).Date;
                    dateTo.Value = now.AddDays(-1).Date.AddHours(23).AddMinutes(59);
                    checkEnableDateFilter.Checked = true;
                    break;
                case 3: // Last 7 Days
                    dateFrom.Value = now.AddDays(-7);
                    dateTo.Value = now;
                    checkEnableDateFilter.Checked = true;
                    break;
                case 4: // Last 30 Days
                    dateFrom.Value = now.AddDays(-30);
                    dateTo.Value = now;
                    checkEnableDateFilter.Checked = true;
                    break;
                case 5: // This Month
                    dateFrom.Value = new DateTime(now.Year, now.Month, 1);
                    dateTo.Value = now;
                    checkEnableDateFilter.Checked = true;
                    break;
                case 6: // Last Month
                    DateTime lastMonth = now.AddMonths(-1);
                    dateFrom.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    dateTo.Value = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
                    checkEnableDateFilter.Checked = true;
                    break;
                case 7: // This Year
                    dateFrom.Value = new DateTime(now.Year, 1, 1);
                    dateTo.Value = now;
                    checkEnableDateFilter.Checked = true;
                    break;
                case 8: // Custom Range
                    enableCustom = true;
                    checkEnableDateFilter.Checked = true;
                    break;
            }

            dateFrom.Enabled = enableCustom && checkEnableDateFilter.Checked;
            dateTo.Enabled = enableCustom && checkEnableDateFilter.Checked;
        }

        private void checkEnableDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            bool isCustom = comboDatePreset.SelectedIndex == 8;
            dateFrom.Enabled = checkEnableDateFilter.Checked && isCustom;
            dateTo.Enabled = checkEnableDateFilter.Checked && isCustom;
        }

        private long ConvertToBytes(string value, int unitIndex)
        {
            if (string.IsNullOrWhiteSpace(value))
                return -1;

            if (!long.TryParse(value, out long number))
                return -1;

            switch (unitIndex)
            {
                case 0: return number; // Bytes
                case 1: return number * 1024; // KB
                case 2: return number * 1024 * 1024; // MB
                case 3: return number * 1024 * 1024 * 1024; // GB
                default: return number;
            }
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            // Date filter
            if (checkEnableDateFilter.Checked)
            {
                DateFrom = dateFrom.Value.Date;
                DateTo = dateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            else
            {
                DateFrom = null;
                DateTo = null;
            }

            FiltersApplied = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            checkEnableDateFilter.Checked = false;
            comboDatePreset.SelectedIndex = 0;
            
            DateFrom = null;
            DateTo = null;
            
            FiltersApplied = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            FiltersApplied = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
