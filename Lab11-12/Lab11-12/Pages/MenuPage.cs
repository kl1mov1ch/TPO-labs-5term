using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab11_12.Pages
{
    public class MenuPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public MenuPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void OpenMenu()
        {
            IWebElement menuButton = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("react-burger-menu-btn")));
            menuButton.Click();
            Wait(1000);
        }

        public void NavigateToAbout()
        {
            IWebElement aboutLink = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("about_sidebar_link")));
            aboutLink.Click();
            Wait(1000);
        }

        public bool IsAboutPageOpened()
        {
            // Проверяем, что находимся на странице "About"
            return _driver.Url.Contains("https://saucelabs.com/about");
        }

        private void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
