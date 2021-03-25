using System;
using vpn.Shared.Network;

namespace vpn.Network.Event
{
    public class StatusChangedEventArgs : EventArgs
    {
        public StatusChangedEventArgs(ConnectionStatus status)
        {
            Status = status;
        }

        public ConnectionStatus Status { get; }
    }
}