using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class SearchResultPage : MainBasePage
    {
        private IList<IWebElement> listItems => WaitElements(By.XPath("//div[@class='pip-compact-price-package']"));

        private static readonly Dictionary<string, By> clickableElements = new Dictionary<string, By>()
        {
            {
                "ListItems", By.XPath("//div[@class='pip-compact-price-package']")
            }
        };

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetClickableElementLocator(string nameElement)
        {

            if (clickableElements.ContainsKey(nameElement))
            {
                return clickableElements[nameElement];
            }
            else if (ClickableElements.ContainsKey(nameElement))
            {
                return ClickableElements[nameElement];
            }

            throw new NotFoundException($"Unable to find locator by provided name {nameElement}");
        }

        public void ClikNElement(IWebDriver driver, string num)
        {
            var webElement = WaitElement(By.XPath("//div[@class='plp-fragment-wrapper']["+num+"]//div[contains(@class, 'bottom-wrapper')]//a"));
            new Actions(driver).MoveToElement(webElement).Perform();
            webElement.Click();
        }

        public void ClickOnSpecificElement(string num, string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            IList<IWebElement> webElements = WaitElements(locator);
            webElements[Int32.Parse(num) - 1].Click();
        }
    }
}
