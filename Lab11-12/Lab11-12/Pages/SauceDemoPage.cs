using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab11_12.Pages
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

        public void Close()
        {
            Thread.Sleep(1000);
            _driver.Quit();
        }

        private void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
