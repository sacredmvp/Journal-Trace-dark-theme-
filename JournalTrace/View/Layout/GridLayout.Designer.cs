namespace JournalTrace.View.Layout
{
    partial class GridLayout
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.datagJournalEntries = new System.Windows.Forms.DataGridView();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btSearchClear = new System.Windows.Forms.Button();
            this.btFilterSettings = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.CBdeleted = new System.Windows.Forms.CheckBox();
            this.CBrenamednew = new System.Windows.Forms.CheckBox();
            this.CBstreamchange = new System.Windows.Forms.CheckBox();
            this.CBbasicinfochange = new System.Windows.Forms.CheckBox();
            this.CBrenamedold = new System.Windows.Forms.CheckBox();
            this.flowFilters = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.datagJournalEntries)).BeginInit();
            this.flowFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagJournalEntries
            // 
            this.datagJournalEntries.AllowUserToDeleteRows = false;
            this.datagJournalEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagJournalEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagJournalEntries.Location = new System.Drawing.Point(8, 128);
            this.datagJournalEntries.Name = "datagJournalEntries";
            this.datagJournalEntries.ReadOnly = true;
            this.datagJournalEntries.RowHeadersVisible = false;
            this.datagJournalEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagJournalEntries.Size = new System.Drawing.Size(815, 232);
            this.datagJournalEntries.TabIndex = 10;
            this.datagJournalEntries.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.datagJournalEntries_CellFormatting);
            this.datagJournalEntries.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagJournalEntries_CellMouseDown);
            // 
            // comboSearch
            // 
            this.comboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "USN",
            "Nome",
            "Hora",
            "Razão",
            "Diretório"});
            this.comboSearch.Location = new System.Drawing.Point(340, 12);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(145, 21);
            this.comboSearch.TabIndex = 11;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(8, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 22);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btSearch.ForeColor = System.Drawing.Color.White;
            this.btSearch.Location = new System.Drawing.Point(505, 8);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(85, 34);
            this.btSearch.TabIndex = 13;
            this.btSearch.Tag = "search";
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btSearchClear
            // 
            this.btSearchClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearchClear.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.btSearchClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btSearchClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btSearchClear.ForeColor = System.Drawing.Color.White;
            this.btSearchClear.Location = new System.Drawing.Point(596, 8);
            this.btSearchClear.Name = "btSearchClear";
            this.btSearchClear.Size = new System.Drawing.Size(85, 34);
            this.btSearchClear.TabIndex = 14;
            this.btSearchClear.Tag = "clear";
            this.btSearchClear.Text = "Clear";
            this.btSearchClear.UseVisualStyleBackColor = false;
            this.btSearchClear.Click += new System.EventHandler(this.btSearchClear_Click);
            // 
            // btFilterSettings
            // 
            this.btFilterSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFilterSettings.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btFilterSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btFilterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFilterSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btFilterSettings.ForeColor = System.Drawing.Color.White;
            this.btFilterSettings.Location = new System.Drawing.Point(505, 46);
            this.btFilterSettings.Name = "btFilterSettings";
            this.btFilterSettings.Size = new System.Drawing.Size(85, 34);
            this.btFilterSettings.TabIndex = 15;
            this.btFilterSettings.Text = "Settings";
            this.btFilterSettings.UseVisualStyleBackColor = false;
            this.btFilterSettings.Click += new System.EventHandler(this.btFilterSettings_Click);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.btExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btExport.ForeColor = System.Drawing.Color.White;
            this.btExport.Location = new System.Drawing.Point(596, 46);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(85, 34);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = false;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // CBdeleted
            // 
            this.CBdeleted.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBdeleted.AutoSize = true;
            this.CBdeleted.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.CBdeleted.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBdeleted.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBdeleted.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBdeleted.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBdeleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBdeleted.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBdeleted.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.CBdeleted.Location = new System.Drawing.Point(3, 3);
            this.CBdeleted.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.CBdeleted.MinimumSize = new System.Drawing.Size(0, 34);
            this.CBdeleted.Name = "CBdeleted";
            this.CBdeleted.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.CBdeleted.TabIndex = 15;
            this.CBdeleted.Tag = "filter_deleted";
            this.CBdeleted.Text = "Deleted";
            this.CBdeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBdeleted.UseCompatibleTextRendering = true;
            this.CBdeleted.CheckedChanged += new System.EventHandler(this.CBdeleted_CheckedChanged);
            // 
            // CBrenamednew
            // 
            this.CBrenamednew.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBrenamednew.AutoSize = true;
            this.CBrenamednew.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.CBrenamednew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBrenamednew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBrenamednew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBrenamednew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBrenamednew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBrenamednew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBrenamednew.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.CBrenamednew.Location = new System.Drawing.Point(120, 3);
            this.CBrenamednew.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.CBrenamednew.MinimumSize = new System.Drawing.Size(0, 34);
            this.CBrenamednew.Name = "CBrenamednew";
            this.CBrenamednew.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.CBrenamednew.TabIndex = 17;
            this.CBrenamednew.Tag = "filter_renamed_new";
            this.CBrenamednew.Text = "Renamed New";
            this.CBrenamednew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBrenamednew.UseCompatibleTextRendering = true;
            this.CBrenamednew.CheckedChanged += new System.EventHandler(this.CBrenamed_CheckedChanged);
            // 
            // CBrenamedold
            // 
            this.CBrenamedold.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBrenamedold.AutoSize = true;
            this.CBrenamedold.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.CBrenamedold.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBrenamedold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBrenamedold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBrenamedold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBrenamedold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBrenamedold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBrenamedold.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.CBrenamedold.Location = new System.Drawing.Point(280, 3);
            this.CBrenamedold.MinimumSize = new System.Drawing.Size(0, 34);
            this.CBrenamedold.Name = "CBrenamedold";
            this.CBrenamedold.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.CBrenamedold.TabIndex = 20;
            this.CBrenamedold.Tag = "filter_renamed_old";
            this.CBrenamedold.Text = "Renamed Old";
            this.CBrenamedold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBrenamedold.UseCompatibleTextRendering = true;
            this.CBrenamedold.CheckedChanged += new System.EventHandler(this.CBrenamedold_CheckedChanged);
            // 
            // CBbasicinfochange
            // 
            this.CBbasicinfochange.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBbasicinfochange.AutoSize = true;
            this.CBbasicinfochange.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.CBbasicinfochange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBbasicinfochange.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBbasicinfochange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBbasicinfochange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBbasicinfochange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBbasicinfochange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBbasicinfochange.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.CBbasicinfochange.Location = new System.Drawing.Point(436, 3);
            this.CBbasicinfochange.MinimumSize = new System.Drawing.Size(0, 34);
            this.CBbasicinfochange.Name = "CBbasicinfochange";
            this.CBbasicinfochange.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.CBbasicinfochange.TabIndex = 19;
            this.CBbasicinfochange.Tag = "filter_basic_info";
            this.CBbasicinfochange.Text = "Basic Info";
            this.CBbasicinfochange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBbasicinfochange.UseCompatibleTextRendering = true;
            this.CBbasicinfochange.CheckedChanged += new System.EventHandler(this.CBbasicinfochange_CheckedChanged);
            // 
            // CBstreamchange
            // 
            this.CBstreamchange.Appearance = System.Windows.Forms.Appearance.Button;
            this.CBstreamchange.AutoSize = true;
            this.CBstreamchange.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.CBstreamchange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBstreamchange.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBstreamchange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.CBstreamchange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.CBstreamchange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBstreamchange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBstreamchange.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.CBstreamchange.Location = new System.Drawing.Point(600, 3);
            this.CBstreamchange.MinimumSize = new System.Drawing.Size(0, 34);
            this.CBstreamchange.Name = "CBstreamchange";
            this.CBstreamchange.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.CBstreamchange.TabIndex = 18;
            this.CBstreamchange.Tag = "filter_stream";
            this.CBstreamchange.Text = "Stream";
            this.CBstreamchange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBstreamchange.UseCompatibleTextRendering = true;
            this.CBstreamchange.CheckedChanged += new System.EventHandler(this.CBdataextend_CheckedChanged);
            // 
            // flowFilters
            // 
            this.flowFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowFilters.BackColor = System.Drawing.Color.Transparent;
            this.flowFilters.Controls.Add(this.CBdeleted);
            this.flowFilters.Controls.Add(this.CBrenamednew);
            this.flowFilters.Controls.Add(this.CBrenamedold);
            this.flowFilters.Controls.Add(this.CBbasicinfochange);
            this.flowFilters.Controls.Add(this.CBstreamchange);
            this.flowFilters.Location = new System.Drawing.Point(8, 84);
            this.flowFilters.Name = "flowFilters";
            this.flowFilters.Size = new System.Drawing.Size(815, 40);
            this.flowFilters.TabIndex = 21;
            // 
            // GridLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowFilters);
            this.Controls.Add(this.datagJournalEntries);
            this.Controls.Add(this.comboSearch);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btFilterSettings);
            this.Controls.Add(this.btSearchClear);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Name = "GridLayout";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(750, 368);
            ((System.ComponentModel.ISupportInitialize)(this.datagJournalEntries)).EndInit();
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagJournalEntries;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btSearchClear;
        private System.Windows.Forms.Button btFilterSettings;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.CheckBox CBdeleted;
        private System.Windows.Forms.CheckBox CBrenamednew;
        private System.Windows.Forms.CheckBox CBstreamchange;
        private System.Windows.Forms.CheckBox CBbasicinfochange;
        private System.Windows.Forms.CheckBox CBrenamedold;
        private System.Windows.Forms.FlowLayoutPanel flowFilters;
    }
}
