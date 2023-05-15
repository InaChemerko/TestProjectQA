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
    public abstract class BasePage
    {
        private IWebDriver driver;
        private const int WaitInSecond = 5;
        private const int ScrollWait = 500;
        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            new Actions(driver).MoveToElement(webElement).Perform();
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


        protected IWebElement WaitElement(By selector, IWebElement parentElement = null, int waitInSecond = WaitInSecond)
        {
            try
            {
                IWebElement result = null;
                Wait(sec: waitInSecond).Until(driver =>
                {
                    try
                    {

                        var element = parentElement == null ? driver.FindElement(selector) : parentElement.FindElement(selector);
                        result = element;
                        return true;

                    }
                    catch (Exception)
                    {

                        return false;
                    }
                });

                return result ?? throw new WebDriverTimeoutException();
            }
            catch (WebDriverTimeoutException)
            {

                throw new NoSuchElementException($"Element was not found by the following selector: ${selector.ToString()}");
            }

        }

        protected WebDriverWait Wait(int days = 0, int hours = 0, int min = 0, int sec = 0, int ms = 0) =>
            new(this.driver, new TimeSpan(days, hours, min, sec, ms));

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
