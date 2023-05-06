using OpenQA.Selenium;
using QAUtils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProjectQA.Steps
{
    [Binding]
    public abstract class BaseSteps
    {
        public BaseSteps(ScenarioContext scenarioContext) 
        {
            ScenarioContext = scenarioContext;
        }

        public ScenarioContext ScenarioContext { get; private set; }

        public IWebDriver Driver => ScenarioContext.Get<IWebDriver>(KeyStorage.WebDriverKey);
    }
}
