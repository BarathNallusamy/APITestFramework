using System;
using System.Threading.Tasks;
using RestSharp;

namespace API_App.PostcodesIOService
{
    public class CallManager
    {
        //Restsharp object which hanled communication witht he API
        readonly IRestClient _client;

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }


        //
        // Summary:
        //     Sets the BaseUrl property for requests made by this client instance
        //
        // Parameters:
        //   baseUrl:
        //defines and makes the API request, and stored the response
        public async Task<string> MakeSinglePostcodeRequest(string postcode)
        {
            //setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            //define request resource path,(changing to lowercase and removing the spaces)
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            //make the request
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> MakeSingleOuttcodeRequest(string postcode)
        {
            //setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");

            //define request resource path,(changing to lowercase and removing the spaces)
            request.Resource = $"outcodes/{postcode.ToLower()}";

            //make the request
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
