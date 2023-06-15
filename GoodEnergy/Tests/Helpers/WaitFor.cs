using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Tests.Helpers
{
    public class WaitFor
    {
        private const int StandardTimeToWaitSeconds = 30;
        public IWebDriver _driver;
        public WebDriverWait Wait;

        public WaitFor(IWebDriver driver)
        {
            _driver = driver;
            Wait = new WebDriverWait(_driver, new TimeSpan(0, 0, StandardTimeToWaitSeconds));
        }

        public void ElementToBeClickable(IWebElement pagemodelandelement)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(pagemodelandelement));
        }
    }
}