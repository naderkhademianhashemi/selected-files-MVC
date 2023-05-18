using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1.Tools
{
    public static class Logger
    {
        static string _fileAddress = HttpContext.Current.Server.MapPath(string.Format("/Logs/{0}.txt", DateUtility.MiladiToShamsi(DateTime.Now)));
        public static void Error(Exception ex)
        {
            string message = string.Format("Error====>DateTime:{0}=====Exception:{1}", DateTime.Now, ex.ToString());
            File.AppendAllLines(_fileAddress, new List<string> { message });
        }

        public static void Error(Exception ex, string msg)
        {
            string message = string.Format("Error====>DateTime:{0}=====Exception:{1}", DateTime.Now, ex.ToString());
            File.AppendAllLines(_fileAddress, new List<string> { message });
        }

        public static void Info(string msg , string place)
        {
            string message = string.Format("Info====>DateTime:{0}=====Place:{1}=====Message:{2}",
                 DateTime.Now, place, msg);
            File.AppendAllLines(_fileAddress, new List<string> { message });
        }
    }
}