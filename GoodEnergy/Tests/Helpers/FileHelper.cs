using OpenQA.Selenium;
using System.Reflection;

namespace Tests.Helpers
{
    public static class FileHelper
    {
        public static void UploadAFile(IWebElement pagemodelAndUploadFileWebElement, string filename)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathWithFile = Path.Combine(path, filename);
            pagemodelAndUploadFileWebElement.SendKeys(pathWithFile);
        }
    }
}