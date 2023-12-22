using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CyraliveScreensaver
{
    /// <summary>
    /// CSsettings.xaml 的交互逻辑
    /// </summary>
    public partial class CSsettings : Window
    {
        JsonNode getCyraliveConfig = JsonNode.Parse(File.ReadAllText("CyraliveScreensaver.json"));
        public CSsettings()
        {
            InitializeComponent();
            object[] all_author = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            author_info.Text = "作者: " + ((AssemblyCompanyAttribute)all_author[0]).Company;
            ver_info.Text = "版本: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if ((int)getCyraliveConfig["theme"] != 0)
            {
                CStheme.SelectedIndex = (int)getCyraliveConfig["theme"];
            }
            if ((bool)getCyraliveConfig["snowfall"])
            {
                CSsnowfall.IsChecked = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            getCyraliveConfig["theme"] = CStheme.SelectedIndex;
            getCyraliveConfig["snowfall"] = CSsnowfall.IsChecked;
            File.WriteAllText("CyraliveScreensaver.json", getCyraliveConfig.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
            Process process = new Process();
            process.StartInfo.FileName = Assembly.GetExecutingAssembly().GetName().Name + ".exe";
            process.StartInfo.Arguments = "/p";
            process.Start();
        }
    }
}
