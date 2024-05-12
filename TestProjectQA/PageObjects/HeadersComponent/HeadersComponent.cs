using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public abstract class HeadersComponent : BasePageObject
    {

        private IWebElement searchField => WaitElement(By.XPath("//input[@name='q']"));
        private IWebElement searchButton => WaitElement(By.XPath("//button[@type='submit']"));
        private IWebElement okCookiesButton => WaitElement(By.XPath("//button[text()='Ok']"));
        private IWebElement shoppingCartButton => WaitElement(By.XPath("//div/ul/li[5]/a/span"));

        public static readonly Dictionary<string, By> ClickableElements = new Dictionary<string, By>()
        {
            {
                "SearchField", By.XPath("//input[@name='q']")
            },
            {
                "SearchButton", By.XPath("//button[@type='submit']")
            },
            {
                "OkCookies", By.XPath("//button[text()='Ok']")
            },
            {
                "shoppingCartButton", By.XPath("//div/ul/li[5]/a/span")
            }
        };

        public HeadersComponent(IWebDriver driver) : base(driver)
        {
        }

        public void EnterTextInSearchField(string text)
        {
            searchField.Click();
            searchField.SendKeys(text);
        }

        
        
    }
}
