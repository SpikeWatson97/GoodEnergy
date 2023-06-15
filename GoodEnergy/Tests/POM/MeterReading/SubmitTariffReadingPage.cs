using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Helpers;
using System.Threading.Tasks;

namespace Tests.POM.MeterReading
{
    public class SubmitTariffReadingPage
    {
        private readonly IWebDriver _driver;

        public SubmitTariffReadingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GeneratorAccountNumberInput => _driver.FindElement(By.Id("FitAccountNumber"));
        public IWebElement MeterSerialNumberInput => _driver.FindElement(By.Id("FitMeterSerialNumber"));
        public IWebElement MeterReadingInput => _driver.FindElement(By.Id("FitMeterReadingValue"));
        public IWebElement SubmitButon => _driver.FindElement(By.CssSelector(".btn--submit"));
        public IWebElement UploadButton => _driver.FindElement(By.Id("ImageUpload"));
        public SelectElement DateOfReadingDayDropdown => new SelectElement(_driver.FindElement(By.Id("FitDateOfReading_Value_Day")));
        public SelectElement DateOfReadingMonthDropdown => new SelectElement(_driver.FindElement(By.Id("FitDateOfReading_Value_Month")));
        public SelectElement DateOfReadingYearDropdown => new SelectElement(_driver.FindElement(By.Id("FitDateOfReading_Value_Year")));

        public void CompleteSubmitReadingForm(string dateOfReadingDay, string dateOfReadingMonth, string dateOfReadingYear,
            string generatorAccountNumber = "12345", string meterSerialNumber = "3346", string meterReading = "24456")
        {
            GeneratorAccountNumberInput.SendKeys(generatorAccountNumber);
            MeterSerialNumberInput.SendKeys(meterSerialNumber);
            DateOfReadingDayDropdown.SelectByText(dateOfReadingDay);
            DateOfReadingMonthDropdown.SelectByText(dateOfReadingMonth);
            DateOfReadingYearDropdown.SelectByText(dateOfReadingYear);
            MeterReadingInput.SendKeys(meterReading);
        }

        public void UploadImageAsEvidence(string fileName)
        {
            FileHelper.UploadAFile(UploadButton, fileName);
        }
    }
}