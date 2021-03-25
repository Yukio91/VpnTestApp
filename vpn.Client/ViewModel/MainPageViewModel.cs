using System;
using System.Threading.Tasks;
using vpn.Client.Base;
using vpn.Client.Utils;
using vpn.Network.Base;
using vpn.Shared.Logger;
using vpn.Shared.Network;

namespace vpn.Client.ViewModel
{
    public class MainPageViewModel : NotifyObjectBase
    {
        public RelayCommand ConnectCommand { get; }
        public RelayCommand ChooseCountryCommand { get; }

        public ILogger Logger { get; }
        public NetworkManagerBase NetworkManager { get; }

        public MainPageViewModel(NetworkManagerBase networkManager)
        {
            NetworkManager = networkManager;
            NetworkManager.StatusChanged += NetworkManager_StatusChanged;
            ConnectCommand = new RelayCommand(async o => await ConnectCommandExecute(), ce => ConnectCanExecute());
            ChooseCountryCommand = new RelayCommand(o => ChooseCountryCommandExecute());
        }

        private void NetworkManager_StatusChanged(object sender, Network.Event.StatusChangedEventArgs e)
        {
            
        }

        private bool ConnectCanExecute()
        {
            var status = NetworkManager.Status;
            return status == ConnectionStatus.Disconnected || status == ConnectionStatus.None;
        }

        private async Task ConnectCommandExecute()
        {
           await NetworkManager.ConnectAsync();
        }

        private void ChooseCountryCommandExecute()
        {

        }
    }
}
