using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Location.Model.DaoAccess.Master.State;
using static Location.Api.Models.State.ResponseState;

namespace Location.Api.Controllers.State
{
    [Authorize]
    public class StateController : ApiController
    {
        private readonly IStateService _stateService;
        private readonly IValidationStateService _validationService;
        public StateController(IStateService stateService, IValidationStateService validationService)
        {
            _stateService = stateService;
            _validationService = validationService;
        }
        [HttpGet]
        public IHttpActionResult GetAllStates()
        {
            var response = new ResponseGetAllStates();
            try
            {
                var states = _stateService.GetAllStates();
                response.success = true;
                response.message = "Lista de departamentos generada correctamente";
                response.Data = states;
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
        public IHttpActionResult AddState(AllState addStateRequest)
        {
            var response = new ResponseGetAllStates();
            try
            {
                _validationService.ValidateState(addStateRequest);
                var states = _stateService.AddState(addStateRequest);
                response.success = true;
                response.message = "Departamento generado correctamente";
                response.Data = states;
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
        public IHttpActionResult UpdateState(AllState updateStateRequest)
        {
            var response = new ResponseGetAllStates();
            try
            {
                _validationService.ValidateState(updateStateRequest);
                var states = _stateService.UpdateState(updateStateRequest);
                response.success = true;
                response.message = "Departamento actualizado correctamente";
                response.Data = states;
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
        public IHttpActionResult DeleteState(string stateId)
        {
            var response = new ResponseGetAllStates();
            try
            {
                _stateService.DeleteState(stateId);
                response.success = true;
                response.message = "Departamento eliminado correctamente";
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
    public interface IStateService
    {
        List<AllState> GetAllStates();
        List<AllState> AddState(AllState addStateRequest);
        List<AllState> UpdateState(AllState updateStateRequest);
        void DeleteState(string stateId);
    }
    public interface IValidationStateService
    {
        void ValidateState(AllState state);
    }
}
