using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Reflection;
using TestParameters = Configuration.TestRunParameters.TestParameters;

namespace Configuration.WebdriverCreation
{
    public static class WebdriverFactory
    {
        private const string _windowSize = "window-size=1920,1080";
        private const string _windowBehaviour = "--kiosk";
        private const string _headlessBrowser = "--headless";

        private static readonly string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver CreateWebDriver()
        {
            return TestParameters.Browser.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "headlesschrome" => CreateHeadlessChromeDriver(),
                "edge" => CreateEdgeDriver(),
                "headlessedge" => CreateHeadlessEdgeDriver(),
                _ => CreateHeadlessChromeDriver(),
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new()
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };

            options.SetLoggingPreference(LogType.Driver, LogLevel.Debug);
            options.AddArguments(_windowBehaviour, _windowSize);
            var driver = new ChromeDriver(_path, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static IWebDriver CreateHeadlessChromeDriver()
        {
            var downloadPath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

            ChromeOptions options = new()
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };
            options.SetLoggingPreference(LogType.Driver, LogLevel.Debug);
            options.AddArguments(_windowBehaviour, _windowSize, _headlessBrowser, "--incognito");
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            var driver = new ChromeDriver(_path, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static IWebDriver CreateEdgeDriver()
        {
            EdgeOptions options = new()
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };
            options.AddArguments(_windowBehaviour, _windowSize);
            var driver = new EdgeDriver(_path, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        private static IWebDriver CreateHeadlessEdgeDriver()
        {
            var downloadPath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

            EdgeOptions options = new()
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };

            options.AddArguments(_windowBehaviour, _windowSize, _headlessBrowser, "incognito");
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);

            var driver = new EdgeDriver(_path, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public static void TakeScreenshot(IWebDriver driver)
        {
            if (driver is ITakesScreenshot takesScreenshot)
            {
                string screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.png";
                var directory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string screenshotFilePath = Path.Combine(directory, screenshotFileName);
                var screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath);

                TestContext.AddTestAttachment(screenshotFilePath);
                Console.WriteLine(screenshotFileName, new Uri(screenshotFilePath));
            }
        }
    }
}