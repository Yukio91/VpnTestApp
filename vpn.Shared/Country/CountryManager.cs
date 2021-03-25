using FamFamFam.Flags.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace vpn.Shared.Country
{
    public class CountryManager : ICountryManager
    {
        private IEnumerable<Country> _countries;

        /// <inheritdoc/>
        public IEnumerable<Country> GetCountries()
        {
            if (_countries != null)
            {
                return _countries;
            }

            return _countries = CountryData.AllCountries.Select(i => new Country(i.Name, i.Iso2));
        }
    }
}
