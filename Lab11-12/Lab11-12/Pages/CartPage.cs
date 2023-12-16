using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SauceDemoAutomation.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
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

        private void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        private void ClickElement(By locator)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Click();
        }
    }
}
