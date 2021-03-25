using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        public ICommand ConnectCommand { get; }
        public ICommand ChooseCountryCommand { get; }

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


        public MainPageViewModel(NetworkManagerBase networkManager, ILogger logger)
        {
            Logger = logger;
            NetworkManager = networkManager;
            NetworkManager.StatusChanged += NetworkManager_StatusChanged;
            NetworkManager.CountryChanged += NetworkManager_CountryChanged;

            ConnectCommand = new RelayCommand(async o => await ConnectCommandExecute(), ce => ConnectCanExecute());
            ChooseCountryCommand = new RelayCommand(o => ChooseCountryCommandExecute());
        }

        private void NetworkManager_CountryChanged(object sender, Network.Event.CountryChangedEventArgs e)
        {
            SelectedCountry = e.Country;
        }

        private void NetworkManager_StatusChanged(object sender, Network.Event.StatusChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NetworkManager));
        }

        private bool ConnectCanExecute()
        {
            var status = NetworkManager.Status;
            return SelectedCountry != null
                && (status == ConnectionStatus.Connected
                || status == ConnectionStatus.Disconnected
                || status == ConnectionStatus.None);
        }

        private async Task ConnectCommandExecute()
        {
            Logger.Info("Connecting to server");
            await NetworkManager.ConnectAsync();
        }

        private void ChooseCountryCommandExecute()
        {
            var window = new ChooseCountryWindowView(this)
            {
                Owner = Application.Current.MainWindow
            };

            var result = window.ShowDialog();
            if (result == true)
            {
                OnPropertyChanged(nameof(NetworkManager));
            }
        }
    }
}
