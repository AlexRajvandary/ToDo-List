using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskLib
{
    public static class Logger
    {
        private static string path = "History.log";
        public static void Log(string msg)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, $"{DateTime.Now}__было добавлено: {msg}\n");
            }
            else
            {
                File.AppendAllText(path, $"{DateTime.Now}__было добавлено: {msg}\n");
            }
        }
    }
}
