using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Helper.Interfaces;
using System.Configuration;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing View mHCP page when user creates new form and all actions that can be performed on it. 
    /// </summary>

    public class ViewuHCPFormPageModel : ViewHCPFormPageModel, IHasEditButton, IHasCancelButton, IHasSendForVerificationButton
    {
        //Healthcare Professional Details selectors
        public static readonly By hcpDetailsCountryFieldSelector = By.XPath("//td[contains(text(),'HCP Country')]/../td/span/a");
        public static readonly By hcpDetailsFullNameLabelSelector = By.XPath("//td[contains(text(),'HCP Country')]/../../tr[2]/td/span/table/tbody/tr[1]/td[1]/a");
        public static readonly By hcpDetailsFullName2LabelSelector = By.XPath("//td[contains(text(),'HCP Country')]/../../tr[2]/td/span/table/tbody/tr[2]/td[1]/a");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public ViewuHCPFormPageModel(IWebDriver driver)
            : base(driver, infoFormTypeLabelSelector)
        {
        }

        /// <summary>
        /// Verify if each section was saved correctly
        /// </summary>

        public override void VerifyIfEngOwnerSectionIsSaved(string engOwnerName, string globalFunction, string jobTitle, string engagementPaidBy, string engFunction)
        {
            //Engagement owner assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerNameLabelSelector).Text, "Name field is empty!");
            Assert.AreEqual(jobTitle, Driver.FindElement(engOwnerJobTitleLabelSelector).Text, "Job Title field is incorrect!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerDepartmentLabelSelector).Text, "Department field is empty. Check if department field is set in user details!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerEmailLabelSelector).Text, "Email field is empty. Check if email field is set in user details!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerPhoneDetailsLabelSelector).Text, "Phone field is empty. Check if phone field is set in user details!");
            Assert.AreEqual(engagementPaidBy, Driver.FindElement(engOwnerEngagementPaidByLabelSelector).Text, "Smoke test failed. Object cannot be found on page!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerCountryLabelSelector).Text, "Country field is empty. Check if country field is set in user details!");
            Assert.AreEqual(engFunction, Driver.FindElement(engOwnerFunctionLabelSelector).Text, "Function field is incorrect!");
        }
        public override void VerifyIfHCPCoordSectionIsSaved(string hcpCoord)
        {
            //HCP Coordinator/Assistant Details assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(hcpCoordNameLabelSelector).Text, "HCP Coordinator Section is filled incorrectly!");
        }
        public override void VerifyIfLineManagerSectionIsSaved(string lineManager)
        {
            //Line Manager assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(lineMgrLineManagerLabelSelector).Text, "Line Manager Section is filled incorrectly!");
        }
        public override void VerifyIfHCPDetailsSectionIsSaved(string hcpCountry, string hcpFirstName, string hcpLastName, string hcpFirstName2, string hcpLastName2)
        {
            //Healthcare Professional Details assertions
            Assert.IsTrue(Driver.FindElement(hcpDetailsFullNameLabelSelector).Text.ToUpper().Equals(hcpFirstName.ToUpper() + " " + hcpLastName.ToUpper()) || Driver.FindElement(hcpDetailsFullNameLabelSelector).Text.ToUpper().Equals(hcpFirstName2.ToUpper() + " " + hcpLastName2.ToUpper()), "HCP Full Name field does not contain HCP Details !");
        }
        public override void VerifyIfProdInfSectionIsSaved(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
            //Product Information assertions
            Assert.AreEqual(therapeuticArea, Driver.FindElement(prodInfTherapeuticAreaLabelSelector).Text, "Therapeutic Area does not have chosen item on list!");
            Assert.AreEqual(productBrandMolecule, Driver.FindElement(prodInfProductBrandMoleculeLabelSelector).Text, "Product/Brand/Molecule does not have chosen item on list!");
            Assert.AreEqual(prodIndication, Driver.FindElement(prodInfIndicationLabelSelector).Text, "Indication does not have chosen item on list!");
        }
        public override void VerifyIfEngDescSectionIsSaved(string engagementTitle, string engDescCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engDescription)
        {
            //Engagement description assertions
            Assert.AreEqual(engagementTitle, Driver.FindElement(engDescEngagementTitleLabelSelector).Text, "Engagement Title field has incorrect value!");
            Assert.AreEqual(engDescCongress, Driver.FindElement(engDescCongressLabelSelector).Text, "Congress field does not contain any value!");
            Assert.AreEqual(engagementType, Driver.FindElement(engDescEngagementTypeLabelSelector).Text, "Engagement Type Chosen field does not contain any value!");

            if (allDayEngagement.Equals("Yes"))
            {
                Assert.AreEqual("Checked", Driver.FindElement(engDescAllDayEngagementLabelSelector).GetAttribute("title"), "All Day Engagement should be selected!");
            }

            Assert.AreEqual(engagementVenue, Driver.FindElement(engDescEngagementVenueLabelSelector).Text, "Engagement Venue field is not filled correctly!");
            Assert.AreEqual(engagementCity, Driver.FindElement(engDescEngagementCityLabelSelector).Text, "Engagement City field is not filled correctly!");

            switch (engagementStateProvince)
            {
                case "US":
                    Assert.AreEqual(engagementStateProvince, Driver.FindElement(engDescEngagementStateProvinceFieldSelector).GetAttribute("value"), "Engagement State/Province field is not filled correctly!");
                    break;
                case "Other":
                    Assert.AreEqual(engagementStateProvince, Driver.FindElement(engDescEngagementOtherCountryFieldSelector).GetAttribute("value"), "Engagement Other Country field is not filled correctly!");
                    break;
                default:
                    break;
            }

            Assert.IsNotNullOrEmpty(Driver.FindElement(engDescStartDateLabelSelector).Text, "Start date field is empty!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engDescEndDateLabelSelector).Text, "End Date field is empty!");
            Assert.AreEqual(sciMedBusNeeds, Driver.FindElement(engDescScientificalMedicalBusinessNeedsLabelSelector).Text, "Scientific Medical Business needs field is not filled correctly!");
            Assert.AreEqual(engagementObjective, Driver.FindElement(engDescEngagementObjectivesLabelSelector).Text, "Engagement Objectives field is not filled correctly!");

            if (contractedService.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(engDescContractedRadioYesButtonSelector).Selected, "Part of Contracted service YES option should be selected!");
            }
            else
            {
                Assert.True(Driver.FindElement(engDescContractedRadioNoButtonSelector).Selected, "Part of Contracted service NO option should be selected!");
                Assert.AreEqual(engDescription, Driver.FindElement(engDescDescriptionLabelSelector).Text, "Description field is not filled correctly!");
            }
        }
        public override void VerifyIfAffiliateContSectionIsSaved(string affContact)
        {
            //Affiliate Contact List assertions
            Assert.AreEqual(affContact, Driver.FindElement(affContAffiliateContactLabelSelector).Text, "Affiliate Contact field is not filled correctly!");
        }
        public override void VerifyIfMealDescSectionIsSaved(string noMeal, string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments, string mealBreakfastIncluded)
        {
            //Meal Description assertions
            if (noMeal.Equals("Yes"))
            {
                Assert.AreEqual("Checked", Driver.FindElement(mealDescNoMealFieldSelector).GetAttribute("title"), "No Meal checkbox should be selected!");
            }
            else
            {
                Assert.AreEqual(mealType, Driver.FindElement(mealDescMealTypeFieldSelector).Text, "Meal Type field is Incorrect!");
                Assert.AreEqual(mealEstimatedCosts, Driver.FindElement(mealDescEstimatedCostsPerMealLabelSelector).Text, "Estimated costs per meal field is incorrect!");
                Assert.AreEqual(mealNumberOfMeals, Driver.FindElement(mealDescNumberOfMealsLabelSelector).Text, "Number of meals field is incorrect!");
                Assert.AreEqual(CurrencySplitString(mealCurrency, '('), Driver.FindElement(mealDescCurrencyLabelSelector).Text, "Meal Currency field is incorrect!");
                Assert.AreEqual(mealRestaurantName, Driver.FindElement(mealDescRestaurantNameLabelSelector).Text, "Restaurant Name field is incorrect!");
                Assert.AreEqual(mealComments, Driver.FindElement(mealDescAddCommentsLabelSelector).Text, "Additional comments field is incorrect!");

                //summary costs assertions
                Assert.IsNotNullOrEmpty(Driver.FindElement(mealDescSummaryCostLabelSelector).Text, "Summary costs field is empty!");
                Assert.IsNotNullOrEmpty(Driver.FindElement(mealDescCurrencySummaryCostsLabelSelector).Text, "Meal Currency Summary costs field is empty!");
            }
        }
        public override void VerifyIfOtherCostsSectionIsSaved(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
            //Other Costs assertions
            if (noOtherCosts.Equals("Yes"))
            {
                Assert.IsFalse(Driver.FindElements(othCostsCostTypeLabelSelector).Count() != 0, "Other costs section should be hidden when there are no other costs declared!");
            }
            else
            {
                Assert.AreEqual(otherCostsType, Driver.FindElement(othCostsCostTypeLabelSelector).Text, "Other costs Type field is Incorrect!");
                Assert.AreEqual(otherCostsAmount, Driver.FindElement(othCostsAmountLabelSelector).Text, "Other costs Amount field is incorrect!");
                Assert.AreEqual(CurrencySplitString(otherCostsCurrency, '('), Driver.FindElement(othCostsCurrencyLabelSelector).Text, "Other costs Currency field is incorrect!");
                Assert.AreEqual(otherCostsComment, Driver.FindElement(othCostsAddCommentsLabelSelector).Text, "Other costs Additional Comment field is incorrect!");
            }
        }

        /// <summary>
        /// Adding Notes & Attachments
        /// </summary>

        public override void AddNewNoteToForm()
        {
            Driver.FindElement(notesNewNoteButtonSelector).Click();
        }
        public override void AddNewAttachmentToForm()
        {
            Driver.FindElement(notesNewAttachmentButtonSelector).Click();
        }

        /// <summary>
        /// Adding Supporting Role
        /// </summary>

        public override void ClickAddSupportingRoleButton()
        {
            Driver.FindElement(suppRoleAddSupportingRoletButtonSelector).Click();
        }

        public void SendForVerification()
        {
            Driver.FindElement(topSendToEngagementOwnerForVerificationButtonSelector).Click();
        }

        public void ClickEditButton()
        {
            Driver.FindElement(topEditButtonSelector).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(topCancelButtonSelector).Click();
        }

        public override void SaveFormIDToConfig()
        {
            string HCPFormIDToStore = Driver.FindElement(infoHCPEngIDLabelSelector).Text;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["hcpFormID"].Value = HCPFormIDToStore;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
