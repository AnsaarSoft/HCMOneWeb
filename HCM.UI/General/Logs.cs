namespace HCM.UI.General
{
    public class Logs
    {
        public static void GenerateLogs(Exception LogMessage)
        {
            try
            {
                DateTime ExceptionDate = System.DateTime.Now;
                if (!File.Exists("MEPL_Logs_UI.txt"))
                {
                    File.Create("MEPL_Logs_UI.txt").Close();
                    using (StreamWriter sw = File.AppendText("MEPL_Logs_UI.txt"))
                    {
                        sw.WriteLine(LogMessage + ": " + ExceptionDate, LogMessage.Message, LogMessage.InnerException == null ? "" : LogMessage.InnerException.ToString(), LogMessage.StackTrace);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText("MEPL_Logs_UI.txt"))
                    {
                        sw.WriteLine(LogMessage + ": " + ExceptionDate, LogMessage.Message, LogMessage.InnerException == null ? "" : LogMessage.InnerException.ToString(), LogMessage.StackTrace);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public static void GenerateLogs(string LogMessage)
        {
            try
            {
                DateTime ExceptionDate = System.DateTime.Now;
                if (!File.Exists("MEPL_Logs_UI.txt"))
                {
                    File.Create("MEPL_Logs_UI.txt").Close();
                    using (StreamWriter sw = File.AppendText("MEPL_Logs_UI.txt"))
                    {
                        sw.WriteLine(LogMessage + ": " + ExceptionDate, LogMessage);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText("MEPL_Logs_UI.txt"))
                    {
                        sw.WriteLine(LogMessage + ": " + ExceptionDate, LogMessage);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
