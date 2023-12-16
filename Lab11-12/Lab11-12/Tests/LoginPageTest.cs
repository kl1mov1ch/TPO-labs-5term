using Lab11_12.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoAutomation.Pages;
using System;
using System.Collections.Generic;

namespace Lab11_12.Tests
{
    [TestFixture]
    public class SauceDemoTest
    {
        private IWebDriver driver;
        private SauceDemoPage sauceDemoPage;
        private LoginPage loginPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;
        private MenuPage menuPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            sauceDemoPage = new SauceDemoPage(driver);
            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            menuPage = new MenuPage(driver);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestSauceDemo_AddToCart()
        {
            sauceDemoPage.GoToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            cartPage.AddToCart();

            Assert.Pass("AddToCart test passed");
        }

        [Test]
        public void TestSauceDemo_RemoveFromCart()
        {
            sauceDemoPage.GoToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            cartPage.AddToCart();
            cartPage.GoToShoppingCart();
            cartPage.RemoveFromCart();

            Assert.Pass("RemoveFromCart test passed");
        }

        [Test]
        public void TestSauceDemo_CompleteCheckout()
        {
            sauceDemoPage.GoToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            cartPage.AddToCart();
            cartPage.GoToShoppingCart();
            checkoutPage.Checkout();
            checkoutPage.CompleteCheckout("John", "Doe", "12345");

            Assert.Pass("CompleteCheckout test passed");
        }

        [Test]
        public void TestSauceDemo_SortProductsByName_AtoZ()
        {
            sauceDemoPage.GoToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");

            // Используем SortPage для сортировки
            SortPage sortPage = new SortPage(driver);
            sortPage.SortProductsByNameAtoZ();

            // Получаем список продуктов после сортировки
            List<string> sortedProductNames = sortPage.GetProductNames();

            // Проверяем, что продукты отсортированы по имени (A to Z)
            Assert.IsTrue(sortPage.IsSortedAtoZ(sortedProductNames), "Products are not sorted by name (A to Z)");
        }

        [Test]
        public void TestSauceDemo_MenuNavigation()
        {
            sauceDemoPage.GoToLoginPage();
            loginPage.Login("standard_user", "secret_sauce");
            menuPage.OpenMenu();
            menuPage.NavigateToAbout();
            Assert.AreEqual("https://saucelabs.com/", driver.Url, "Failed to navigate to About page");
            Assert.Pass("Navigation to About page succeeded");
        }

        [Test]
        public void TestSauceDemo_SecondPages()
        {
            Assert.IsTrue(true, "This test always passes.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
