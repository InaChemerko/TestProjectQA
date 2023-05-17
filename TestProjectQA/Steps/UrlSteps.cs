using QAUtils.ModelSkillFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
            using (var client = new HttpClient())
            {
                //using var result = await client.GetAsync("https://lms.skillfactory.ru/csrf/api/v1/token");
                //Console.WriteLine(result.StatusCode);
                //System.Diagnostics.Debug.WriteLine($"result: {result.Content}");
                //specFlowOutputHelper.WriteLine($"result: {result.Content}");
                //string responseBody = await result.Content.ReadAsStringAsync();
                //specFlowOutputHelper.WriteLine($"responseBody: {responseBody}");

                var csrfToken = await client.GetFromJsonAsync<TokenDto>("https://lms.skillfactory.ru/csrf/api/v1/token");
                specFlowOutputHelper.WriteLine($"result: {csrfToken.csrfToken}");

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Content-Disposition: form-data; name=\"email\"", "innachemerko@gmail.com"),
                    new KeyValuePair<string, string>("Content-Disposition: form-data; name=\"password\"", "siigwNaN22")
                });

                //var myHttpClient = new HttpClient();
                var response = await client.PostAsync("https://lms.skillfactory.ru/api/user/v1/account/login_session", formContent);

                CookieContainer cookies = new CookieContainer();
                var uri = new Uri("https://lms.skillfactory.ru");
                // получаем из запроса все элементы с заголовком Set-Cookie
                foreach (var cookieHeader in response.Headers.GetValues("set-cookie"))
                    // добавляем заголовки кук в CookieContainer
                    cookies.SetCookies(uri, cookieHeader);

                foreach (Cookie cookie in cookies.GetCookies(uri))
                    specFlowOutputHelper.WriteLine($"{cookie.Name}: {cookie.Value}");


                var i = 0;
            }

        }


    }
}
