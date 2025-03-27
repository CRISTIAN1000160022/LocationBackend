using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Location.Model.DaoAccess.Master.Country;
using Location.Model.Service;
using static Location.Api.Models.Country.ResponseCountry;

namespace Location.Api.Controllers.Country
{
    [Authorize]
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;
        private readonly IValidationCountryService _validationService;

        public CountryController(ICountryService countryService, IValidationCountryService validationService)
        {
            _countryService = countryService;
            _validationService = validationService;
        }

        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            var response = new ResponseGetAllCountries();
            try
            {
                var countries = _countryService.GetAllCountries();
                response.success = true;
                response.message = "Lista de paises generada correctamente";
                response.Data = countries;
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
        public IHttpActionResult AddCountry(AllCountry addCountryRequest)
        {
            var response = new ResponseGetAllCountries();
            try
            {
                _validationService.ValidateCountry(addCountryRequest);
                var countries = _countryService.AddCountry(addCountryRequest);
                response.success = true;
                response.message = "País generado correctamente";
                response.Data = countries;
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
        public IHttpActionResult UpdateCountry(AllCountry updateCountryRequest)
        {
            var response = new ResponseGetAllCountries();
            try
            {
                _validationService.ValidateCountry(updateCountryRequest);
                var countries = _countryService.UpdateCountry(updateCountryRequest);
                response.success = true;
                response.message = "País actualizado correctamente";
                response.Data = countries;
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
        public IHttpActionResult DeleteCountry(string countryId)
        {
            var response = new ResponseGetAllCountries();
            try
            {
                _countryService.DeleteCountry(countryId);
                response.success = true;
                response.message = "País eliminado correctamente";
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

    public interface ICountryService
    {
        List<AllCountry> GetAllCountries();
        List<AllCountry> AddCountry(AllCountry addCountryRequest);
        List<AllCountry> UpdateCountry(AllCountry updateCountryRequest);
        void DeleteCountry(string countryId);
    }

    public interface IValidationCountryService
    {
        void ValidateCountry(AllCountry country);
    }
}