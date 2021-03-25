using System;
using vpn.Shared.Country;

namespace vpn.Network.Event
{
    public class CountryChangedEventArgs : EventArgs
    {
        public CountryChangedEventArgs(Country country)
        {
            Country = country;
        }

        public Country Country { get; }
    }
}