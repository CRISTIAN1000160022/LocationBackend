using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Location.Model.Service
{
    public static class Constants
    {
        public static readonly string DBConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}
