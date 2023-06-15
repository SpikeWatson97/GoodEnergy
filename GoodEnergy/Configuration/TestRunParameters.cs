using NUnit.Framework;

namespace Configuration.TestRunParameters
{
    public static class TestParameters
    {
        /// <summary>
        /// Browser parameter for web tests
        /// </summary>
        public static string? Browser = TestContext.Parameters["Browser"];

        /// <summary>
        /// URL parameter for webtests
        /// </summary>
        public static string? URL = TestContext.Parameters["URL"];
    }
}