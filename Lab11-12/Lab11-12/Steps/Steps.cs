using NUnit.Framework;
using OpenQA.Selenium;

namespace Lab11_12.Steps
{
    [TestFixture]
    public class Steps
    {
        protected IWebDriver driver;

        [SetUp]
        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }
    }
}
