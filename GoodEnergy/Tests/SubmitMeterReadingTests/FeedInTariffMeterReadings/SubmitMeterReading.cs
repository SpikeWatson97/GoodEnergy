using NUnit.Framework;
using Tests.Constants;
using Tests.POM.MeterReading;
using Tests.POM.MeterReading.Results;

namespace Tests.SubmitMeterReadingTests.FeedInTariffMeterReadings
{
    [Parallelizable]
    public class SubmitMeterReading : TestBase
    {
        private readonly MeterReadingLandingPage _meterReadingLandingPage;
        private readonly AboutYouPage _aboutYouPage;
        private readonly SubmitTariffReadingPage _submitTariffReadingPage;
        private readonly ResultsPage _resultsPage;

        public SubmitMeterReading()
        {
            _meterReadingLandingPage = new(_driver);
            _aboutYouPage = new(_driver);
            _submitTariffReadingPage = new(_driver);
            _resultsPage = new(_driver);
        }

        [Test]
        public void SubmitMeterReadingAndVerify()
        {
            _meterReadingLandingPage.ClickMeterReadingTypeButtonAndClickNext(MeterReadingTypes.FeedInTariff);
            _aboutYouPage.CompleteAboutYouForm("Jim", "fakeemail@outlook.com", "NR5 6RX");
            _aboutYouPage.NextButton.Click();
            _submitTariffReadingPage.CompleteSubmitReadingForm(DateTime.Now.ToString("dd"), DateTime.Now.ToString("MMMM"),
                DateTime.Now.ToString("yyyy"));
            _submitTariffReadingPage.UploadImageAsEvidence("Screenshot (1).png");
            _submitTariffReadingPage.SubmitButon.Click();

            Assert.Multiple(() =>
            {
                Assert.True(_resultsPage.MeterReadSubmittedSuccessMessage.Displayed);
                Assert.True(_driver.Url.Contains("failure=False"));
            });
        }
    }
}