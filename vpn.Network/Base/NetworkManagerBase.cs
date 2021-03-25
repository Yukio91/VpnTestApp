using System;
using System.Threading.Tasks;
using vpn.Network.Event;
using vpn.Shared.Country;
using vpn.Shared.Network;

namespace vpn.Network.Base
{
    public abstract class NetworkManagerBase : INetwork
    {
        private ConnectionStatus _status = ConnectionStatus.None;
        private Country _currentCountry;

        public ConnectionStatus Status { get => _status; protected set => OnStatusChanged(value); }
        public Country CurrentCountry { get => _currentCountry; protected set => OnCountryChanged(value); }

        public abstract Task ConnectAsync();

        public abstract Task DisconnectAsync();

        public virtual void SetCountry(Country country)
        {
            CurrentCountry = country ?? throw new ArgumentNullException(nameof(country));
        }

        protected void OnStatusChanged(ConnectionStatus status)
        {
            _status = status;
            StatusChanged?.Invoke(this, new StatusChangedEventArgs(status));
        }

        protected void OnCountryChanged(Country country)
        {
            _currentCountry = country;
            CountryChanged?.Invoke(this, new CountryChangedEventArgs(country));
        }

        public virtual event EventHandler<StatusChangedEventArgs> StatusChanged;
        public virtual event EventHandler<CountryChangedEventArgs> CountryChanged;
    }
}
