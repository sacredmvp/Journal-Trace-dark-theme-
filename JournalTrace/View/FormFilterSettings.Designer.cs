namespace JournalTrace.View
{
    partial class FormFilterSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupDateFilter = new System.Windows.Forms.GroupBox();
            this.checkEnableDateFilter = new System.Windows.Forms.CheckBox();
            this.comboDatePreset = new System.Windows.Forms.ComboBox();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btApply = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupDateFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDateFilter
            // 
            this.groupDateFilter.Controls.Add(this.checkEnableDateFilter);
            this.groupDateFilter.Controls.Add(this.comboDatePreset);
            this.groupDateFilter.Controls.Add(this.labelDateFrom);
            this.groupDateFilter.Controls.Add(this.dateFrom);
            this.groupDateFilter.Controls.Add(this.labelDateTo);
            this.groupDateFilter.Controls.Add(this.dateTo);
            this.groupDateFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupDateFilter.Location = new System.Drawing.Point(12, 12);
            this.groupDateFilter.Name = "groupDateFilter";
            this.groupDateFilter.Size = new System.Drawing.Size(460, 140);
            this.groupDateFilter.TabIndex = 0;
            this.groupDateFilter.TabStop = false;
            this.groupDateFilter.Text = "Date Range Filter";
            // 
            this.checkEnableDateFilter.AutoSize = true;
            this.checkEnableDateFilter.Location = new System.Drawing.Point(15, 28);
            this.checkEnableDateFilter.Name = "checkEnableDateFilter";
            this.checkEnableDateFilter.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkEnableDateFilter.Size = new System.Drawing.Size(65, 17);
            this.checkEnableDateFilter.TabIndex = 0;
            this.checkEnableDateFilter.Text = "Enable";
            this.checkEnableDateFilter.UseVisualStyleBackColor = true;
            this.checkEnableDateFilter.CheckedChanged += new System.EventHandler(this.checkEnableDateFilter_CheckedChanged);
            // 
            // comboDatePreset
            // 
            this.comboDatePreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDatePreset.FormattingEnabled = true;
            this.comboDatePreset.Items.AddRange(new object[] {
            "All Time",
            "Today",
            "Yesterday",
            "Last 7 Days",
            "Last 30 Days",
            "This Month",
            "Last Month",
            "This Year",
            "Custom Range"});
            this.comboDatePreset.Location = new System.Drawing.Point(15, 55);
            this.comboDatePreset.Name = "comboDatePreset";
            this.comboDatePreset.Size = new System.Drawing.Size(430, 21);
            this.comboDatePreset.TabIndex = 1;
            this.comboDatePreset.SelectedIndexChanged += new System.EventHandler(this.comboDatePreset_SelectedIndexChanged);
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(15, 95);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(33, 13);
            this.labelDateFrom.TabIndex = 2;
            this.labelDateFrom.Text = "From:";
            // 
            // dateFrom
            // 
            this.dateFrom.Enabled = false;
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(70, 92);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(150, 22);
            this.dateFrom.TabIndex = 3;
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Location = new System.Drawing.Point(240, 95);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(22, 13);
            this.labelDateTo.TabIndex = 4;
            this.labelDateTo.Text = "To:";
            // 
            // dateTo
            // 
            this.dateTo.Enabled = false;
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(280, 92);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(150, 22);
            this.dateTo.TabIndex = 5;
            // 
            // btApply
            // 
            this.btApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btApply.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btApply.ForeColor = System.Drawing.Color.White;
            this.btApply.Location = new System.Drawing.Point(220, 165);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(80, 35);
            this.btApply.TabIndex = 2;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = false;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btClear.ForeColor = System.Drawing.Color.White;
            this.btClear.Location = new System.Drawing.Point(310, 165);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(80, 35);
            this.btClear.TabIndex = 3;
            this.btClear.Text = "Clear All";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.Location = new System.Drawing.Point(400, 165);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(72, 35);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FormFilterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.groupDateFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFilterSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Filters";
            this.groupDateFilter.ResumeLayout(false);
            this.groupDateFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDateFilter;
        private System.Windows.Forms.CheckBox checkEnableDateFilter;
        private System.Windows.Forms.ComboBox comboDatePreset;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btCancel;
    }
}
