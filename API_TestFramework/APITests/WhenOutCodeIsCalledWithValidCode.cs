using API_App.PostcodesIOService;
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
            Assert.That(_lookOutwardCodeService.LookOutwardCodeDTO.LookOutwardCode.status, Is.EqualTo(200));
        }

        [Test]
        public void CountAdminWardInthisOutCode()
        {
            var result = _lookOutwardCodeService.LookOutwardCodeDTO.LookOutwardCode.result.admin_ward.Length;
            Assert.That(result, Is.EqualTo(6));
        }
    }
}
