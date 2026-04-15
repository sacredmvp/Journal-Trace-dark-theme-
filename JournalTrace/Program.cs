using JournalTrace.Language;
using JournalTrace.View;
using JournalTrace.View.Util;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JournalTrace
{
    internal static class Program
    {
        [DllImport("uxtheme.dll", EntryPoint = "#135", CharSet = CharSet.Unicode)]
        private static extern int SetPreferredAppMode(int preferredAppMode);

        [DllImport("uxtheme.dll", EntryPoint = "#136", CharSet = CharSet.Unicode)]
        private static extern void FlushMenuThemes();

        [DllImport("uxtheme.dll", EntryPoint = "#104", CharSet = CharSet.Unicode)]
        private static extern void RefreshImmersiveColorPolicyState();

        private const int PreferredAppMode_AllowDark = 1;
        private const int PreferredAppMode_ForceDark = 2;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            _ = new LanguageManager();
            _ = new ContextMenuHelper();
            
            // Enable dark mode for the entire application
            try
            {
                if (Environment.OSVersion.Version.Major >= 10)
                {
                    SetPreferredAppMode(PreferredAppMode_ForceDark);
                    FlushMenuThemes();
                    RefreshImmersiveColorPolicyState();
                    
                    // Set registry key for dark mode (Windows 10 1809+)
                    try
                    {
                        using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                        {
                            // This is just for the app, doesn't change system settings
                        }
                    }
                    catch { }
                }
            }
            catch { }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}