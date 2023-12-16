using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class SauceDemoTest
    {
        private SauceDemoPage sauceDemoPage;

        [SetUp]
        public void Setup()
        {
            var driver = new ChromeDriver();
            sauceDemoPage = new SauceDemoPage(driver);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestAddAndRemoveFromCart()
        {
            sauceDemoPage.GoToLoginPage();
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.RemoveFromCart();
            Assert.Pass("Add and Remove from Cart test passed");
        }

        [Test]
        public void TestCompleteCheckout()
        {
            sauceDemoPage.GoToLoginPage();
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.Checkout();
            sauceDemoPage.CompleteCheckout("John", "Doe", "12345");
            Assert.Pass("Complete Checkout test passed");
        }

        [TearDown]
        public void TearDown()
        {
            sauceDemoPage.Close();
        }
    }
}
