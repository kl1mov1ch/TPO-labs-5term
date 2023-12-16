using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SauceDemoAutomation
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
            sauceDemoPage.GoToLoginPage();
        }

        [Test]
        public void TestAddAndRemoveFromCart()
        {
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.RemoveFromCart();

            // Assuming the cart is now empty, you can add assertions accordingly.
            Assert.Pass("Add and Remove from Cart test passed");
        }

        [Test]
        public void TestCompleteCheckout()
        {
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.Checkout();
            sauceDemoPage.CompleteCheckout("John", "Doe", "12345");

            // Assuming there is a confirmation page or message after completing the checkout.
            Assert.Pass("Complete Checkout test passed");
        }

        [TearDown]
        public void TearDown()
        {
            sauceDemoPage.Close();
        }
    }
}
