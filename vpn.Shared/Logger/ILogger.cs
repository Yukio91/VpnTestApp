using System;

namespace vpn.Shared.Logger
{
    public interface ILogger
    {
        void Trace(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Error(Exception exception, string message);
    }
}
