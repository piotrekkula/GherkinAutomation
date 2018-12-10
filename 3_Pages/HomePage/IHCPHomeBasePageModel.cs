using OpenQA.Selenium;
using System.Configuration;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing iHCP Home page and all actions that can be performed from it. 
    /// </summary>

    public class IHCPHomeBasePageModel : PageModel
    {        
        //HCP Engagement selectors
        public static readonly By CreateSearchEventButtonSelector = By.XPath("//li/input[@title='Refresh']/../../li/input[@value='Search/Create Event']");
        public static readonly By hcpRefreshEngagementListButtonSelector = By.XPath("//li/input[@value='Search/Create Event']/../../li/input[@title='Refresh']");
        
        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public IHCPHomeBasePageModel(IWebDriver driver)
            : base(driver, CreateSearchEventButtonSelector)
        {
        }

        /// <summary>
        /// Configure ID in settings file App.config.
        /// Externally it is possible to set it using config file in directory.
        /// </summary>
        public void SearchForFormWithSpecificID()
        {
            string hcpEngagementID = ConfigurationManager.AppSettings["hcpFormID"];
            SendKeysToElement(searchFormInputSelector, hcpEngagementID);
            Driver.FindElement(searchFormSearchButtonSelector).Click();
        }      
        public void ClickSearchEventButton()
        {
            Driver.FindElement(CreateSearchEventButtonSelector).Click();
        }
    }
}