using System;
using JLogging;

namespace JSystem.Perform
{
    public class LogManager
    {
        private static LogManager _instance;

        public static LogManager Instance => _instance ?? (_instance = new LogManager());

        public Action<string> OnAddLog;

        public LogManager()
        {
        }

        public void AddLog(string msg, bool isError = false)
        {
            LoggingIF.Log(msg, isError ? LogLevels.Error : LogLevels.Info);
            OnAddLog?.Invoke(DateTime.Now.ToString("HH:mm:ss:fff  ") + msg.ToString() + "\r\n");
        }
    }
}
