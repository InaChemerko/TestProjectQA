using QAUtils.ModelSkillFactory;
using QAUtils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using TechTalk.SpecFlow.Infrastructure;
using static System.Net.WebRequestMethods;

namespace TestProjectQA.Steps
{
    public class UrlSteps : BaseSteps
    {
        private ISpecFlowOutputHelper specFlowOutputHelper;
        public UrlSteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper) : base(scenarioContext)
        {
            this.specFlowOutputHelper = specFlowOutputHelper;
        }

        [When(@"User opens ""(.*)"" url")]
        public void WhenUserOpensUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);

        }

        [When(@"User logins to Skillfactory")]
        public async Task WhenUserLoginsToSkillfactory()
        {
            var email = "innachemerko@gmail.com";
            var password = "siigwNaN22";

            var cookies = new CookieContainer();
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookies
            };
            using var client = new HttpClient(httpClientHandler);
            var token = await client.GetFromJsonAsync<TokenDto>("https://lms.skillfactory.ru/csrf/api/v1/token");
            
            client.DefaultRequestHeaders.Add("X-CSRFToken", token.csrfToken);
            //client.DefaultRequestHeaders.Add("USE-JWT-COOKIE", "true");
            client.DefaultRequestHeaders.Add("Referer", "https://apps.skillfactory.ru/");


            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(email), "email");
            formContent.Add(new StringContent(password), "password");

            var response = await client.PostAsync("https://lms.skillfactory.ru/api/user/v1/account/login_session/", formContent);
            
            Driver.Manage().Cookies.DeleteAllCookies();

            foreach(Cookie cookie in cookies.GetAllCookies())
            {
                Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, ".skillfactory.ru", "/", DateTime.UtcNow.AddDays(14)));
            }

            //var cookies = new CookieContainer();
            //var uri = new Uri("https://apps.skillfactory.ru/");

            //foreach (var cookieHeader in response.Headers.GetValues("set-cookie"))
            //{
            //    cookies.SetCookies(uri, cookieHeader);
            //}

            //foreach (Cookie cookie in cookies.GetCookies(uri))
            //{
            //    Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value));
            //}         
            

        }        

    }
}
