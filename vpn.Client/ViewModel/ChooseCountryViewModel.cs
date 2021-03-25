using System;
using System.Collections.Generic;
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

        public RelayCommand AcceptChooseCommand { get; }

        public ChooseCountryViewModel(Action closeWindow, ICountryManager countryManager, NetworkManagerBase networkManager)
        {
            _closeWindow = closeWindow;
            Countries = countryManager.GetCountries();
            AcceptChooseCommand = new RelayCommand(AcceptChooseCommandExecute, ce=>AcceptChooseCanExecute());

            NetworkManager = networkManager;
        }

        private void AcceptChooseCommandExecute(object obj)
        {
            NetworkManager.SetCountry(_selectedCountry);
            _closeWindow();
        }

        private bool AcceptChooseCanExecute()
        {
            return _selectedCountry != null;
        }
    }
}
