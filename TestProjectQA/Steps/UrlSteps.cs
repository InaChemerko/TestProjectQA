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
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using TechTalk.SpecFlow.Infrastructure;

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


            using var client = new HttpClient();
            var csrfToken = await client.GetFromJsonAsync<TokenDto>("https://lms.skillfactory.ru/csrf/api/v1/token");

            client.DefaultRequestHeaders.Add("X-CSRFToken", csrfToken.csrfToken);
            client.DefaultRequestHeaders.Add("USE-JWT-COOKIE", "true");

            

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Content-Disposition: form-data; name=\"email\"", email),
                new KeyValuePair<string, string>("Content-Disposition: form-data; name=\"password\"", password)
            });


            var response = await client.PostAsync("https://lms.skillfactory.ru/api/user/v1/account/login_session", formContent);

            var cookies = new CookieContainer();
            var uri = new Uri("https://apps.skillfactory.ru/");

            foreach (var cookieHeader in response.Headers.GetValues("set-cookie"))
            {
                cookies.SetCookies(uri, cookieHeader);
            }

            foreach (Cookie cookie in cookies.GetCookies(uri))
            {
                Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value));
            }         
            

        }        

    }
}
