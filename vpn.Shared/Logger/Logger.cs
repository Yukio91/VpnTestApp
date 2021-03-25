using NLog;
using System;

namespace vpn.Shared.Logger
{
    public class Logger : ILogger
    {
        private static readonly NLog.Logger _logger = LogManager.GetLogger(nameof(Logger), typeof(object));
        private static Logger _instance;

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            _logger.Error(exception, message);
        }        

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }
    }
}
