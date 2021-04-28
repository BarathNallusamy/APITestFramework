using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using API_App.PostcodesIOService;

namespace API_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("https://api.postcodes.io/");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            var postcode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";


            //sending request to retreive the data
            var restResponse = restClient.Execute(restRequest);
            Console.WriteLine("Response content (string):");
            Console.WriteLine(restResponse.Content);

            //convert the response to json object
            var jsonResponse = JObject.Parse(restResponse.Content);
            Console.WriteLine("\nResponse content as a JObject");
            Console.WriteLine(jsonResponse);

            var adminDistrict = jsonResponse["result"]["admin_district"];
            Console.WriteLine($"Admin district: {adminDistrict}");

            var parish = jsonResponse["result"]["parish"];
            Console.WriteLine($"Parish ward: {parish}");


            var singlePostCodeResponse = JsonConvert.DeserializeObject<SinglePostCodeResponse>(restResponse.Content);




            ////copied from POSTMAN APP
            //var client = new RestClient("https://api.postcodes.io/postcodes/EC2Y5AS");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Cookie", "__cfduid=d5a97c4134f7517f2b95a3f39d303548c1619433749");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine("\nResponse generated from POSTMAN");
            //Console.WriteLine(response.Content);


            //Posting from postman
            var client = new RestClient("https://api.postcodes.io/postcodes/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "__cfduid=d5a97c4134f7517f2b95a3f39d303548c1619433749");
            request.AddParameter("application/json", "{\r\n  \"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine("\n\n Generate from the POST call code");
            Console.WriteLine(response.Content);

            var jsonResponseCollection = JObject.Parse(response.Content);
            Console.WriteLine("\nResponse content as a JObject");
            Console.WriteLine(jsonResponseCollection);

            var adminDistrict2 = jsonResponseCollection["result"][1]["result"]["admin_district"];
            Console.WriteLine($"Admin district from raw JSON: {adminDistrict2}");



            var bulkPostcodeResponse = JsonConvert.DeserializeObject<BulkPostCodeResponse>(response.Content);

            var adminDistrictObj = bulkPostcodeResponse.result[1].result.admin_district;
            Console.WriteLine($"Admin district from Object: {adminDistrictObj}");
        }
    }
}
