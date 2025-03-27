using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Api.Controllers.Country;
using Location.Api.Controllers.State;
using Location.Model.DaoAccess.Master.State;
using Location.Model.Service;

namespace Location.Api.Utilities.Interfaces
{
    public class StateService : IStateService
    {
        private readonly Facade _facade;
        public StateService()
        {
            _facade = new Facade();
        }
        public List<AllState> GetAllStates()
        {
            return _facade.GetAllStates();
        }
        public List<AllState> AddState(AllState addStateRequest)
        {
            return _facade.AddState(addStateRequest);
        }
        public List<AllState> UpdateState(AllState updateStateRequest)
        {
            return _facade.UpdateState(updateStateRequest);
        }
        public void DeleteState(string stateId)
        {
            _facade.DeleteState(stateId);
        }

        public class ValidationStateService : IValidationStateService
        {
            public void ValidateState(AllState state)
            {
                if (state.Name.Length > 100)
                {
                    throw new Exception("El campo 'Name' supera la longitud permitida de 100 caracteres.");
                }
            }
        }
    }
}