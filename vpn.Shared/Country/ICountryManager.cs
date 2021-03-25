using System.Collections.Generic;

namespace vpn.Shared.Country
{
    public interface ICountryManager
    {
        IEnumerable<Country> GetCountries();
    }
}
