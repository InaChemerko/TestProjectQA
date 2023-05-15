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
        public HomePage MainPage => new HomePage(Driver);
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
            var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
            pageObject.EnterTextInElement(nameElement, text);
        }

        [When(@"User clicks on (.*) product item")]
        public void ClickOnProductItem(string num)
        {
            var pageObject = ScenarioContext.Get<SearchResultPage>(KeyStorage.PageKey);
            pageObject.ClikNElement(Driver, num);
        }

        [When(@"User moves to (.*)")]
        public void MoveToWebElement(string name)
        {
            var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
            pageObject.MoveToElement(name);
        }

        [When(@"User scrolls to top page")]
        public void ScrollToTop()
        {
            // ProjectUtils.ScrollToTopPage(Driver);
            //((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0, -document.body.scrollHeight)");
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scroll(0, 0)");
        }

        [When(@"User scrolls to (.*) element")]
        public void Scrolling(string nameElement)
        {
            var pageObject = ScenarioContext.Get<BasePage>(KeyStorage.PageKey);
            pageObject.ScrollToWebElelemnt(nameElement);
        }
    }
}
