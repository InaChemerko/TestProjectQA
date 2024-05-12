using DataBase.DBcommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProjectQA.Steps
{
    public class DBsteps : BaseSteps
    {
        public DBsteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"Crete new user ""(.*)"", ""(.*)""")]
        public async Task CreateNewUser(string firstName, string lastName)
        {
            var dbWorker = new UserDBworker();
            await dbWorker.CreateNewUser(new DataBase.DB.Models.User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = "test",
                Age = new DateTime(2024, 5, 1)
            });
        }
    }
}
