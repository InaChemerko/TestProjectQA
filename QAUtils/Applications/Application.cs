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
        private static string ClientsFolder => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString(), "QAUtils", "Clients");

        public static IWebDriver GetWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            options.AddArgument("disable-infobars");
            options.AddArgument("--lang=en-GB");

            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return new ChromeDriver(ClientsFolder, options);
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
