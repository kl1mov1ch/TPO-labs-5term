using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace Lab11_12.Pages
{
    public class SortPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public SortPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void SortProductsByNameAtoZ()
        {
            // Выбираем сортировку по имени (A to Z)
            SelectElement dropdown = new SelectElement(_wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_sort_container"))));
            dropdown.SelectByValue("az");
        }

        public List<string> GetProductNames()
        {
            // Получаем список имен продуктов
            IReadOnlyCollection<IWebElement> productElements = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("inventory_item_name")));
            List<string> productNames = new List<string>();

            foreach (IWebElement productElement in productElements)
            {
                productNames.Add(productElement.Text);
            }

            return productNames;
        }

        public bool IsSortedAtoZ(List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (string.Compare(list[i], list[i + 1], StringComparison.Ordinal) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
