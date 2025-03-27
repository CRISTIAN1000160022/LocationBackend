using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Location.Api.Models.Login
{
    public class ResponseLogin : ResponseHeader
    {
        [JsonProperty(Order = 3)]
        public string Data { get; set; }
    }
}