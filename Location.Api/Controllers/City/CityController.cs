using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Location.Model.DaoAccess.Master.City;
using static Location.Api.Models.City.ResponseCity;

namespace Location.Api.Controllers.City
{
    [Authorize]
    public class CityController : ApiController
    {
        private readonly ICityService _cityService;
        private readonly IValidationCityService _validationService;

        public CityController(ICityService cityService, IValidationCityService validationService)
        {
            _cityService = cityService;
            _validationService = validationService;
        }

        [HttpGet]
        public IHttpActionResult GetAllCities()
        {
            var response = new ResponseGetAllCities();
            try
            {
                var cities = _cityService.GetAllCities();
                response.success = true;
                response.message = "Lista de ciudades generada correctamente";
                response.Data = cities;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex.Message;
                response.Data = null;
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [HttpPost]
        public IHttpActionResult AddCity(AllCity addCityRequest)
        {
            var response = new ResponseGetAllCities();
            try
            {
                _validationService.ValidateCity(addCityRequest);
                var cities = _cityService.AddCity(addCityRequest);
                response.success = true;
                response.message = "Ciudad generada correctamente";
                response.Data = cities;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex.Message;
                response.Data = null;
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateCity(AllCity updateCityRequest)
        {
            var response = new ResponseGetAllCities();
            try
            {
                _validationService.ValidateCity(updateCityRequest);
                var cities = _cityService.UpdateCity(updateCityRequest);
                response.success = true;
                response.message = "Ciudad actualizada correctamente";
                response.Data = cities;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex.Message;
                response.Data = null;
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteCity(string cityId)
        {
            var response = new ResponseGetAllCities();
            try
            {
                _cityService.DeleteCity(cityId);
                response.success = true;
                response.message = "Ciudad eliminada correctamente";
                response.Data = null;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex.Message;
                response.Data = null;
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
    }
    public interface ICityService
    {
        List<AllCity> GetAllCities();
        List<AllCity> AddCity(AllCity addCityRequest);
        List<AllCity> UpdateCity(AllCity updateCityRequest);
        void DeleteCity(string cityId);
    }
    public interface IValidationCityService
    {
        void ValidateCity(AllCity city);
    }
}
