using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.POM.MeterReading;

namespace Tests.SubmitMeterReadingTests.FeedInTariffMeterReadings
{
    public class SubmitMeterReading : TestBase
    {
        private readonly MeterReadingLandingPage _meterReadingLandingPage;
        private readonly AboutYouPage _aboutYouPage;

        public SubmitMeterReading()
        {
            _meterReadingLandingPage = new(_driver);
            _aboutYouPage = new(_driver);
        }

        [Test]
        public void SubmitMeterReadingAndVerify()
        {
        }
    }
}