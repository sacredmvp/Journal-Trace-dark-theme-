using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace JournalTrace.View
{
    public static class ModernTheme
    {
        public static readonly Color Background = Color.FromArgb(18, 18, 18);
        public static readonly Color Surface = Color.FromArgb(28, 28, 28);
        public static readonly Color SurfaceLight = Color.FromArgb(38, 38, 38);
        public static readonly Color SurfaceHover = Color.FromArgb(48, 48, 48);
        public static readonly Color Primary = Color.FromArgb(88, 101, 242);
        public static readonly Color PrimaryDark = Color.FromArgb(71, 82, 196);
        public static readonly Color PrimaryLight = Color.FromArgb(105, 118, 255);
        public static readonly Color TextPrimary = Color.FromArgb(240, 240, 240);
        public static readonly Color TextSecondary = Color.FromArgb(160, 160, 160);
        public static readonly Color Border = Color.FromArgb(50, 50, 50);
        public static readonly Color Accent = Color.FromArgb(114, 137, 218);
        public static readonly Color Success = Color.FromArgb(67, 181, 129);
        public static readonly Color Warning = Color.FromArgb(250, 166, 26);
        public static readonly Color Error = Color.FromArgb(237, 66, 69);
        public static readonly Color ScrollBar = Color.FromArgb(45, 45, 45);
        public static readonly Color ScrollBarThumb = Color.FromArgb(70, 70, 70);
        public static readonly Color ScrollBarThumbHover = Color.FromArgb(90, 90, 90);

        private static readonly string[] PreferredFonts = { "SF Pro Display", "Inter", "Roboto", "Segoe UI" };
        private static string _selectedFont = null;

        public static string GetFont()
        {
            if (_selectedFont != null) return _selectedFont;

            foreach (var fontName in PreferredFonts)
            {
                using (var testFont = new Font(fontName, 8.5f))
                {
                    if (testFont.Name == fontName)
                    {
                        _selectedFont = fontName;
                        return fontName;
                    }
                }
            }
            _selectedFont = "Segoe UI";
            return _selectedFont;
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll")]
        private static extern int SetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi, bool fRedraw);

        [StructLayout(LayoutKind.Sequential)]
        private struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_BORDER_COLOR = 34;
        private const int DWMWA_SYSTEMBACKDROP_TYPE = 38;

        public static void ApplyToForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = TextPrimary;
            form.Font = new Font(GetFont(), 9F);
            form.AutoScaleMode = AutoScaleMode.Dpi;

            try
            {
                if (Environment.OSVersion.Version.Major >= 10)
                {
                    int darkMode = 1;
                    DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));

                    int captionColor = ColorToInt(Surface);
                    DwmSetWindowAttribute(form.Handle, DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));

                    int borderColor = ColorToInt(Border);
                    DwmSetWindowAttribute(form.Handle, DWMWA_BORDER_COLOR, ref borderColor, sizeof(int));
                    
                    // Enable dark mode for system dialogs and controls
                    SetWindowTheme(form.Handle, "DarkMode_Explorer", null);
                }
            }
            catch { }

            foreach (Control control in form.Controls)
            {
                ApplyToControl(control);
            }
            
            // Apply dark mode to all child forms and dialogs
            form.Shown += (s, e) =>
            {
                try
                {
                    if (Environment.OSVersion.Version.Major >= 10)
                    {
                        int darkMode = 1;
                        DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));
                    }
                }
                catch { }
            };
        }

        private static int ColorToInt(Color color)
        {
            return color.R | (color.G << 8) | (color.B << 16);
        }

        public static void ApplyToControl(Control control)
        {
            if (control is MenuStrip menu)
            {
                menu.BackColor = Surface;
                menu.ForeColor = TextPrimary;
                menu.Renderer = new ModernMenuRenderer();
                menu.Font = new Font(GetFont(), 8.5F);
                
                foreach (ToolStripMenuItem item in menu.Items)
                {
                    ApplyToMenuItem(item);
                }
            }
            else if (control is Label label)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = label.Font.Bold ? TextPrimary : TextSecondary;
                if (!label.Font.Bold)
                {
                    label.Font = new Font(GetFont(), label.Font.Size, label.Font.Style);
                }
                else
                {
                    label.Font = new Font(GetFont(), label.Font.Size, FontStyle.Bold);
                }
            }
            else if (control is FlowLayoutPanel || control is Panel)
            {
                control.BackColor = Color.Transparent;
                foreach (Control child in control.Controls)
                {
                    ApplyToControl(child);
                }
            }
            else if (control is TreeView tree)
            {
                tree.BackColor = Surface;
                tree.ForeColor = TextPrimary;
                tree.BorderStyle = BorderStyle.None;
                tree.LineColor = Border;
                tree.Font = new Font(GetFont(), 9F);
                tree.ItemHeight = 24;
                
                try
                {
                    SetWindowTheme(tree.Handle, "DarkMode_Explorer", null);
                }
                catch { }
            }
            else if (control is DataGridView grid)
            {
                grid.BackgroundColor = Background;
                grid.GridColor = Color.FromArgb(45, 45, 45);
                grid.BorderStyle = BorderStyle.None;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grid.RowHeadersVisible = false;
                grid.ColumnHeadersHeight = 36;
                grid.RowTemplate.Height = 28;
                grid.AllowUserToResizeRows = false;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.ScrollBars = ScrollBars.Both;
                
                grid.ColumnHeadersDefaultCellStyle.BackColor = SurfaceLight;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
                grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = SurfaceLight;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font(GetFont(), 9F, FontStyle.Bold);
                grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                
                grid.DefaultCellStyle.BackColor = Surface;
                grid.DefaultCellStyle.ForeColor = TextPrimary;
                grid.DefaultCellStyle.SelectionBackColor = Primary;
                grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
                grid.DefaultCellStyle.Font = new Font(GetFont(), 9F);
                grid.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
                grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
                grid.EnableHeadersVisualStyles = false;
                
                try
                {
                    SetWindowTheme(grid.Handle, "DarkMode_Explorer", null);
                }
                catch { }
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = Surface;
                textBox.ForeColor = TextPrimary;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = new Font(GetFont(), 9F);
                
                try
                {
                    SetWindowTheme(textBox.Handle, "DarkMode_CFD", null);
                }
                catch { }
            }
            else if (control is Button button)
            {
                button.BackColor = Primary;
                button.ForeColor = TextPrimary;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseOverBackColor = PrimaryLight;
                button.FlatAppearance.MouseDownBackColor = PrimaryDark;
                button.Font = new Font(GetFont(), 9F, FontStyle.Regular);
                button.Cursor = Cursors.Hand;
                button.Padding = new Padding(16, 8, 16, 8);
                button.MinimumSize = new Size(80, 32);
                button.AutoSize = true;
                button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                
                button.Region = CreateRoundedRegion(button.Width, button.Height, 4);
                button.Resize += (s, e) =>
                {
                    var btn = s as Button;
                    if (btn != null && btn.Width > 0 && btn.Height > 0)
                    {
                        btn.Region = CreateRoundedRegion(btn.Width, btn.Height, 4);
                    }
                };
            }
            else if (control is ListBox listBox)
            {
                listBox.BackColor = Surface;
                listBox.ForeColor = TextPrimary;
                listBox.BorderStyle = BorderStyle.None;
                listBox.Font = new Font(GetFont(), 10F);
                listBox.ItemHeight = 32;
                listBox.DrawMode = DrawMode.OwnerDrawFixed;
                
                // Add custom draw handler
                listBox.DrawItem -= ListBox_DrawItem; // Remove if exists
                listBox.DrawItem += ListBox_DrawItem;
                
                try
                {
                    SetWindowTheme(listBox.Handle, "DarkMode_Explorer", null);
                }
                catch { }
            }
            else if (control is CheckBox checkBox)
            {
                checkBox.BackColor = Color.Transparent;
                checkBox.ForeColor = TextPrimary;
                checkBox.FlatStyle = FlatStyle.Flat;
                checkBox.FlatAppearance.BorderColor = Border;
                checkBox.FlatAppearance.BorderSize = 1;
                checkBox.FlatAppearance.CheckedBackColor = Primary;
                checkBox.Font = new Font(GetFont(), 8.5F);
                checkBox.AutoSize = true;
                checkBox.Padding = new Padding(4, 3, 4, 3);
                checkBox.MinimumSize = new Size(0, 24);
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = Surface;
                comboBox.ForeColor = TextPrimary;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = new Font(GetFont(), 9F);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                
                try
                {
                    SetWindowTheme(comboBox.Handle, "DarkMode_CFD", null);
                }
                catch { }
            }
            else if (control is ContextMenuStrip cms)
            {
                cms.BackColor = Surface;
                cms.ForeColor = TextPrimary;
                cms.Renderer = new ModernMenuRenderer();
            }
            else if (control is UserControl userControl)
            {
                userControl.BackColor = Color.Transparent;
                foreach (Control child in userControl.Controls)
                {
                    ApplyToControl(child);
                }
            }
        }

        private static void ApplyToMenuItem(ToolStripMenuItem item)
        {
            item.BackColor = Surface;
            item.ForeColor = TextPrimary;
            
            if (item.HasDropDownItems)
            {
                item.DropDown.BackColor = Surface;
                foreach (ToolStripItem subItem in item.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem menuItem)
                    {
                        ApplyToMenuItem(menuItem);
                    }
                }
            }
        }

        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            
            if (radius <= 0 || rect.Width < 2 || rect.Height < 2)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            radius = diameter / 2;
            
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            
            return path;
        }

        public static Region CreateRoundedRegion(int width, int height, int radius)
        {
            if (width <= 0 || height <= 0) return new Region();
            return new Region(CreateRoundedRectanglePath(new Rectangle(0, 0, width, height), radius));
        }

        private static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            
            var listBox = sender as ListBox;
            if (listBox == null) return;
            
            e.DrawBackground();
            
            var isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            
            using (var brush = new SolidBrush(isSelected ? Primary : Surface))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            
            using (var textBrush = new SolidBrush(TextPrimary))
            {
                var text = listBox.Items[e.Index]?.ToString() ?? "";
                var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                e.Graphics.DrawString(text, e.Font, textBrush, e.Bounds, sf);
            }
            
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }
    }

    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernColorTable()) 
        {
            RoundedEdges = false;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(Point.Empty, e.Item.Size);
            
            if (e.Item.Selected)
            {
                using (var brush = new SolidBrush(ModernTheme.SurfaceHover))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (var brush = new SolidBrush(ModernTheme.Surface))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ModernTheme.TextPrimary;
            e.TextFont = new Font(ModernTheme.GetFont(), 8.5F);
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = ModernTheme.TextPrimary;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(e.ImageRectangle.Left + 4, e.ImageRectangle.Top + 4, 
                                     e.ImageRectangle.Width - 8, e.ImageRectangle.Height - 8);
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(ModernTheme.Primary, 2.5f))
            {
                g.DrawLine(pen, rect.Left, rect.Top + rect.Height / 2, 
                          rect.Left + rect.Width / 3, rect.Bottom - 3);
                g.DrawLine(pen, rect.Left + rect.Width / 3, rect.Bottom - 3, 
                          rect.Right, rect.Top);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var rect = new Rectangle(30, 3, e.Item.Width - 30, 1);
            using (var brush = new SolidBrush(ModernTheme.Border))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }

    public class ModernColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => ModernTheme.SurfaceHover;
        public override Color MenuItemSelectedGradientBegin => ModernTheme.SurfaceHover;
        public override Color MenuItemSelectedGradientEnd => ModernTheme.SurfaceHover;
        public override Color MenuItemPressedGradientBegin => ModernTheme.SurfaceLight;
        public override Color MenuItemPressedGradientEnd => ModernTheme.SurfaceLight;
        public override Color MenuItemBorder => ModernTheme.Border;
        public override Color MenuBorder => ModernTheme.Border;
        public override Color ImageMarginGradientBegin => ModernTheme.Surface;
        public override Color ImageMarginGradientMiddle => ModernTheme.Surface;
        public override Color ImageMarginGradientEnd => ModernTheme.Surface;
        public override Color ToolStripDropDownBackground => ModernTheme.Surface;
        public override Color SeparatorDark => ModernTheme.Border;
        public override Color SeparatorLight => ModernTheme.Border;
    }

    public class ModernProgressBar : ProgressBar
    {
        public ModernProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | 
                    ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var bgPath = ModernTheme.CreateRoundedRectanglePath(ClientRectangle, 5))
            {
                using (var brush = new SolidBrush(ModernTheme.Surface))
                {
                    g.FillPath(brush, bgPath);
                }
            }

            if (Maximum > 0 && Value > 0)
            {
                var percent = (float)Value / Maximum;
                var width = (int)(ClientRectangle.Width * percent);
                
                if (width > 10)
                {
                    var progressRect = new Rectangle(0, 0, width, ClientRectangle.Height);
                    
                    using (var progressPath = ModernTheme.CreateRoundedRectanglePath(progressRect, 5))
                    {
                        using (var brush = new LinearGradientBrush(
                            ClientRectangle, 
                            ModernTheme.Primary, 
                            ModernTheme.Accent, 
                            LinearGradientMode.Horizontal))
                        {
                            g.FillPath(brush, progressPath);
                        }
                    }
                }
            }
        }
    }
}
