using System.Linq;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing HCP Details/search and all actions that can be performed from it. 
    /// </summary>

    public class HealthcareProfessionalDetailsPageModel : AddNewHCPFormPageModel, IHasSaveButton, IHasCancelButton
    {

        //ID and Country locators
        public static readonly By hcpIDFieldSelector = By.XPath("//td[contains(text(),'HCP Engagement')]/../*[2]/span/a");
        public static readonly By CountryFieldSelector = By.XPath("//td[contains(text(),'Country')]/../*[4]/span/a");
        
        //Input field locators
        public static readonly By LastNameFieldSelector = By.XPath("//td[contains(text(),'Last Name')]/../*[2]/input");
        public static readonly By FirstNameFieldSelector = By.XPath("//td[contains(text(),'First Name')]/../*[2]/input");

        //Button field locators
        public static readonly By SearchForHCPButtonSelector = By.XPath("//tbody/*[2]/td/span/input[@type='submit']");
        public static readonly By CancelButtonSelector = By.XPath("//h2[contains(text(),'Healthcare Professional Details')]/../../td/input[@value='Cancel']");
        public static readonly By SaveSelectedButtonSelector = By.XPath("//h2[contains(text(),'Healthcare Professional Details')]/../../td/input[@value='Save Selected']");
        public static readonly By AddNewHCPManuallyButtonSelector = By.XPath("//input[contains(@value,'Add new HCP details')]");

        //Link locators
        public static readonly By AddHCPLinkSelector = By.XPath("//tbody/*[1]/*[1]/*[1]/a[contains(text(),'Add')]");
        public static readonly By AddHCP2LinkSelector = By.XPath("//tbody/*[2]/*[1]/*[1]/a[contains(text(),'Add')]");
        public static readonly By DeleteHCPLinkSelector = By.XPath("//tbody/*[1]/*[1]/*[1]/a[contains(text(),'Delete')]");
        public static readonly By DeleteHCP2LinkSelector = By.XPath("//tbody/*[2]/*[1]/*[1]/a[contains(text(),'Delete')]");

        /// <summary>
        /// Constructor used when object of child class is instantiated
        /// </summary>
        public HealthcareProfessionalDetailsPageModel(IWebDriver driver, By knownElementOnPage)
            : base(driver, knownElementOnPage)
        {
        }

        /// <summary>
        /// Constructor used when object of class is instantiated.
        /// </summary>
        public HealthcareProfessionalDetailsPageModel(IWebDriver driver)
            : base(driver, LastNameFieldSelector)
        {
        }

        public void SearchForExistingHCP(string hcpFirstName, string hcpLastName)
        {
            SendKeysToElement(LastNameFieldSelector, hcpLastName);
            SendKeysToElement(FirstNameFieldSelector, hcpFirstName);
            Driver.FindElement(SearchForHCPButtonSelector).Click();
        }

        public void ChooseExistingHCP()
        {
            //If one HCP is already added add second from list displayed
            if (Driver.FindElements(DeleteHCPLinkSelector).Count() != 0)
            {
                Driver.FindElement(AddHCP2LinkSelector).Click();
                WaitForObject(DeleteHCP2LinkSelector);
            }
            else
            {
                WaitForObject(AddHCPLinkSelector);
                Driver.FindElement(AddHCPLinkSelector).Click();
                WaitForObject(DeleteHCPLinkSelector);
            }
        }

        public void ClickSearchForHCPButton()
        {
            Driver.FindElement(SearchForHCPButtonSelector).Click();
        }
        public void ClickAddNewHCPManuallyButton()
        {
            Driver.FindElement(AddNewHCPManuallyButtonSelector).Click();
        }
        public void ClickSaveButton()
        {
            Driver.FindElement(SaveSelectedButtonSelector).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(CancelButtonSelector).Click();
        }
    }
}