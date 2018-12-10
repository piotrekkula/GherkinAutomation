using System.Linq;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Creating NewHCPDetailsPage add/edit page and all actions that can be performed from it. 
    /// </summary>

    public class CreateNewHCPDetailsPageModel : HealthcareProfessionalDetailsPageModel, IHasSaveButton, IHasCancelButton
    {
        //HCP Information section selectors
        private static readonly By addHCPEngagementIDFieldSelector = By.XPath("//td[contains(text(),'HCP Engagement')]/../td[2]/span/a");
        private static readonly By addHCPFirstNameFieldSelector = By.XPath("//td[contains(text(),'First Name')]/../td[2]/div/input");
        private static readonly By addHCPLastNameFieldSelector = By.XPath("//td[contains(text(),'Last Name')]/../td[2]/div/input");
        private static readonly By addHCPSpecialityFieldSelector = By.XPath("//label[contains(text(),'Speciality')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        private static readonly By addHCPAddSpecialityButtonSelector = By.XPath("//label[contains(text(),'Speciality')]/../../td[2]/div/table/tbody/tr[2]/td[2]/a[1]"); 
        private static readonly By addHCPStateOfPracticeFieldSelector = By.XPath("//label[contains(text(),'State of practice')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        private static readonly By addHCPAddStateOfPracticeButtonSelector = By.XPath("//label[contains(text(),'State of practice')]/../../td[2]/div/table/tbody/tr[2]/td[2]/a[1]");
        private static readonly By addHCPAddressFieldSelector = By.XPath("//label[contains(text(),'Address')]/../../td[4]/div/input");
        private static readonly By addHCPZipCodeFieldSelector = By.XPath("//label[contains(text(),'ZIP')]/../../td[4]/div/input");
        private static readonly By addHCPCityNameFieldSelector = By.XPath("//label[contains(text(),'City')]/../../td[4]/div/input");

        //Button field locators
        public static readonly By topSaveHCPButtonSelector = By.XPath("//h2[contains(text(),'Healthcare Professional Details')]/../../td[2]/input[1]");
        public static readonly By topCancelHCPButtonSelector = By.XPath("//h2[contains(text(),'Healthcare Professional Details')]/../../td[2]/input[2]");

        /// <summary>
        /// Constructor used when object of class is instantiated.
        /// </summary>
        public CreateNewHCPDetailsPageModel(IWebDriver driver)
            : base(driver, addHCPEngagementIDFieldSelector)
        {
        }

        public void FillInNewHCPInformation(string hcpFirstName, string hcpLastName, string hcpSpeciality, string hcpStateOfPractice, string hcpAddress, string hcpZipCode, string hcpCityName)
        {
            SendKeysToElement(addHCPFirstNameFieldSelector, hcpFirstName);
            SendKeysToElement(addHCPLastNameFieldSelector, hcpLastName);
            ChooseAvailableElementFromList(addHCPSpecialityFieldSelector,addHCPAddSpecialityButtonSelector,hcpSpeciality);
            ChooseAvailableElementFromList(addHCPStateOfPracticeFieldSelector,addHCPAddStateOfPracticeButtonSelector, hcpStateOfPractice);
            SendKeysToElement(addHCPAddressFieldSelector, hcpAddress);
            SendKeysToElement(addHCPZipCodeFieldSelector, hcpZipCode);
            SendKeysToElement(addHCPCityNameFieldSelector, hcpCityName);
        }
        public new void ClickSaveButton()
        {
            Driver.FindElement(topSaveHCPButtonSelector).Click();
        }
        public new void ClickCancelButton()
        {
            Driver.FindElement(topCancelHCPButtonSelector).Click();
        }
    }
}