using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.Business.City;
using Location.Model.Business.Country;
using Location.Model.Business.State;
using Location.Model.DaoAccess.Master.City;
using Location.Model.DaoAccess.Master.Country;
using Location.Model.DaoAccess.Master.State;

namespace Location.Model.Service
{
    public class Facade
    {
        #region Country
        public List<AllCountry> GetAllCountries()
        {
            return new CountryBL().GetAllCountries();
        }
        public List<AllCountry> AddCountry(AllCountry addCountryRequest)
        {
            return new CountryBL().AddCountry(addCountryRequest);
        }
        public List<AllCountry> UpdateCountry(AllCountry updateCountryRequest)
        {
            return new CountryBL().UpdateCountry(updateCountryRequest);
        }
        public void DeleteCountry(string countryId)
        {
            new CountryBL().DeleteCountry(countryId);
        }
        #endregion
        #region State
        public List<AllState> GetAllStates()
        {
            return new StateBL().GetAllStates();
        }
        public List<AllState> AddState(AllState addStateRequest)
        {
            return new StateBL().AddState(addStateRequest);
        }
        public List<AllState> UpdateState(AllState updateStateRequest)
        {
            return new StateBL().UpdateState(updateStateRequest);
        }
        public void DeleteState(string stateId)
        {
            new StateBL().DeleteState(stateId);
        }
        #endregion
        #region City
        public List<AllCity> GetAllCities()
        {
            return new CityBL().GetAllCities();
        }
        public List<AllCity> AddCity(AllCity addCityRequest)
        {
            return new CityBL().AddCity(addCityRequest);
        }
        public List<AllCity> UpdateCity(AllCity updateCityRequest)
        {
            return new CityBL().UpdateCity(updateCityRequest);
        }
        public void DeleteCity(string cityId)
        {
            new CityBL().DeleteCity(cityId);
        }
        #endregion
    }
}
