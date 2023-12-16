using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab11_12.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        }

        public void GoToPage()
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
            Wait(1000);
        }

        public bool IsLoginSuccessful()
        {
            try
            {
                IWebElement productsLabel = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_label")));
                return productsLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        public void EnterText(By locator, string text)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.SendKeys(text);
        }

        public void ClickElement(By locator)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Click();
        }

        public void Close()
        {
            _driver.Quit();
        }
    }
}
