using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Model.DaoAccess.Master.City;
using Newtonsoft.Json;

namespace Location.Api.Models.City
{
	public class ResponseCity
	{
        public class ResponseGetAllCities : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<AllCity> Data { get; set; }
        }
    }
}