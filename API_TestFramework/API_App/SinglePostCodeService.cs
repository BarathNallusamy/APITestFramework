using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace API_App
{
    public class SinglePostCodeService
    {
        #region Properties
        //REstsharp object which handles communication with API
        public RestClient Client;
        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent{ get; set; }
        //Restsharp response Object
        public IRestResponse RestResponse { get; set; }
        //The postcode used in the API request
        public string PostcodeSelected { get; set; }
        #endregion

        //constructor - creates the rest client object
        public SinglePostCodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public void MakeRequest(string postcode)
        {
            //setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;

            //define request resource path,(changing to lowercase and removing the spaces)
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            //make the request
            RestResponse = Client.Execute(request);

            //parse json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);
        }
    }
}