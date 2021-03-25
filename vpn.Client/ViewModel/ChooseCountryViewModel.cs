using System;
using System.Collections.Generic;
using System.Windows.Input;
using vpn.Client.Base;
using vpn.Client.Utils;
using vpn.Network.Base;
using vpn.Shared.Country;

namespace vpn.Client.ViewModel
{
    public class ChooseCountryViewModel : NotifyObjectBase
    {
        private Action _closeWindow;
        private Country _selectedCountry;
        private readonly MainPageViewModel _mainPage;

        public Country SelectedCountry
        {
            get => _selectedCountry; set
            {
                _selectedCountry = value;
                OnPropertyChanged();
            }
        }

        public NetworkManagerBase NetworkManager { get; }        

        public IEnumerable<Country> Countries { get; }

        public ICommand AcceptChooseCommand { get; }

        public ChooseCountryViewModel(Action closeWindow, ICountryManager countryManager, NetworkManagerBase networkManager)
        {
            _closeWindow = closeWindow;
            Countries = countryManager.GetCountries();
            AcceptChooseCommand = new RelayCommand(AcceptChooseCommandExecute, ce=>AcceptChooseCanExecute());

            NetworkManager = networkManager;
        }

        public ChooseCountryViewModel(MainPageViewModel mainPage): this(null, new CountryManager(), mainPage.NetworkManager)
        {
            _mainPage = mainPage;
        }

        private void AcceptChooseCommandExecute(object obj)
        {
            NetworkManager.SetCountry(_selectedCountry);
            OnCloseWindow();
        }

        private bool AcceptChooseCanExecute()
        {
            return _selectedCountry != null;
        }

        public event EventHandler<EventArgs> CloseWindow;

        private void OnCloseWindow()
        {
            CloseWindow?.Invoke(this, new EventArgs());
        }
    }
}
