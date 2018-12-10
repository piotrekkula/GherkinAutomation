using System.Linq;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Adding Supporting Role page and all actions that can be performed from it. 
    /// </summary>

    public class AddSupportingRolePageModel : ViewHCPFormPageModel, IHasSaveButton, IHasCancelButton
    {
        //HCP Engagement Person section selectors
        private static readonly By suppRoleHCPEngagementIDFieldSelector = By.XPath("//td[contains(text(),'HCP Engagement')]/../td[2]/span/a");
        private static readonly By suppRoleRequestRoleFieldSelector = By.XPath("//label[contains(text(),'Request Role')]/../../td[2]/select");
        private static readonly By suppRoleMessageFieldSelector = By.XPath("//label[contains(text(),'Message')]/../../td[2]/textarea");
        private static readonly By suppRoleUserLookupFieldSelector = By.XPath("//label[contains(text(),'User')]/../../td[2]/span/a/img");
        
        //Button field locators
        public static readonly By topSaveSupportingRoleButtonSelector = By.XPath("//h2[contains(text(),'HCP Engagement Person')]/../../td[2]/input[2]");
        public static readonly By topCancelSupportingRoleButtonSelector = By.XPath("//h2[contains(text(),'HCP Engagement Person')]/../../td[2]/input[1]");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public AddSupportingRolePageModel(IWebDriver driver)
            : base(driver, suppRoleHCPEngagementIDFieldSelector)
        {
        }

        public void FillSupportingRole(string userName, string supportingRole)
        {
            HandlePopup(
                            () => Driver.FindElement(suppRoleUserLookupFieldSelector).Click(),
                            () => UseAsPopup<NameLookupPageModel>().PerformNameLookup(userName)
                        );

            ChooseAvailableElementFromList(suppRoleRequestRoleFieldSelector, supportingRole);
            SendKeysToElement(suppRoleMessageFieldSelector, "Some message");
        }
        
        public void ClickSaveButton()
        {
            Driver.FindElement(topSaveSupportingRoleButtonSelector).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(topCancelSupportingRoleButtonSelector).Click();
        }
    }
}
