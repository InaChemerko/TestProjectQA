using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public abstract class MainBasePage : BasePage
    {

        private IWebElement searchField => WaitElement(By.XPath("//input[@name='q']"));

        public static readonly Dictionary<string, By> ClickableElements = new Dictionary<string, By>()
        {
            {
                "SearchField", By.XPath("//input[@name='q']")
            }
        };

        public MainBasePage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterTextInSearchField(string text)
        {
            searchField.Click();
            searchField.SendKeys(text);
        }
        
    }
}
