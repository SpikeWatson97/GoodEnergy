using NUnit.Framework;
using Tests.POM.MeterReading;

namespace Tests.SubmitMeterReadingTests.ElectricityMeterReadings
{
    [Parallelizable]
    public class SubmitMeterReadingInvalidAccountNumber : TestBase
    {
        private readonly MeterReadingLandingPage _meterReadingLandingPage;
        private readonly AboutYouPage _aboutYouPage;
        private readonly SubmitElectricityReadingPage _submitElectricityReadingPage;

        public SubmitMeterReadingInvalidAccountNumber()
        {
            _meterReadingLandingPage = new MeterReadingLandingPage(_driver);
            _aboutYouPage = new AboutYouPage(_driver);
            _submitElectricityReadingPage = new SubmitElectricityReadingPage(_driver);
        }

        [Test(Description = "Tests to ensure meter reading cannot be submitted when validation message is displayed")]
        public void VerifyInvalidAccountNumberErrorMessage()
        {
            _meterReadingLandingPage.ClickMeterReadingTypeButtonAndClickNext("Electricity");
            _aboutYouPage.CompleteAboutYouForm("Jim", "fakeemail@outlook.com", "NR5 6RX");
            _aboutYouPage.NextButton.Click();
            _submitElectricityReadingPage.CompleteSubmitElectricityReadingForm(DateTime.Now.ToString("dd"), DateTime.Now.ToString("MMMM"),
                DateTime.Now.ToString("yyyy"), accountNumber: "1");
            _submitElectricityReadingPage.SubmitButton.Click();

            Assert.Multiple(() =>
            {
                Assert.True(_submitElectricityReadingPage.SubmitButton.Displayed);
                Assert.True(_driver.Url.Equals("https://www.goodenergy.co.uk/meter-reading/"));
                Assert.True(_submitElectricityReadingPage.ValidationMessageIsDisplayed(ValidationMessageConstants.InvalidAccountNumber));
            });
        }
    }
}