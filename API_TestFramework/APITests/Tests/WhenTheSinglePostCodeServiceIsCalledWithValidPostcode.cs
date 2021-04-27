using System;
using Newtonsoft.Json.Linq;
using API_App;
using NUnit.Framework;

namespace APITests.Tests
{
    public class WhenTheSinglePostCodeServiceIsCalledWithValidPostcode
    {
        SinglePostCodeService _singlePostCodeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _singlePostCodeService = new SinglePostCodeService();
            _singlePostCodeService.MakeRequest("EC2Y 5AS");
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
    }
}
