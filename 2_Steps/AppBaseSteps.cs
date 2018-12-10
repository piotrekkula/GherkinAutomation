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
    /// <summary>
    /// Base application steps shared for all scenarios. Common paths are covered such as Login, Create New Form.
    /// </summary>
    [Binding]
    public class AppBaseSteps : BaseStepDefinitions
    {
        [Given(@"I am logged in as (.*)")]
        [When(@"I log in as (.*)")]
        public void GivenIAmLoggedInAs(string userToLogin)
        {
            Create(new LoginPageModel(Driver));
            Use<LoginPageModel>().LogInToApplication(userToLogin);            
            Use<LoginPageModel>().ClickLoginButton();
            Create(new IHCPHomeBasePageModel(Driver));
        }

        [When(@"I click Logout Link")]
        public void WhenIClickLogoutLink()
        {
            Use<PageModel>().LogOutOfApplication();
        }

        [Then(@"I am logged out")]
        public void ThenIAmLoggedOut()
        {
            //Assert.False(Driver.FindElements(userNavigationMenuButtonSelector) != 0, "Menu is visible. I have not been logged out!");
        }

        [When(@"User clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            Use<IHasSaveButton>().ClickSaveButton();   
        }

        [When(@"User clicks Edit button")]
        public void WhenUserClicksEditButton()
        {
            Use<IHasEditButton>().ClickEditButton();
        }

        [When(@"User clicks Cancel button")]
        public void WhenUserClicksCancelButton()
        {
            Use<IHasCancelButton>().ClickCancelButton();
        }

        /// <summary>
        /// IS THIS USED??
        /// </summary>
        [When(@"User clicks Next button")]
        public void WhenUserClicksNextButton()
        {
            Use<IHasNextButton>().ClickNextButton();
        }

        [Then(@"Form is in status (.*)")]
        public void ThenFormIsInStatus(string formStatus)
        {
            //Create(Use<PageModel>().FormIsInStatus(formStatus));
        }

        [Then(@"sHCP Form is in view mode")]
        public void ThenSHCPFormIsInViewMode()
        {
            Create(new ViewsHCPFormPageModel(Driver));
        }

        [Then(@"mHCP Form is in view mode")]
        public void ThenMHCPFormIsInViewMode()
        {
            Create(new ViewmHCPFormPageModel(Driver));
        }

        [Then(@"uHCP Form is in view mode")]
        public void ThenUHCPFormIsInViewMode()
        {
            Create(new ViewuHCPFormPageModel(Driver));
        }

        [Then(@"sHCP Form is in edit mode")]
        public void ThenSHCPFormIsInEditMode()
        {
            Create(new AddNewsHCPFormPageModel(Driver));
        }

        [Then(@"mHCP Form is in edit mode")]
        public void ThenMHCPFormIsInEditMode()
        {
            Create(new AddNewmHCPFormPageModel(Driver));
        }

        [Then(@"uHCP Form is in edit mode")]
        public void ThenUHCPFormIsInEditMode()
        {
            Create(new AddNewuHCPFormPageModel(Driver));
        }

        [Then(@"HomePage is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            Create(new IHCPHomeBasePageModel(Driver));
        }

        [Then(@"HCP Event Form page is displayed")]
        public void ThenHCPEventFormPageIsDisplayed()
        {
            Create(new HCPEventEditFormPageModel(Driver));
        }
    }
}
