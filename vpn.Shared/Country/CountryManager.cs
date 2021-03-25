using System;
using System.Collections.Generic;

namespace vpn.Shared.Country
{
    public class CountryManager : ICountryManager
    {
        public IEnumerable<Country> GetCountries()
        {
            return new List<Country>();
        }
    }
}
