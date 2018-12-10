using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using GherkinAutomation.Pages;
using Helper.Interfaces;
using WebTestAutomation.Steps;

namespace GherkinAutomation.Steps
{
    [Binding]
    public class FormVerificationSteps : BaseStepDefinitions
    {
        [When(@"User searches for existing sHCP form and opens it")]
        public void WhenUserSearchesForExistingSHCPFormAndOpensIt()
        {
            Use<IHCPHomeBasePageModel>().SearchForFormWithSpecificID();
            Create(new SearchResultsPageModel(Driver));
            Use<SearchResultsPageModel>().SelectFoundFormWithSpecificID();
            Create(new ViewsHCPFormPageModel(Driver));
        }

        [When(@"User searches for existing mHCP form and opens it")]
        public void WhenUserSearchesForExistingMHCPFormAndOpensIt()
        {
            Use<IHCPHomeBasePageModel>().SearchForFormWithSpecificID();
            Create(new SearchResultsPageModel(Driver));
            Use<SearchResultsPageModel>().SelectFoundFormWithSpecificID();
            Create(new ViewmHCPFormPageModel(Driver));
        }

        [When(@"User searches for existing uHCP form and opens it")]
        public void WhenUserSearchesForExistingUHCPFormAndOpensIt()
        {
            Use<IHCPHomeBasePageModel>().SearchForFormWithSpecificID();
            Create(new SearchResultsPageModel(Driver));
            Use<SearchResultsPageModel>().SelectFoundFormWithSpecificID();
            Create(new ViewuHCPFormPageModel(Driver));
        }

        [When(@"User clicks Send To Engagement Owner For Verification button")]
        public void WhenUserClicksSendToEngagementOwnerForVerificationButton()
        {
            Use<IHasSendForVerificationButton>().SendForVerification();
        }

        [Then(@"Form has been sent for verification")]
        public void ThenFormHasBeenSentForVerification()
        {
            Assert.True(Driver.FindElements(ViewHCPFormPageModel.successMessageLabelSelector).Count() != 0, "Success message was not displayed! Form is not properly processed.");
        }
    }
}
