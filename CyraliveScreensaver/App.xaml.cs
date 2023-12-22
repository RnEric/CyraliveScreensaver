using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Interop;
using static CyraliveScreensaver.GlobalFunction;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CyraliveScreensaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            if (e.Args.Length > 0)
            {
                if (e.Args[0].ToLower().StartsWith("/p"))
                {
                    CSpreview = true;   
                    Window Cyralivepreview = new MainWindow();
                    Cyralivepreview.Title = "锁屏界面预览";
                    Cyralivepreview.WindowState = WindowState.Normal;
                    Cyralivepreview.WindowStyle = WindowStyle.SingleBorderWindow;
                    Cyralivepreview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    Cyralivepreview.Show();
                }
                else if (e.Args[0].ToLower().StartsWith("/s"))
                {
                    new MainWindow().Show();
                }
                else if (e.Args[0].ToLower().StartsWith("/c"))
                {
                    new CSsettings().Show();
                }
                else if (e.Args[0].ToLower().StartsWith("/gencfg"))
                {
                    if (Gencfg())
                    {
                        MessageBox.Show("初始化成功。", "初始化成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("初始化失败。", "初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Current.Shutdown();
                }
            }
            else
            {
                Current.Shutdown();
            }
        }
    }

}
