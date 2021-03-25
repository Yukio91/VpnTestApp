using vpn.Client.Base;
using vpn.Network.Manager;

namespace vpn.Client.ViewModel
{
    public class MainWindowViewModel : NotifyObjectBase
    {
        public MainPageViewModel MainPageViewModel { get; set; }

        public MainWindowViewModel()
        {
            var networkManager = new NetworkManager();
            MainPageViewModel = new MainPageViewModel(networkManager);
        }
    }
}
