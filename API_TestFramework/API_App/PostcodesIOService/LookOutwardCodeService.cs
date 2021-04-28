using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace API_App.PostcodesIOService
{
    public class LookOutwardCodeService
    {
        #region Properties

        public CallManager CallManager { get; }

        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent { get; set; }

        //An object model of the response
        public LookOutwardCodeDTO LookOutwardCodeDTO { get; set; }

        //The postcode used in the API request
        public string outcodeSelected { get; set; }

        //the response content as a string
        public string outcodeResponse { get; set; }
        #endregion

        public LookOutwardCodeService()
        {
            CallManager = new CallManager();
            LookOutwardCodeDTO = new LookOutwardCodeDTO();
        }

        public async Task MakeRequestAsync(string outcode)
        {
            outcodeSelected = outcode;
            //make the request
            outcodeResponse = await CallManager.MakeSingleOutcodeRequest(outcode);

            //parse json into a JObject
            ResponseContent = JObject.Parse(outcodeResponse);

            //parse response body into an object tree
            LookOutwardCodeDTO.DeserializeResponse(outcodeResponse);
        }
    }
}
