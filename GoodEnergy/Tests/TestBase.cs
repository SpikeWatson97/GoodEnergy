using Configuration.WebdriverCreation;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestParameters = Configuration.TestRunParameters.TestParameters;

namespace Tests
{
    public class TestBase
    {
        protected readonly IWebDriver _driver;

        /// <summary>
        /// Every time class is derived a fresh webdriver instance is created
        /// </summary>
        public TestBase()
        {
            _driver = WebdriverFactory.CreateWebDriver();
        }

        /// <summary>
        /// Before each test you are directed to the url specified in the .runsettings file
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            _driver.Navigate().GoToUrl(TestParameters.URL);
        }

        /// <summary>
        /// After every test a screenshot is taken(if testfailed) and the driver is closed
        /// </summary>
        [TearDown]
        protected void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                WebdriverFactory.TakeScreenshot(_driver);
            }
            _driver.Quit();
        }
    }
}