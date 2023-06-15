using OpenQA.Selenium;
using Tests.Helpers;

namespace Tests.POM.MeterReading
{
    public class MeterReadingLandingPage
    {
        private readonly IWebDriver _driver;
        private readonly DriverActions _driverActions;

        public MeterReadingLandingPage(IWebDriver driver)
        {
            _driver = driver;
            _driverActions = new DriverActions(_driver);
        }

        public IWebElement MeterReadingTypeButton(string buttonText) => _driver.FindElement(By.XPath($"//label[contains(text(), '{buttonText}')]"));

        public IWebElement NextButton => _driver.FindElement(By.XPath("//button[text()='Next']"));

        public void ClickMeterReadingTypeButtonAndClickNext(string buttonText)
        {
            MeterReadingTypeButton(buttonText).Click();
            _driverActions.ScrollToWebElementAndClick(NextButton);
        }
    }
}