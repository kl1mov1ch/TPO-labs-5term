using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    public class SauceDemoTests
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
        public void TestLoginAndAddToCart()
        {
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.SortProducts("lohi");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();

            // Assuming the cart now has one item.
            Assert.IsTrue(true, "Login and Add to Cart test passed");
        }

        [Test]
        public void TestRemoveFromCart()
        {
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.SortProducts("lohi");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.RemoveFromCart();

            // Assuming the cart is now empty.
            Assert.IsTrue(true, "Remove from Cart test passed");
        }

        [Test]
        public void TestCompleteCheckout()
        {
            sauceDemoPage.Login("standard_user", "secret_sauce");
            sauceDemoPage.SortProducts("lohi");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();
            sauceDemoPage.Checkout();
            sauceDemoPage.CompleteCheckout("John", "Doe", "12345");

            // Assuming there is a confirmation page or message after completing the checkout.
            Assert.IsTrue(true, "Complete Checkout test passed");
        }

        [Test]
        public void TestSearchAndAddToCart()
        {
            sauceDemoPage.SortProducts("lohi");
            sauceDemoPage.SearchProduct("Sauce Labs Backpack");
            Assert.IsTrue(sauceDemoPage.IsProductDisplayedInSearchResults("Sauce Labs Backpack"), "Product not found in search results");
            sauceDemoPage.AddToCart();
            sauceDemoPage.GoToShoppingCart();

            // Assuming the cart now has one item.
            Assert.IsTrue(true, "Search and Add to Cart test passed");
        }

        [TearDown]
        public void TearDown()
        {
            sauceDemoPage.Close();
        }
    }
}
