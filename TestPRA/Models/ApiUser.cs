using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPRA.Models
{
    public class ApiUser
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("pass")]
        public string Pass { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }
    }
}
