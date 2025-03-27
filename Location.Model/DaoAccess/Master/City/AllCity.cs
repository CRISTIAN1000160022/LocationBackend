using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Model.Business.City;
using Location.Model.Business.State;

namespace Location.Model.DaoAccess.Master.City
{
    public class AllCity
    {
        public string CityID { get; set; }
        public string Name { get; set; }
        public string StateID { get; set; }
        public string StateName { get; set; }
    }
}
