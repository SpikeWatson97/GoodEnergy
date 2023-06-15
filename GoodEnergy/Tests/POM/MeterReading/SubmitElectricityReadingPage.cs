using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.POM.MeterReading
{
    public class SubmitElectricityReadingPage
    {
        private readonly IWebDriver _driver;

        public SubmitElectricityReadingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AccountNumberInput => _driver.FindElement(By.Id("ElecAccountNumber"));
        public IWebElement MeterSerialNumberInput => _driver.FindElement(By.Id("ElecMeterSerialNumber"));
        public IWebElement MeterReadingInput => _driver.FindElement(By.Id("ElecMeterReadingValue"));
        public IWebElement SubmitButton => _driver.FindElement(By.CssSelector(".btn--submit"));
        public IReadOnlyCollection<IWebElement> ValidationMessage => _driver.FindElements(By.CssSelector(".field-validation-error"));
        public SelectElement DateOfReadingDayDropdown => new(_driver.FindElement(By.Id("ElecDateOfReading_Value_Day")));
        public SelectElement DateOfReadingMonthDropdown => new(_driver.FindElement(By.Id("ElecDateOfReading_Value_Month")));
        public SelectElement DateOfReadingYearDropdown => new(_driver.FindElement(By.Id("ElecDateOfReading_Value_Year")));

        public void CompleteSubmitElectricityReadingForm(string dateOfReadingDay, string dateOfReadingMonth, string dateOfReadingYear,
            string accountNumber = "11879997", string meterSerialNumber = "123456789123456", string meterReading = "12345678")
        {
            AccountNumberInput.SendKeys(accountNumber);
            MeterSerialNumberInput.SendKeys(meterSerialNumber);
            DateOfReadingDayDropdown.SelectByText(dateOfReadingDay);
            DateOfReadingMonthDropdown.SelectByText(dateOfReadingMonth);
            DateOfReadingYearDropdown.SelectByText(dateOfReadingYear);
            MeterReadingInput.SendKeys(meterReading);
        }

        public bool ValidationMessageIsDisplayed(string validationMessage)
        {
            return ValidationMessage.Single(vm => vm.GetAttribute("innerText").Equals(validationMessage)).Displayed;
        }
    }
}