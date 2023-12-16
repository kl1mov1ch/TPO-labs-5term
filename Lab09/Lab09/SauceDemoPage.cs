using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemoAutomation
{
    public class SauceDemoPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public SauceDemoPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void GoToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(2000); // Пауза в 2 секунды
        }

        public void Login(string username, string password)
        {
            IWebElement usernameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
            IWebElement passwordField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            IWebElement loginButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-button")));

            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(2000);
        }

        public void AddToCart()
        {
            IWebElement addToCartButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-sauce-labs-backpack")));
            addToCartButton.Click();
            Thread.Sleep(2000);
        }

        public void GoToShoppingCart()
        {
            IWebElement shoppingCartLink = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_link")));
            shoppingCartLink.Click();
            Thread.Sleep(2000);
        }

        public void RemoveFromCart()
        {
            IWebElement removeButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("remove-sauce-labs-backpack")));
            removeButton.Click();
            Thread.Sleep(2000);
        }

        public void Checkout()
        {
            IWebElement checkoutButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("checkout")));
            checkoutButton.Click();
            Thread.Sleep(2000);
        }

        public void CompleteCheckout(string firstName, string lastName, string zipCode)
        {
            IWebElement firstNameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("first-name")));
            IWebElement lastNameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("last-name")));
            IWebElement zipCodeField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("postal-code")));
            IWebElement continueButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("continue")));

            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            zipCodeField.SendKeys(zipCode);

            continueButton.Click();
            Thread.Sleep(2000); // Пауза в 2 секунды

            // Assume there is a summary page before finalizing the order
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("finish"))).Click();
            Thread.Sleep(2000); // Пауза в 2 секунды
        }

        public void Close()
        {
            _driver.Quit();
        }
    }
}
