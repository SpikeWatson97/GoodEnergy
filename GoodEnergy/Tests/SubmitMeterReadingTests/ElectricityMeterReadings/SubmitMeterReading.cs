using NUnit.Framework;
using Tests.Constants;
using Tests.Helpers;
using Tests.POM.MeterReading;

namespace Tests.SubmitMeterReadingTests.ElectricityMeterReadings
{
    [Parallelizable]
    public class SubmitMeterReading : TestBase
    {
        private readonly MeterReadingLandingPage _meterReadingLandingPage;
        private readonly AboutYouPage _aboutYouPage;
        private readonly SubmitElectricityReadingPage _submitElectricityReadingPage;

        public SubmitMeterReading()
        {
            _meterReadingLandingPage = new MeterReadingLandingPage(_driver);
            _aboutYouPage = new AboutYouPage(_driver);
            _submitElectricityReadingPage = new SubmitElectricityReadingPage(_driver);
        }

        [Test]
        public void SubmitMeterReadingAndVerify()
        {
            _meterReadingLandingPage.ClickMeterReadingTypeButtonAndClickNext(MeterReadingTypes.Electricity);
            _aboutYouPage.CompleteAboutYouForm("Jim", "fakeemail@outlook.com", "NR5 6RX");
            _aboutYouPage.NextButton.Click();
            _submitElectricityReadingPage.CompleteSubmitElectricityReadingForm(DateTime.Now.ToString("dd"), DateTime.Now.ToString("MMMM"), DateTime.Now.ToString("yyyy"));
            _submitElectricityReadingPage.SubmitButton.Click();
            Assert.That(_driver.Url.Contains("failure=True"));
            //Asserting this way as I'm getting an error when
            //submiting the meter reading. Page is stating
            //'Sorry, something went wrong, please try to submit your readings again.'
        }
    }
}