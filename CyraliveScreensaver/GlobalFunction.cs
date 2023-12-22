using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace CyraliveScreensaver
{
    internal class GlobalFunction
    {
        public static int MouseMoveCount = 0;
        public static bool CSpreview = false;
        public static void MouseInterAction()
        {
            if (MouseMoveCount > 40)
            {
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    window.Close();
                }
            }
        }

        public static bool Gencfg()
        {
            try
            {
                JsonObject CSconfig = new JsonObject
                {
                    { "theme", 0 },
                    { "snowfall", false }
                };
                StreamWriter streamWriter = File.CreateText("CyraliveScreensaver.json");
                streamWriter.WriteLine(JsonSerializer.Serialize(CSconfig, new JsonSerializerOptions { WriteIndented = true }));
                streamWriter.Close();
                return true;
            }
            catch 
            { 
                return false;
            }
        }
    }
}
