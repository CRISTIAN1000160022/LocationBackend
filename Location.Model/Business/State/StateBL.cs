using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.DaoAccess.Master.State;
using Location.Model.DaoAccess.Process.State;

namespace Location.Model.Business.State
{
    public class StateBL
    {
        public List<AllState> GetAllStates()
        {
            return new StateDAO().GetAllStates();
        }
        public List<AllState> AddState(AllState addStateRequest)
        {
            return new StateDAO().AddState(addStateRequest);
        }
        public List<AllState> UpdateState(AllState updateStateRequest)
        {
            return new StateDAO().UpdateState(updateStateRequest);
        }
        public void DeleteState(string stateId)
        {
            new StateDAO().DeleteState(stateId);
        }
    }
}
