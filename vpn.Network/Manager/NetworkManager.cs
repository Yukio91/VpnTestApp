using System;
using System.Threading.Tasks;
using vpn.Network.Base;
using vpn.Shared.Network;

namespace vpn.Network.Manager
{
    public class NetworkManager : NetworkManagerBase
    {
        public override async Task ConnectAsync()
        {
            try
            {
                Status = ConnectionStatus.Connecting;
                await Task.Delay(5000);
                Status = ConnectionStatus.Connected;
            }
            catch (Exception)
            {
                Status = ConnectionStatus.Failed;
                throw;
            }
        }

        public override async Task DisconnectAsync()
        {
            Status = ConnectionStatus.Disconnecting;
            await Task.Delay(5000);
            Status = ConnectionStatus.Disconnected;
        }
    }
}
