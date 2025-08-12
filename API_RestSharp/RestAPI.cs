using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API_RestSharp
{
    [TestClass]
    public class RestAPI
    {
        private HttpClient _client;


        [TestMethod]
        public async Task Get_Post_ById_ShouldReturnPost()
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
            };
            var response = await _client.GetAsync("posts/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Contains("\"id\": 1"));
        }

    }
}
