using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Model.DaoAccess.Master.Country;
using Newtonsoft.Json;

namespace Location.Api.Models.Country
{
	public class ResponseCountry
	{
        public class ResponseGetAllCountries : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<AllCountry> Data { get; set; }
        }
    }
}