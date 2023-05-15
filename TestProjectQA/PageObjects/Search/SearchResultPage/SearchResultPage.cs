using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class SearchResultPage : HeadersComponent
    {
        private static readonly Dictionary<string, By> clickableElements = new Dictionary<string, By>()
        {
            
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

        public void ClikNElement(IWebDriver driver, int number)
        {
            var webElements = WaitElements(By.XPath("//*[contains(@class, 'pip-product-compact')]/a"));

            if (webElements.Count < number)
            {
                throw new ArgumentException($"Elements with number {number} wasnt found. Founded only {webElements.Count} elements");
            }

            var element = webElements[number - 1];

            ScrollToElement(element);
            element.Click();
        }
    }
}
