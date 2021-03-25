using vpn.Client.Base;
using vpn.Network.Manager;
using vpn.Shared.Logger;

namespace vpn.Client.ViewModel
{
    public class MainWindowViewModel : NotifyObjectBase
    {
        public MainPageViewModel MainPageViewModel { get; set; }

        public MainWindowViewModel()
        {
            var networkManager = new NetworkManager();
            var logger = new Logger();
            MainPageViewModel = new MainPageViewModel(networkManager, logger);
        }
    }
}
