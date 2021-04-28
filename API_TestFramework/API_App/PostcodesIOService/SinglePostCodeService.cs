using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace API_App.PostcodesIOService
{
    public class SinglePostCodeService
    {
        #region Properties
        public CallManager CallManager { get; }

        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent{ get; set; }
       
        //An object model of the response
        public SinglePostCodeDTO SinglePostcodeDTO { get; set; }
        
        //The postcode used in the API request
        public string PostcodeSelected { get; set; }

        //the response content as a string
        public string PostcodeResponse { get; set; }
        #endregion

        //constructor - creates the rest client object
        public SinglePostCodeService()
        {
            CallManager = new CallManager();
            SinglePostcodeDTO = new SinglePostCodeDTO();
        }

        public async Task MakeRequestAsync(string postcode)
        {
            PostcodeSelected = postcode;
            //make the request
            PostcodeResponse = await CallManager.MakeSinglePostcodeRequest(postcode);

            //parse json into a JObject
            ResponseContent = JObject.Parse(PostcodeResponse);

            //parse response body into an object tree
            SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
        }
    }
}