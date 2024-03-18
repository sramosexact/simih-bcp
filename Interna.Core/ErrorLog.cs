using System;
using System.IO;

namespace Interna.Core
{
    public class ErrorLog
    {

        private string fileName = @"C:\errorLogRVA.txt"; // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ErrorLogSIM.txt";

        public void EscribirLog(string logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(string.Format("{0} - {1}", DateTime.Now, logText));
                }
            }
            catch { }
        }

        public void EscribirLog(Exception ex)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine("--------------------------------------------------------------------------------");
                    w.WriteLine(DateTime.Now.ToString() + " - EXCEPCION");
                    w.WriteLine("Message: " + ex.Message);
                    w.WriteLine("Source: " + ex.Source);
                    w.WriteLine("TargetSite: " + ex.TargetSite);
                    w.WriteLine("StackTrace: " + ex.StackTrace);
                    w.WriteLine("InnerException: " + ex.InnerException);
                    w.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch { }
        }
    }
}
