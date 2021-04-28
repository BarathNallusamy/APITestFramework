using System;
using Newtonsoft.Json.Linq;
using API_App;
using NUnit.Framework;
using System.Threading.Tasks;

namespace APITests
{
    public class WhenOutCodeIsCalledWithValidCode
    {
        LookOutwardCodeService _lookOutwardCodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _lookOutwardCodeService = new LookOutwardCodeService();
            await _lookOutwardCodeService.MakeRequestAsync("EC2Y");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_lookOutwardCodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void CorrectOutcodeIsReturned()
        {
            var result = _lookOutwardCodeService.ResponseContent["result"]["outcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_lookOutwardCodeService.ResponseObj.status, Is.EqualTo(200));
        }

        [Test]
        public void CountAdminWardInthisOutCode()
        {
            var result = _lookOutwardCodeService.ResponseObj.result.admin_ward.Length;
            Assert.That(result, Is.EqualTo(6));
        }
    }
}
