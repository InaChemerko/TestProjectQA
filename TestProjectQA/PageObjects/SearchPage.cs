using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class SearchPage : MainBasePage
    {

        private static readonly Dictionary<string, By> clickableElements = new Dictionary<string, By>()
        {            
            
        };
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetClickableElementLocator(string nameElement)
        {
                      
            if (clickableElements.ContainsKey(nameElement))
            {
                return clickableElements[nameElement];
            } else if (ClickableElements.ContainsKey(nameElement)) 
            { 
                return ClickableElements[nameElement]; 
            }

            throw new NotFoundException($"Unable to find locator by provided name {nameElement}");
        }
        
    }
}
