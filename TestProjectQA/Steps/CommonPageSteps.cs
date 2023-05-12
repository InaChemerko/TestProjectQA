using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QAUtils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProjectQA.PageObjects;

namespace TestProjectQA.Steps
{
    public class CommonPageSteps : BaseSteps
    {
        public CommonPageSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        public MainPage MainPage => new MainPage(Driver);
        public SearchPage SearchPage => new SearchPage(Driver);

        [When(@"User clicks on (.*) button")]
        public void ClickOnButton(string button)
        {
            var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
            pageObject.ClickElement(button);
        }

        [When(@"User opens (.*) page")]
        public void UserOpenPage(Pages page) 
        {
            var pageObject = GetPageObject(page);
            ScenarioContext.Set(pageObject, KeyStorage.PageKey);
        }

        private BasePage GetPageObject(Pages page)
        {
            return page switch
            {
                Pages.Main => new MainPage(Driver),
                Pages.Search => new SearchPage(Driver),
                _ => throw new NotImplementedException($"Unable to get page {page}"),                
            };
        }

        [When(@"User enter in (.*) ""(.*)"" text")]
        public void UserEnterWords(string nameElement, string text)
        {
            var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
            pageObject.EnterTextInElement(nameElement, text);
        }

    }
}
