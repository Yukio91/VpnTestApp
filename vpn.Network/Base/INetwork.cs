using System;
using System.Threading.Tasks;

namespace vpn.Network.Base
{
    public interface INetwork
    {        
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}
