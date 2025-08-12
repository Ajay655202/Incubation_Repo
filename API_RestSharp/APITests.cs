using System;
using System.Web.Management;
using API_RestSharp.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace API_RestSharp
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void SubmitJoke()
        {
            RestClient client = new RestClient("https://v2.jokeapi.dev/joke/Any"); //Base url using as client
            RestRequest request = new RestRequest("submit", Method.Post);  //adding rest url as restrequest with Post method

            //Adding headers to the request
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Connection", "keep-alive");

            //Creating payload through class object
            string payload = Helper.CreateSubmitRequestPayload("This is a Joke");

            //Finally adding Payload as json body to request

            request.AddJsonBody(payload);

            //Executing the request i.e POST
            RestResponse response = client.Execute(request);

        }
    }
}
