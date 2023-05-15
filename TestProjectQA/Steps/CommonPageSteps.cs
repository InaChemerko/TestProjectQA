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
        public CommonPageSteps(ScenarioContext scenarioContext) 
            : base(scenarioContext)
        {
        }

        public HomePage MainPage => new (Driver);
        public SearchPage SearchPage => new (Driver);     
        
        public SearchResultPage SearchResultPage => new (Driver);

        [When(@"User clicks on (.*) button")]
        public void ClickOnButton(string button)
        {
            var pageObject = ScenarioContext.Get<BasePageObject>(KeyStorage.PageKey);
            pageObject.ClickElement(button);
        }

        [When(@"User opens (.*) page")]
        public void UserOpenPage(Pages page) 
        {
            var pageObject = GetPageObject(page);
            ScenarioContext.Set(pageObject, KeyStorage.PageKey);
        }

        private BasePageObject GetPageObject(Pages page)
        {
            return page switch
            {
                Pages.Home => new HomePage(Driver),
                Pages.Search => new SearchPage(Driver),
                Pages.SearchResult => new SearchResultPage(Driver),
                Pages.ProductItem => new ProductItemPage(Driver),
                _ => throw new NotImplementedException($"Unable to get page {page}"),                
            };
        }

        [When(@"User enter in (.*) ""(.*)"" text")]
        public void UserEnterWords(string nameElement, string text)
        {
            var pageObject = ScenarioContext.Get<BasePageObject>(KeyStorage.PageKey);
            pageObject.EnterTextInElement(nameElement, text);
        }

        [When(@"User clicks on (.*) product item")]
        public void ClickOnProductItem(int num)
        {
            SearchResultPage.ClikNElement(Driver, num);
        }

        //[When(@"User clicks on (.*) specific product item in (.*) list")]
        //public void ClickOnSpecificProductItem(string num, string nameElement)
        //{
        //    var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
        //    pageObject.ClickOnSpecificElement(num, nameElement);
        //}

        [When(@"User moves to (.*)")]
        public void MoveToWebElement(string name)
        {
            var pageObject = ScenarioContext.Get<BasePageObject>(KeyStorage.PageKey);
            pageObject.MoveToElement(name);
        }

        [When(@"User scrolls to top page")]
        public void UserScrollsToTopPage()
        {
            var pageObject = ScenarioContext.Get<BasePageObject>(KeyStorage.PageKey);
            pageObject.ScrollToTop();
        }

        [When(@"User scrolls to (.*) element")]
        public void Scrolling(string nameElement)
        {
            var pageObject = ScenarioContext.Get<BasePageObject>(KeyStorage.PageKey);
            pageObject.ScrollToWebElelemnt(nameElement);
        }
    }
}
