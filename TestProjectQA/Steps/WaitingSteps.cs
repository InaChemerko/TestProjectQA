using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProjectQA.Steps
{
    [Binding]
    public class WaitingSteps : BaseSteps
    {
        public WaitingSteps(ScenarioContext scenarioContext) : base(scenarioContext) {

        }

        [When(@"User waits ([0-9]+) (?:(?:second|seconds))")]
        public static async Task WhenUsersWaitSeconds(int sec)
        {
            await Task.Delay(sec * 1000);
        }
    }
}
