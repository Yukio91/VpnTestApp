using System;
using System.Threading.Tasks;
using System.Windows;
using vpn.Client.Base;
using vpn.Client.Utils;
using vpn.Client.Windows;
using vpn.Network.Base;
using vpn.Shared.Country;
using vpn.Shared.Logger;
using vpn.Shared.Network;

namespace vpn.Client.ViewModel
{
    public class MainPageViewModel : NotifyObjectBase
    {
        private Country _selectedCountry;

        public RelayCommand ConnectCommand { get; }
        public RelayCommand ChooseCountryCommand { get; }

        public ILogger Logger { get; }
        public NetworkManagerBase NetworkManager { get; }

        public Country SelectedCountry
        {
            get => _selectedCountry; set
            {
                _selectedCountry = value;
                OnPropertyChanged();
            }
        }

        public Func<ChooseCountryWindowView> CountryWindowFactory { get; set; }

        public MainPageViewModel(NetworkManagerBase networkManager)
        {
            NetworkManager = networkManager;
            NetworkManager.StatusChanged += NetworkManager_StatusChanged;

            ConnectCommand = new RelayCommand(async o => await ConnectCommandExecute(), ce => ConnectCanExecute());
            ChooseCountryCommand = new RelayCommand(o => ChooseCountryCommandExecute());
        }

        private void NetworkManager_StatusChanged(object sender, Network.Event.StatusChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NetworkManager));
        }

        private bool ConnectCanExecute()
        {
            var status = NetworkManager.Status;
            return status == ConnectionStatus.Disconnected || status == ConnectionStatus.None;
        }

        private async Task ConnectCommandExecute()
        {
            Logger.Info("Connecting to server");
            await NetworkManager.ConnectAsync();
        }

        private void ChooseCountryCommandExecute()
        {
            var window = CountryWindowFactory();
            window.Owner = Application.Current.MainWindow;

            var result = window.ShowDialog();
            if (result == true)
            {
                OnPropertyChanged(nameof(NetworkManager));
            }
        }
    }
}
