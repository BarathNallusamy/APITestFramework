using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace API_App
{
    public class LookOutwardCodeService
    {
        #region Properties
        //REstsharp object which handles communication with API
        public RestClient Client;
        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent { get; set; }
        //Restsharp response Object
        public IRestResponse RestResponse { get; set; }
        //An object model of the response
        public LookOutwardCode ResponseObj { get; set; }
        //The postcode used in the API request
        public string PostcodeSelected { get; set; }
        #endregion

        public LookOutwardCodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequestAsync(string outcode)
        {
            //setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = outcode;

            //define request resource path,(changing to lowercase and removing the spaces)
            request.Resource = $"outcodes/{outcode.ToLower()}";

            //make the request
            RestResponse = await Client.ExecuteAsync(request);

            //parse json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);

            //parse response body into an object tree
            ResponseObj = JsonConvert.DeserializeObject<LookOutwardCode>(RestResponse.Content);
        }
    }
}
