using System.Linq;
using TechTalk.SpecFlow;
using NUnit.Framework;
using GherkinAutomation.Pages;
using Helper.Interfaces;
using WebTestAutomation.Steps;

namespace GherkinAutomation.Steps
{
    [Binding]
    public class SmokeTesting : BaseStepDefinitions
    {
        [Then(@"Smoke Test passes")]
        public void ThenSmokeTestPasses()
        {
            Use<IHasSmokeTest>().SmokeTest();
        }

        [Then(@"Legacy form option is not visible")]
        public void ThenLegacyFormOptionIsNotVisible()
        {
            Use<NewHCPEngagementPageModel>().IsNewLegacyFormButtonPresentOnPage();
        }
    }
}
