using OpenQA.Selenium;

namespace Tests.POM.MeterReading.Results
{
    public class ResultsPage
    {
        private readonly IWebDriver _driver;

        public ResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement MeterReadSubmittedSuccessMessage => _driver.FindElement(By.XPath("//*[contains(text(), 'Meter read submitted')]"));
    }
}