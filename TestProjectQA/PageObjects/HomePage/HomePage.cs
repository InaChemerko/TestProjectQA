using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class HomePage : BasePageObject
    {

        private IWebElement goShoppingLink => WaitElement(By.XPath("//section[contains(@class, 'hero')]//span[text()='Go shopping']"));
        private IWebElement acceptCookies => WaitElement(By.XPath("//button[text()='Accept all']"));

        private static readonly Dictionary<string, By> clickableElements = new Dictionary<string, By>()
        {
            {
                "GoShopping", By.XPath("//section[contains(@class, 'hero')]//span[text()='Go shopping']")
            },
            {
                "AcceptCookies", By.XPath("//button[text()='Accept all']")
            }
        };

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickGoShoppingLink()
        {
            goShoppingLink.Click();
        }

        protected override By GetClickableElementLocator(string nameElement)
        {
            if (clickableElements.ContainsKey(nameElement))
            {
                return clickableElements[nameElement];
            }
            throw new NotFoundException($"Unable to find locator by provided name {nameElement}");            
        }


    }
}
