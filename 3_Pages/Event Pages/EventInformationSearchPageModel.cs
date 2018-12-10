using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Event Information Search page and all actions that can be performed from it. 
    /// Even Information page is triggered when User wants to create or search for a specific event.
    /// </summary>

    public class EventInformationSearchPageModel : PageModel, IHasSearchButton, IHasCancelButton
    {
        //HCP Engagement selectors
        public static readonly By eventTitleButtonSelector = By.XPath("//*[contains(@id,'eventTitle')]");
        
        public static readonly By eventTypeAvailableFieldSelector = By.XPath("//*[contains(@id,'eventType_unselected')]");
        public static readonly By eventTypeChosenFieldSelector = By.XPath("//*[contains(@id,'eventType_selected')]");
        public static readonly By eventTypeAddButtonSelector = By.XPath("//*[contains(@id,'eventType_right_arrow')]");
        public static readonly By eventTypeRemoveButtonSelector = By.XPath("//*[contains(@id,'eventType_left_arrow')]");

        public static readonly By eventVenueFieldSelector = By.XPath("//*[contains(@id,'eventVenue')]");
        public static readonly By eventStartDateFieldSelector = By.XPath("//*[contains(@id,'eventStartDate')]");
        public static readonly By eventEndDateFieldSelector = By.XPath("//*[contains(@id,'eventEndDate')]");
        public static readonly By eventEndDateFieldLabelSelector = By.XPath("//*[contains(@for,'eventEndDate')]");
        
        public static readonly By eventSearchResultsFieldSelector = By.XPath("//*[contains(@id,'eventtable:tb')]/tr/td[4]");

        //Button selectors
        public static readonly By cancelButtonSelector = By.XPath("//*[contains(@id,'btnCancel')]");
        public static readonly By searchButtonSelector = By.XPath("//*[contains(@id,'btnSearch')]");
        public static readonly By createEventButtonSelector = By.XPath("//*[contains(@id,'btnNewEvent')]");
        
        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public EventInformationSearchPageModel(IWebDriver driver)
            : base(driver, eventTitleButtonSelector)
        {
        }

        public void FillInEventInformationSection(string eventTitle, string eventType,string eventVenue, string startDate,string endDate)
        {
            SendKeysToElement(eventTitleButtonSelector,eventTitle);
            ChooseAvailableElementFromList(eventTypeAvailableFieldSelector,eventTypeAddButtonSelector, eventType);
            SendKeysToElement(eventVenueFieldSelector, eventVenue);
            SendKeysToElement(eventStartDateFieldSelector, startDate);
            Driver.FindElement(eventVenueFieldSelector).Click();
            SendKeysToElement(eventEndDateFieldSelector, endDate);
        }

        public void CheckForPreviousEvents()
        {
            //Assert.IsNotNullOrEmpty(Driver.FindElement(eventSearchResultsFieldSelector).Text, "Event already exists!");
        }

        public void ClickCreateEventButton()
        {
            Driver.FindElement(createEventButtonSelector).Click();
        }

        void IHasCancelButton.ClickCancelButton()
        {
            Driver.FindElement(cancelButtonSelector).Click();
        }

        void IHasSearchButton.ClickSearchButton()
        {
            Driver.FindElement(searchButtonSelector).Click();
        }
    }
}

