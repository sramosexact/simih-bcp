using System;
using System.Configuration;
using System.IO;

namespace SIMIHSFTP.FILES
{
    public static class LogFile
    {
        static string fileName = ConfigurationManager.AppSettings["LogFilePath"] == "" ? $@"{AppContext.BaseDirectory}\ErrorLogRVA.txt" : $@"{ConfigurationManager.AppSettings["LogFilePath"]}\ErrorLogRVA.txt";

        public static void WriteLog(Exception ex)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine("--------------------------------------------------------------------------------");
                    w.WriteLine($@"{DateTime.Now.ToString()} - EXCEPCION");
                    w.WriteLine($"Message: {ex.Message}");
                    w.WriteLine($"Source: {ex.Source}");
                    w.WriteLine($"TargetSite: {ex.TargetSite}");
                    w.WriteLine($"StackTrace: {ex.StackTrace}");
                    w.WriteLine($"InnerException: {ex.InnerException}");
                    w.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch { }
        }

        public static void WriteLog(string logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine("--------------------------------------------------------------------------------");
                    w.WriteLine($@"{DateTime.Now} - {logText}");
                    w.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch { }
        }
    }
}
