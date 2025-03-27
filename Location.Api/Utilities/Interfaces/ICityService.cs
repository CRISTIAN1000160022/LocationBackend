using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Api.Controllers.City;
using Location.Model.DaoAccess.Master.City;
using Location.Model.Service;

namespace Location.Api.Utilities.Interfaces
{
	public class CityService : ICityService
	{
        private readonly Facade _facade;

        public CityService(Facade facade)
        {
            _facade = facade;
        }

        public List<AllCity> GetAllCities()
        {
            return _facade.GetAllCities();
        }

        public List<AllCity> AddCity(AllCity addCityRequest)
        {
            return _facade.AddCity(addCityRequest);
        }

        public List<AllCity> UpdateCity(AllCity updateCityRequest)
        {
            return _facade.UpdateCity(updateCityRequest);
        }

        public void DeleteCity(string cityId)
        {
            _facade.DeleteCity(cityId);
        }
    }
    public class ValidationCityService : IValidationCityService
    {
        public void ValidateCity(AllCity city)
        {
            if (city.Name.Length > 100)
            {
                throw new Exception("El campo 'Name' supera la longitud permitida de 100 caracteres.");
            }
        }
    }
}