using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAUtils.Applications
{
    public class Application
    {
        public static IWebDriver GetWebDriver()
        {
            var options = new ChromeOptions();
            var pathToChromeDriver = "C:\\Users\\Ina\\source\\repos\\TestProjectQA\\QAUtils\\Clients";
            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return new ChromeDriver(pathToChromeDriver, options);
        }

        public static void OpenDriver(IWebDriver driver, string url)
        {
            driver?.Navigate().GoToUrl(url);
        }

        public static void CloseDriver(IWebDriver driver)
        {
            driver?.Quit();
        }
    }
}
