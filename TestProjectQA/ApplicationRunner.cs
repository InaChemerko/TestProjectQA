using OpenQA.Selenium;
using QAUtils;
using QAUtils.Applications;
using QAUtils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProjectQA
{
    [Binding]    
    public class ApplicationRunner
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;

        public ApplicationRunner(ScenarioContext scenarioContext) 
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = Application.GetWebDriver();
            scenarioContext.Set(driver, KeyStorage.WebDriverKey);
            Application.OpenDriver(driver, TestConfigurator.AppSettings.Url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Application.CloseDriver(driver);

        }


    }
}
