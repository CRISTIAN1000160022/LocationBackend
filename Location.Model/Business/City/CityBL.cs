using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.DaoAccess.Master.City;
using Location.Model.DaoAccess.Process.City;

namespace Location.Model.Business.City
{
    public class CityBL
    {
        public List<AllCity> GetAllCities()
        {
            return new CityDAO().GetAllCities();
        }
        public List<AllCity> AddCity(AllCity addCityRequest)
        {
            return new CityDAO().AddCity(addCityRequest);
        }
        public List<AllCity> UpdateCity(AllCity updateCityRequest)
        {
            return new CityDAO().UpdateCity(updateCityRequest);
        }
        public void DeleteCity(string cityId)
        {
            new CityDAO().DeleteCity(cityId);
        }
    }
}
