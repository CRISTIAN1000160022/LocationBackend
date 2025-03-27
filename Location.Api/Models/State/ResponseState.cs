using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Location.Model.DaoAccess.Master.State;
using Newtonsoft.Json;

namespace Location.Api.Models.State
{
	public class ResponseState
	{
        public class ResponseGetAllStates : ResponseHeader
        {
            [JsonProperty(Order = 3)]
            public List<AllState> Data { get; set; }
        }
    }
}