using System;
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
            Wait(2000);
        }

        public void Login(string username, string password)
        {
            EnterText(By.Id("user-name"), username);
            Thread.Sleep(1000);
            EnterText(By.Id("password"), password);
            Thread.Sleep(1000);
            ClickElement(By.Id("login-button"));
            Thread.Sleep(1000);
            Wait(2000);
        }

        public void AddToCart()
        {
            ClickElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Wait(2000);
        }

        public void GoToShoppingCart()
        {
            ClickElement(By.ClassName("shopping_cart_link"));
            Wait(2000);
        }

        public void RemoveFromCart()
        {
            ClickElement(By.Id("remove-sauce-labs-backpack"));
            Wait(2000);
        }

        public void Checkout()
        {
            ClickElement(By.Id("checkout"));
            Wait(2000);
        }

        public void CompleteCheckout(string firstName, string lastName, string zipCode)
        {
            EnterText(By.Id("first-name"), firstName);
            Thread.Sleep(1000);
            EnterText(By.Id("last-name"), lastName);
            Thread.Sleep(1000);
            EnterText(By.Id("postal-code"), zipCode);
            Thread.Sleep(1000);
            ClickElement(By.Id("continue"));
            Thread.Sleep(1000);
            ClickElement(By.Id("finish"));
            Wait(2000);
        }

        public void Close()
        {
            Thread.Sleep(1000);
            _driver.Quit();
        }

        private void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        private void EnterText(By locator, string text)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.SendKeys(text);
        }

        private void ClickElement(By locator)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Click();
        }
    }
}
