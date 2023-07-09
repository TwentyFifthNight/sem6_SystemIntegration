using System.Collections.Generic;
using System.Formats.Asn1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }

        public string Voivodeship { get; set; }
    }
}
