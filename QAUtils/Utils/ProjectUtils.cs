using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QAUtils.Utils
{
    public class ProjectUtils
    {
        public static void ScrollToTopPage(IWebDriver driver)
        {
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, -document.body.scrollHeight)");
        }
    }
}
