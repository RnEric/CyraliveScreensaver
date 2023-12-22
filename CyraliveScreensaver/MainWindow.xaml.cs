using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CyraliveScreensaver.GlobalFunction;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Threading;
using System.Text.Json.Nodes;
using System.IO;
using System.Text.Json;
using FontFamily = System.Windows.Media.FontFamily;

namespace CyraliveScreensaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageBrush Cyralive_Screensaver = new ImageBrush();
            if (!File.Exists("CyraliveScreensaver.json"))
            {
                Gencfg();
            }
            JsonNode getCyraliveConfig = JsonNode.Parse(File.ReadAllText("CyraliveScreensaver.json"));
            SnowEngine snow = new SnowEngine(Diphylleia_snowfall, "pack://application:,,,/snow/snow1.png",
                    "pack://application:,,,/snow/snow2.png",
                    "pack://application:,,,/snow/snow3.png",
                    "pack://application:,,,/snow/snow4.png",
                    "pack://application:,,,/snow/snow5.png",
                    "pack://application:,,,/snow/snow6.png",
                    "pack://application:,,,/snow/snow7.png",
                    "pack://application:,,,/snow/snow8.png",
                    "pack://application:,,,/snow/snow9.png");
            if ((int)getCyraliveConfig["theme"] == 1)
            {
                Cyralive_Screensaver.ImageSource = new BitmapImage(new Uri("pack://application:,,,/OR_golden2.jpg"));
                Cyralive_Screen_Clock.FontFamily = new FontFamily("Old English Text MT");
            }
            else if ((int)getCyraliveConfig["theme"] == 2)
            {
                Cyralive_Screensaver.ImageSource = new BitmapImage(new Uri("pack://application:,,,/OR_blue.jpg"));
                Cyralive_Screen_Clock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./#Digital-7");
            }
            else
            {
                Cyralive_Screensaver.ImageSource = new BitmapImage(new Uri("pack://application:,,,/CR_farewell.jpg"));
            }
            Cyralive_Screensaver.Stretch = Stretch.UniformToFill;
            Background = Cyralive_Screensaver;
            if ((bool)getCyraliveConfig["snowfall"])
            {
                snow.Start();
            }
            if (!CSpreview)
            {
                Cyralive_Screen_Clock.FontSize = 72;
            }
            else
            {
                Cyralive_Screen_Clock.FontSize = 24;
                ClearValue(CursorProperty);
                MouseMove -= Window_MouseMove;
                KeyUp -= Window_KeyUp;
            }
            Cyralive_Screen_Clock.Text = DateTime.Now.ToString("yyyy") + "." + DateTime.Now.ToString("MM") + "." + DateTime.Now.ToString("dd") + "\n" + DateTime.Now.ToString("T");
            Timer timer = new Timer(1000);
            timer.Elapsed += Clock_trigger;
            timer.Enabled = true;
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseMoveCount++;
            MouseInterAction();
        }

        private void Clock_trigger(object sender, EventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, () =>
            {
                Cyralive_Screen_Clock.Text = DateTime.Now.ToString("yyyy") + "." + DateTime.Now.ToString("MM") + "." + DateTime.Now.ToString("dd") + "\n" + DateTime.Now.ToString("T");
            });
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}