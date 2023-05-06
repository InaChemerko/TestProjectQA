using OpenQA.Selenium;
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

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(string nameElement)
        {
            var locator = GetClickableElementLocator(nameElement);
            var webElement = WaitElement(locator);
            webElement.Click();
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

    }
}
