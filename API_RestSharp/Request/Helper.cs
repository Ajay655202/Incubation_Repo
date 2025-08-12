using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_RestSharp.Request
{
    internal class Helper
    {

        public static string CreateSubmitRequestPayload(string joke, bool error = false, string category = "Programming", string type = "single",
                 bool nsfw = false, bool religious = false, bool political = false, bool racist = false, bool sexist = false, bool @explicit = false,
                 bool safe = true, int id = 318, string lang = "en")
        {
            //Adding all the payload values to Created class objects
            SubmitJokeRequest request = new SubmitJokeRequest();
            request.joke = joke;
            request.error = error;
            request.category = category;
            request.type = type;
            request.flags = new flags
            {
                nsfw = nsfw,
                religious = religious,
                political = political,
                racist = racist,
                sexist = sexist,
                @explicit = @explicit
            };
            request.safe = safe;
            request.id = id;
            request.lang = lang;

            //Serializing into Json
            string payload = JsonConvert.SerializeObject(request);
            return payload;
        }
    }
}
