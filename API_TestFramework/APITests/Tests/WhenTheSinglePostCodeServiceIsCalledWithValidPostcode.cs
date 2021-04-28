using System;
using Newtonsoft.Json.Linq;
using API_App;
using NUnit.Framework;
using System.Threading.Tasks;
using API_App.PostcodesIOService;

namespace APITests.Tests
{
    public class WhenTheSinglePostCodeServiceIsCalledWithValidPostcode
    {
        SinglePostCodeService _singlePostCodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singlePostCodeService = new SinglePostCodeService();
            await _singlePostCodeService.MakeRequestAsync("EC2Y 5AS");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostCodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void CorrectPostcodeIsReturned()
        {
            var result = _singlePostCodeService.ResponseContent["result"]["postcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y 5AS"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singlePostCodeService.SinglePostcodeDTO.SinglePostCodeResponse.status, Is.EqualTo(200));
        }

        [Test]
        public void ObjectStatusIsCityOfLondon()
        {
            Assert.That(_singlePostCodeService.SinglePostcodeDTO.SinglePostCodeResponse.result.admin_district, Is.EqualTo("City of London"));
        }

        //Make new service object and classes derived from Json
    }
}
