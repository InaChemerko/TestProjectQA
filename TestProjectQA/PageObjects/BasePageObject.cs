using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public abstract class BasePageObject : WebLoadableComponent
    {
        private IWebDriver driver;
        private const int ScrollWait = 500;
        
        public BasePageObject(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ClickElement(string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            ScrollToElement(webElement);
            webElement.Click();
        }

        public void EnterTextInElement(string nameElement, string text)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            webElement.Click();
            webElement.Clear();
            webElement.SendKeys(text);
        }

        protected virtual By GetClickableElementLocator(string nameElement)
        {
            throw new NotImplementedException();
        }

        public void ScrollToElement(IWebElement name, bool isSmooth = false)
        {
            try
            {
                var behavior = isSmooth == true ? "smooth" : "auto";

                ((IJavaScriptExecutor)driver).ExecuteScript(
                    $"arguments[0].scrollIntoView({{behavior: '{behavior}', block: 'center', inline: 'center'}});",
                    name);

                Thread.Sleep(ScrollWait);
            }
            catch (Exception ex)
            {
                throw new WebDriverException($"Cannot scroll to element with text \"{name?.Text}\" and tag \"{name?.TagName}\"", ex);
            }
        }

        public void ScrollToTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,0)");
        }

        public void MoveToElement(string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            new Actions(driver).MoveToElement(webElement).Perform();
        }

        public void ScrollToWebElelemnt(string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            ScrollToElement(webElement);
        }
    }
}
