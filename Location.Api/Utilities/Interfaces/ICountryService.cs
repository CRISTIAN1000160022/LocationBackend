using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Api.Controllers.Country;
using Location.Model.DaoAccess.Master.Country;
using Location.Model.Service;

namespace Location.Api.Utilities
{
    public class CountryService : ICountryService
    {
        private readonly Facade _facade;

        public CountryService()
        {
            _facade = new Facade();
        }

        public List<AllCountry> GetAllCountries()
        {
            return _facade.GetAllCountries();
        }

        public List<AllCountry> AddCountry(AllCountry addCountryRequest)
        {
            return _facade.AddCountry(addCountryRequest);
        }

        public List<AllCountry> UpdateCountry(AllCountry updateCountryRequest)
        {
            return _facade.UpdateCountry(updateCountryRequest);
        }

        public void DeleteCountry(string countryId)
        {
            _facade.DeleteCountry(countryId);
        }
    }

    public class ValidationCountryService : IValidationCountryService
    {
        public void ValidateCountry(AllCountry country)
        {
            if (country.Name.Length > 100)
            {
                throw new Exception("El campo 'Name' supera la longitud permitida de 100 caracteres.");
            }
            if (country.Code.Length > 10)
            {
                throw new Exception("El campo 'Code' supera la longitud permitida de 10 caracteres.");
            }
        }
    }
}