using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab11_12.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
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
