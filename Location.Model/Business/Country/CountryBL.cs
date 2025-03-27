using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.DaoAccess.Master.Country;
using Location.Model.DaoAccess.Process.Country;

namespace Location.Model.Business.Country
{
    public class CountryBL
    {
        public List<AllCountry> GetAllCountries()
        {
            return new CountryDAO().GetAllCountries();
        }
        public List<AllCountry> AddCountry(AllCountry addCountryRequest)
        {
            return new CountryDAO().AddCountry(addCountryRequest);
        }
        public List<AllCountry> UpdateCountry(AllCountry updateCountryRequest)
        {
            return new CountryDAO().UpdateCountry(updateCountryRequest);
        }
        public void DeleteCountry(string countryId)
        {
            new CountryDAO().DeleteCountry(countryId);
        }
    }
}
