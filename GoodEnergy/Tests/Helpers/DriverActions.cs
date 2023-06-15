using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Tests.Helpers
{
    public class DriverActions
    {
        public IWebDriver _driver;
        private readonly WaitFor _waitFor;

        public DriverActions(IWebDriver driver)
        {
            _driver = driver;
            _waitFor = new WaitFor(_driver);
        }

        /// <summary>
        /// Use this to scroll to out of view elements, wait until they are in view and then click.
        /// </summary>
        public void ScrollToWebElementAndClick(IWebElement element)
        {
            Actions actions = new(_driver);
            actions.MoveToElement(element).Perform();
            _waitFor.ElementToBeClickable(element);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)_driver;
            ex.ExecuteScript("arguments[0].click();", element);
        }
    }
}