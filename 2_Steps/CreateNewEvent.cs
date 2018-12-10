using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using GherkinAutomation.Pages;
using Helper.Interfaces;
using WebTestAutomation.Steps;

namespace GherkinAutomation.Steps
{
    [Binding]
    public class CreateNewEvent : BaseStepDefinitions
    {
        [When(@"I click Search Event button")]
        public void WhenIClickSearchEventButton()
        {
            Use<IHCPHomeBasePageModel>().ClickSearchEventButton();
        }

        [Then(@"Event Information search page is displayed")]
        public void ThenEventInformationSearchPageIsDisplayed()
        {
            Create(new EventInformationSearchPageModel(Driver));
        }

        [When(@"I fill in Event Information section")]
        public void WhenIFillInEventInformationSection(Table table)
        {
            string eventInfoTitle = table.Header.ElementAt(0);
            string eventInfoType = table.Header.ElementAt(1);
            string eventInfoVenue = table.Header.ElementAt(2);
            string eventInfoStartDate = table.Header.ElementAt(3);
            string eventInfoEndDate = table.Header.ElementAt(4);

            Use<EventInformationSearchPageModel>().FillInEventInformationSection(eventInfoTitle,eventInfoType,eventInfoVenue,eventInfoStartDate,eventInfoEndDate);
        }

        [When(@"I click Search button")]
        public void WhenIClickSearchButton()
        {
            Use<IHasSearchButton>().ClickSearchButton();
        }


        [Then(@"Event search results are displayed")]
        public void ThenEventSearchResultsAreDisplayed()
        {
            Use<EventInformationSearchPageModel>().CheckForPreviousEvents();
        }

        [When(@"I click Create Event button")]
        public void WhenIClickCreateEventButton()
        {
            Use<EventInformationSearchPageModel>().ClickCreateEventButton();
        }

        [When(@"I asldkjalskjdlaskjd")]
        public void WhenIAsldkjalskjdlaskjd()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"alskjdalsjdlaksjd")]
        public void ThenAlskjdalsjdlaksjd()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
