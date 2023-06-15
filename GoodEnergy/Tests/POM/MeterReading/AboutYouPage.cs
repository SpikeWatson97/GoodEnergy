using OpenQA.Selenium;

namespace Tests.POM.MeterReading
{
    public class AboutYouPage
    {
        private readonly IWebDriver _driver;

        public AboutYouPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement NameInput => _driver.FindElement(By.Id("Name"));
        public IWebElement EmailInput => _driver.FindElement(By.Id("Email"));
        public IWebElement PostcodeInput => _driver.FindElement(By.Id("Postcode"));
        public IWebElement NextButton => _driver.FindElement(By.XPath("//button[text()='Next']"));

        public void CompleteAboutYouForm(string name, string email, string postcode)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            PostcodeInput.SendKeys(postcode);
        }
    }
}