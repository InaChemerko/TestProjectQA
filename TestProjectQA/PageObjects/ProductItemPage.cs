using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class ProductItemPage : MainBasePage
    {
        private IWebElement addToBag => WaitElement(By.XPath("//span[text()='Add to bag']"));
        private IWebElement closeButton => WaitElement(By.XPath("//button[@aria-label='Close']"));
        private IWebElement confirmWindow => WaitElement(By.XPath("//div[contains(@class, 'rec-sheets')]/div[contains(@class, 'rec-sheets')]"));
        private IWebElement navigation => WaitElement(By.XPath("//nav[@aria-label='Breadcrumb']"));

        private static readonly Dictionary<string, By> clickableElements = new Dictionary<string, By>()
        { 
            {
                "AddToBag", By.XPath("//span[text()='Add to bag']")
            },
            {
                "CloseButton", By.XPath("//button[@aria-label='Close']")
            },
            {
                "ConfirmWindow", By.XPath("//div[contains(@class, 'rec-sheets')]/div[contains(@class, 'rec-sheets')]")
            },
            {
                "Navigation", By.XPath("//nav[@aria-label='Breadcrumb']")
            }
        }; 
        
        public ProductItemPage(IWebDriver driver) : base(driver)
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

    }
}
