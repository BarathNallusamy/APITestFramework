using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class LookOutwardCodeDTO
    {
        public LookOutwardCode LookOutwardCode { get; set; }

        public void DeserializeResponse(string outcodeResponse)
        {
            LookOutwardCode = JsonConvert.DeserializeObject<LookOutwardCode>(outcodeResponse);
        }
    }
}