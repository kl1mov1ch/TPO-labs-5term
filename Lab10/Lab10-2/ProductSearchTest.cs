using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

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
            Thread.Sleep(2000);
        }

        public void Login(string username, string password)
        {
            IWebElement usernameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
            usernameField.SendKeys(username);
            Thread.Sleep(2000);

            IWebElement passwordField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            passwordField.SendKeys(password);
            Thread.Sleep(2000);

            IWebElement loginButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            loginButton.Click();
            Thread.Sleep(2000);
        }


        public void SortProducts(string sortByValue)
        {
            IWebElement sortDropdown = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_sort_container")));
            SelectElement select = new SelectElement(sortDropdown);
            select.SelectByValue(sortByValue);
            Thread.Sleep(2000);
        }


        public bool IsProductDisplayedInSearchResults(string productName)
        {
            IWebElement searchResults = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("inventory_item_name")));
            return searchResults.Text.Contains(productName);
        }

        public void AddToCart()
        {
            IWebElement addToCartButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_inventory")));
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
            IWebElement removeButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_secondary")));
            removeButton.Click();
            Thread.Sleep(2000);
        }

        public void Checkout()
        {
            IWebElement checkoutButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_action")));
            checkoutButton.Click();
            Thread.Sleep(2000);
        }

        public void CompleteCheckout(string firstName, string lastName, string zipCode)
        {
            IWebElement firstNameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("first-name")));
            firstNameField.SendKeys(firstName);
            Thread.Sleep(2000);

            IWebElement lastNameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("last-name")));
            lastNameField.SendKeys(lastName);
            Thread.Sleep(2000);

            IWebElement zipCodeField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("postal-code")));
            zipCodeField.SendKeys(zipCode);
            Thread.Sleep(2000);

            IWebElement continueButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_primary")));
            continueButton.Click();

            // Assume there is a summary page before finalizing the order
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn_action"))).Click();
        }

        public void Close()
        {
            _driver.Quit();
        }
    }
}
