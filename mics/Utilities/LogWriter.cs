using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace MICS.Utilities
{
   
    public class LogWriter
    {
        private FileInfo _LogFile = null;
        private StreamWriter _LogFileWriter = null;
        private StreamWriter writer = null;
        
        public LogWriter()
        {
            try
            {
                //System.Configuration.ConfigurationManager.AppSettings

                
                //string fileName =System.Configuration.ConfigurationManager.AppSettings["logfile"];
                string fileName = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + ".log";
                string filePath = System.Configuration.ConfigurationManager.AppSettings["logfolder"];
                _LogFile = new FileInfo(filePath + fileName);
            }
            catch
            {
                throw new FileNotFoundException("Error reading the configuration file");
            }
        }
        public DateTime LastUpdateTime
        {
            get { return _LogFile.LastWriteTime; }
        }


        private StreamWriter GetLogWriter()
        {
            if (_LogFileWriter == null)
            {
                if (_LogFile.Exists)
                {
                    _LogFileWriter = new StreamWriter(_LogFile.Open(FileMode.Append, FileAccess.Write));
                }
                else
                {
                    _LogFileWriter = new StreamWriter(_LogFile.Create());
                }
            }
            return _LogFileWriter;
        }
        public void Write(string message, string procedureName)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int diff = DateTime.Compare(LastUpdateTime, DateTime.Today);
            writer = GetLogWriter();
            if (diff < 0)
            {
                writer.WriteLine("**************************** " + DateTime.Today.ToString() + " ***********************************");
            }
            writer.WriteLine("Time: " + date + " | Procedure Name: " + procedureName + " | Error: " + message);
            CloseLog();

        }
        private void CloseLog()
        {
            writer.Flush();
            writer.Close();
            writer = null;

        }




    }
}
