using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_RestSharp.Request
{
    internal class SubmitJokeRequest
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }

        public flags flags { get; set; }

        public bool safe { get; set; }
        public int id { get; set; }
        public string lang { get; set; }

    }

    public class flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        public bool @explicit { get; set; }

    }
}
