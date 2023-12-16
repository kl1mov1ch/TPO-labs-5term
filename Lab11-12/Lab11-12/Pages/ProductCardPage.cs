using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab11_12.Pages
{
    public class ProductCardPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public ProductCardPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void AddToCart()
        {
            By addToCartButtonLocator = By.Id("add-to-cart-sauce-labs-backpack");
            IWebElement addToCartButton = _wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButtonLocator));
            addToCartButton.Click();
            WaitUntilProductAddedToCart();
        }

        private void WaitUntilProductAddedToCart()
        {
            By cartBadgeLocator = By.ClassName("shopping_cart_badge");
            _wait.Until(ExpectedConditions.ElementIsVisible(cartBadgeLocator));
        }
    }
}
