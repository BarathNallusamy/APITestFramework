using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class SinglePostCodeDTO
    {
        public SinglePostCodeResponse SinglePostCodeResponse { get; set; }

        public  void DeserializeResponse(string postcodeResponse)
        {
            SinglePostCodeResponse = JsonConvert.DeserializeObject<SinglePostCodeResponse>(postcodeResponse);
        }
    }
}
