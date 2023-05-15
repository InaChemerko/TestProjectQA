using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectQA.PageObjects
{
    public class WebLoadableComponent
    {
        private const int WaitInSecond = 10;
        private IWebDriver driver;

        public WebLoadableComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement WaitElement(By selector, IWebElement? parentElement = null, int waitInSecond = WaitInSecond)
        {
            try
            {
                IWebElement? result = null;
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

        protected IReadOnlyList<IWebElement> WaitElements(By selector, IWebElement? parentElement = null, int waitInSecond = WaitInSecond)
        {
            try
            {
                IReadOnlyList<IWebElement> result = new List<IWebElement>();
                Wait(sec: waitInSecond).Until(driver =>
                {
                    try
                    {

                        var elements = parentElement == null ? driver.FindElements(selector) : parentElement.FindElements(selector);

                        if (elements.Count == 0)
                            return false;

                        result = elements;
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
    }
}
