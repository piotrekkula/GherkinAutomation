using OpenQA.Selenium;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Search Results page which opens when user uses search box on top of the page.
    /// Page shows search results and returns items found.
    /// </summary>

    public class SearchResultsPageModel : PageModel
    {
        //Other salesforce interface
        public static readonly By salesforceHelpBubbleSelector = By.XPath("//*[@id='HelpBubble']");
        public static readonly By salesforceHelpBubbleCloseButtonSelector = By.XPath("//*[@id='helpBubbleCloseX']");
        
        //NameLookup Pop-up selectors
        public static readonly By secondSearchFieldSelector = By.XPath("//form/*[1]/input[@type='text']");
        public static readonly By secondSearchButtonSelector = By.XPath("//form/*[2]/input[@type='submit']");
        
        //HCP Engagement search results selectors
        public static readonly By hcpEngagementEditLinkSelector = By.XPath("//*[@id='HCP_Engagement_ihcp__c_body']/table/tbody/tr[1]/th/a");
        public static readonly By hcpEngagementIdOnListLinkSelector = By.XPath("//*[@id='HCP_Engagement_ihcp__c_body']/table/tbody/tr[2]/th[1]/a");
        
        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public SearchResultsPageModel(IWebDriver driver)
            : base(driver, secondSearchButtonSelector)
        {
            //Close salesforce help bubble so it doesnt limit our view
            if (Driver.FindElements(salesforceHelpBubbleSelector).Count != 0)
            {
                Driver.FindElement(salesforceHelpBubbleCloseButtonSelector).Click();
            }
        }

        public void SelectFoundFormWithSpecificID()
        {
            Driver.FindElement(hcpEngagementIdOnListLinkSelector).Click();
        }
    }
}
