using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Adding new Multiple HCP Form page and all actions that can be performed on it. 
    /// </summary>

    public class AddNewmHCPFormPageModel : AddNewHCPFormPageModel, IHasSaveButton, IHasCancelButton, IHasSmokeTest
    {
        //Line Manager selectors
        public static readonly By lineMgrLineManagerFieldSelector = By.XPath("//label[contains(text(),'Line Manager')]/../../../td[2]/span/input[@type='text']");
        public static readonly By lineMgrNameLookupButtonSelector = By.XPath("//label[contains(text(),'Line Manager')]/../../../td[2]/span/a");

        //Healthcare Professional Details selectors
        public static readonly By hcpDetailsOpenHCPListButtonSelector = By.XPath("//label[contains(text(),'HCP Country')]/../../../tr[3]/td[2]/input");
        public static readonly By hcpDetailsFirstNameLabelSelector = By.XPath("//td[contains(text(),'First Name')]/../td[4]/span");
        public static readonly By hcpDetailsLastNameLabelSelector = By.XPath("//td[contains(text(),'Last Name')]/../td[4]/span");
        //--Summary table details selectors
        public static readonly By hcpDetailsFullNameLabelSelector = By.XPath("//label[contains(text(),'HCP Country')]/../../../tr[5]/td/span/table/tbody/tr[1]/td[1]/a");
        public static readonly By hcpDetailsFullName2LabelSelector = By.XPath("//td[contains(text(),'HCP Country')]/../../tr[2]/td/span/table/tbody/tr[2]/td[1]/a");

        //Meal Description
        public static readonly By mealDescAddCommentsFieldSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[7]/textarea");

        //Other Costs
        public static readonly By othCostsAddCommentsFieldSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[5]/textarea");

        /// <summary>
        /// Constructor used when new object of current page is created for the first time. 
        /// </summary>
        public AddNewmHCPFormPageModel(IWebDriver driver)
            : base(driver, infoFormTypeLabelSelector)
        {
        }

        /// <summary>
        /// Used to verify if all locators are properly configured and page is ready for further testing.
        /// </summary>
        public void SmokeTest()
        {
            //Check for HCP Forms TAB
            Assert.True(Driver.FindElement(tabsHCPFormsButtonSelector).Displayed, "Smoke test failed. Object " + tabsHCPFormsButtonSelector + " cannot be found on page!");

            //Check for title and Save/Cancel buttons on page
            Assert.True(Driver.FindElement(newHCPEngagementMainTitle).Displayed, "Smoke test failed. Object " + newHCPEngagementMainTitle + " cannot be found on page!");
            Assert.True(Driver.FindElement(topSaveButtonSelector).Displayed, "Smoke test failed. Object " + topSaveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(topCancelButtonSelector).Displayed, "Smoke test failed. Object " + topCancelButtonSelector + " cannot be found on page!");

            //Information section assertions
            Assert.AreEqual(formStatusDraft, Driver.FindElement(infoStatusLabelSelector).Text, "Smoke test failed. Object " + infoStatusLabelSelector + " cannot be found on page!");
            Assert.AreEqual(formTypemHCP, Driver.FindElement(infoFormTypeLabelSelector).Text, "Smoke test failed. Object " + infoFormTypeLabelSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(infoHCPEngIDLabelSelector).Count() == 0, "Smoke test failed. Object " + infoHCPEngIDLabelSelector + " should not be set before first save!");
            Assert.True(Driver.FindElements(infoAccurateCompleteFieldSelector).Count() == 0, "Smoke test failed. Object " + infoAccurateCompleteFieldSelector + " should not be set before choosing engagement owner!");

            //Engagement owner assertions
            Assert.True(Driver.FindElement(engOwnerNameFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerNameFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerNameLookupButtonSelector).Displayed, "Smoke test failed. Object " + engOwnerNameLookupButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerNameMeLinkSelector).Displayed, "Smoke test failed. Object " + engOwnerNameMeLinkSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerRadioYesButtonSelector).Displayed, "Smoke test failed. Object " + engOwnerRadioYesButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerRadioNoButtonSelector).Displayed, "Smoke test failed. Object " + engOwnerRadioNoButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerJobTitleFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerJobTitleFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerDepartmentLabelSelector).Text == "", "Smoke test failed. Object " + engOwnerDepartmentLabelSelector + " should not be filled before choosing engagement owner!");
            Assert.True(Driver.FindElements(engOwnerEmailLabelSelector).Count() == 0, "Smoke test failed. Object " + engOwnerEmailLabelSelector + " should not be filled before choosing engagement owner!");
            Assert.True(Driver.FindElement(engOwnerPhoneDetailsLabelSelector).Text == " ", "Smoke test failed. Object " + engOwnerPhoneDetailsLabelSelector + " should not be filled before choosing engagement owner!");
            Assert.True(Driver.FindElement(engOwnerEngagementPaidAvailableFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerEngagementPaidAvailableFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerEngagementPaidAvailableOptionFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerEngagementPaidAvailableOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerEngagementPaidChosenFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerEngagementPaidChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(engOwnerEngagementPaidChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + engOwnerEngagementPaidChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(engOwnerEngagementPaidAddButtonSelector).Displayed, "Smoke test failed. Object " + engOwnerEngagementPaidAddButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerEngagementPaidRemoveButtonSelector).Displayed, "Smoke test failed. Object " + engOwnerEngagementPaidRemoveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerCountryLabelSelector).Text == "", "Smoke test failed. Object " + engOwnerCountryLabelSelector + " should not be filled before choosing engagement owner!");
            Assert.True(Driver.FindElement(engOwnerEmploymentTypeLabelSelector).Text == " ", "Smoke test failed. Object " + engOwnerEmploymentTypeLabelSelector + " should not be filled before choosing engagement owner!");
            Assert.True(Driver.FindElement(engOwnerFunctionFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerFunctionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engOwnerFunctionOptionFieldSelector).Displayed, "Smoke test failed. Object " + engOwnerFunctionOptionFieldSelector + " cannot be found on page!");

            //Line Manager assertions
            Assert.True(Driver.FindElement(lineMgrLineManagerFieldSelector).Displayed, "Smoke test failed. Object " + lineMgrLineManagerFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(lineMgrNameLookupButtonSelector).Displayed, "Smoke test failed. Object " + lineMgrNameLookupButtonSelector + " cannot be found on page!");

            //HCP Coordinator/Assistant Details assertions
            Assert.True(Driver.FindElement(hcpCoordNameFieldSelector).Displayed, "Smoke test failed. Object " + hcpCoordNameFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpCoordNameLookupButtonSelector).Displayed, "Smoke test failed. Object " + hcpCoordNameLookupButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpCoordNameMeLinkSelector).Displayed, "Smoke test failed. Object " + hcpCoordNameMeLinkSelector + " cannot be found on page!");

            //Healthcare Professional Details assertions
            Assert.True(Driver.FindElement(hcpDetailsCountryFieldSelector).Displayed, "Smoke test failed. Object " + hcpDetailsCountryFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(hcpDetailsOpenHCPListButtonSelector).Count() == 0, "Smoke test failed. Object " + hcpDetailsOpenHCPListButtonSelector + " should not be displayed on page!");

            //Product Information assertions
            Assert.True(Driver.FindElement(prodInfTherapeuticAreaFieldSelector).Displayed, "Smoke test failed. Object " + prodInfTherapeuticAreaFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfTherapeuticAreaOptionFieldSelector).Displayed, "Smoke test failed. Object " + prodInfTherapeuticAreaOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfTherapeuticAreaAddbuttonSelector).Displayed, "Smoke test failed. Object " + prodInfTherapeuticAreaAddbuttonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfTherapeuticAreaRemoveButtonFieldSelector).Displayed, "Smoke test failed. Object " + prodInfTherapeuticAreaRemoveButtonFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfTherapeuticAreaChosenFieldSelector).Displayed, "Smoke test failed. Object " + prodInfTherapeuticAreaChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(prodInfTherapeuticAreaChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + prodInfTherapeuticAreaChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(prodInfProductBrandMoleculeFieldSelector).Displayed, "Smoke test failed. Object " + prodInfProductBrandMoleculeFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfProductBrandMoleculeOptionFieldSelector).Displayed, "Smoke test failed. Object " + prodInfProductBrandMoleculeOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfProductBrandMoleculeAddbuttonSelector).Displayed, "Smoke test failed. Object " + prodInfProductBrandMoleculeAddbuttonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfProductBrandMoleculeRemoveButtonFieldSelector).Displayed, "Smoke test failed. Object " + prodInfProductBrandMoleculeRemoveButtonFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfProductBrandMoleculeChosenFieldSelector).Displayed, "Smoke test failed. Object " + prodInfProductBrandMoleculeChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(prodInfProductBrandMoleculeChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + prodInfProductBrandMoleculeChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(prodInfIndicationFieldSelector).Displayed, "Smoke test failed. Object " + prodInfIndicationFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfIndicationOptionFieldSelector).Displayed, "Smoke test failed. Object " + prodInfIndicationOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfIndicationAddButtonSelector).Displayed, "Smoke test failed. Object " + prodInfIndicationAddButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfIndicationRemoveButtonSelector).Displayed, "Smoke test failed. Object " + prodInfIndicationRemoveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(prodInfIndicationChosenFieldSelector).Displayed, "Smoke test failed. Object " + prodInfIndicationChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(prodInfIndicationChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + prodInfIndicationChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(prodInfProtocolNumberFieldSelector).Displayed, "Smoke test failed. Object " + prodInfProtocolNumberFieldSelector + " cannot be found on page!");

            //Engagement description assertions
            Assert.True(Driver.FindElement(engDescEngagementTitleFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTitleFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescCongressFieldSelector).Displayed, "Smoke test failed. Object " + engDescCongressFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescCongressOptionFieldSelector).Displayed, "Smoke test failed. Object " + engDescCongressOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementTypeFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTypeFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementTypeOptionFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTypeOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementTypeAddButtonSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTypeAddButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementTypeRemoveButtonSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTypeRemoveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementTypeChosenFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementTypeChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(engDescEngagementTypeChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + engDescEngagementTypeChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(engDescAllDayEngagementFieldSelector).Displayed, "Smoke test failed. Object " + engDescAllDayEngagementFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescStartDateFieldSelector).Displayed, "Smoke test failed. Object " + engDescStartDateFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEndDateFieldSelector).Displayed, "Smoke test failed. Object " + engDescEndDateFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementVenueFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementVenueFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementCityFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementCityFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementCountryFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementCountryFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementCountryOptionFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementCountryOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescScientificalMedicalBusinessNeedsFieldSelector).Displayed, "Smoke test failed. Object " + engDescScientificalMedicalBusinessNeedsFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescEngagementObjectivesFieldSelector).Displayed, "Smoke test failed. Object " + engDescEngagementObjectivesFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(engDescDescriptionFieldSelector).Displayed, "Smoke test failed. Object " + engDescDescriptionFieldSelector + " cannot be found on page!");

            //Affiliate Contact List assertions
            Assert.True(Driver.FindElement(affContAffiliateContactFieldSelector).Displayed, "Smoke test failed. Object " + affContAffiliateContactFieldSelector + " cannot be found on page!");

            //HCP Role in this activity assertions
            Assert.True(Driver.FindElement(hcpRoleHCPRoleFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleHCPRoleFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleHCPRoleOptionFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleHCPRoleOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleHCPRoleAddButtonSelector).Displayed, "Smoke test failed. Object " + hcpRoleHCPRoleAddButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleHCPRoleRemoveButtonSelector).Displayed, "Smoke test failed. Object " + hcpRoleHCPRoleRemoveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleHCPRoleChosenFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleHCPRoleChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(hcpRoleHCPRoleChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + hcpRoleHCPRoleChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(hcpRoleRationalForHCPFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleRationalForHCPFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleRationalForHCPOptionFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleRationalForHCPOptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleRationalForHCPAddButtonSelector).Displayed, "Smoke test failed. Object " + hcpRoleRationalForHCPAddButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleRationalForHCPRemoveButtonSelector).Displayed, "Smoke test failed. Object " + hcpRoleRationalForHCPRemoveButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(hcpRoleRationalForHCPChosenFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleRationalForHCPChosenFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(hcpRoleRationalForHCPChosenOptionFieldSelector).Count() == 0, "Smoke test failed. Object " + hcpRoleRationalForHCPChosenOptionFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElement(hcpRoleAreaOfExpertiseFieldSelector).Displayed, "Smoke test failed. Object " + hcpRoleAreaOfExpertiseFieldSelector + " cannot be found on page!");

            //Fee for service assertions
            Assert.True(Driver.FindElement(feeForServNoFeeForServiceFieldSelector).Displayed, "Smoke test failed. Object " + feeForServNoFeeForServiceFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServTotalActivityTimeFieldSelector).Displayed, "Smoke test failed. Object " + feeForServTotalActivityTimeFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServPostActivityTimeFieldSelector).Displayed, "Smoke test failed. Object " + feeForServPostActivityTimeFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServHourlyRateFieldSelector).Displayed, "Smoke test failed. Object " + feeForServHourlyRateFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServFlatRateFieldSelector).Displayed, "Smoke test failed. Object " + feeForServFlatRateFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector).Displayed, "Smoke test failed. Object " + feeForServTotalDisturbanceFeeDescriptionFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(feeForServCurrencyFieldSelector).Displayed, "Smoke test failed. Object " + feeForServCurrencyFieldSelector + " cannot be found on page!");
            Assert.AreEqual("0.00", Driver.FindElement(feeForServCalculatedTotalFieldSelector).Text, "Smoke test failed. Object " + feeForServCalculatedTotalFieldSelector + " is not set to 0.00!");

            //Accommodation Description assertions
            Assert.True(Driver.FindElement(accDescNoAccomodationFieldSelector).Displayed, "Smoke test failed. Object " + accDescNoAccomodationFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(accDescAddHotelButtonSelector).Displayed, "Smoke test failed. Object " + accDescAddHotelButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(accDescHotelNameFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescHotelNameFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescHotelNameLookupButtonSelector).Count() == 0, "Smoke test failed. Object " + accDescHotelNameLookupButtonSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescCostsPerNightFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescCostsPerNightFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescNumberOfNightsFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescNumberOfNightsFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescCurrencyFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescCurrencyFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescTotalCostPerHotelFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescTotalCostPerHotelFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescAddCommentFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescAddCommentFieldSelector + " should not be displayed on page!");
            //summmary cost subsection assertions
            Assert.True(Driver.FindElements(accDescSummaryCostFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescSummaryCostFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(accDescCurrencySummaryCostsFieldSelector).Count() == 0, "Smoke test failed. Object " + accDescCurrencySummaryCostsFieldSelector + " should not be displayed on page!");

            //Meal Description assertions
            Assert.True(Driver.FindElement(mealDescNoMealFieldSelector).Displayed, "Smoke test failed. Object " + mealDescNoMealFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(mealDescNewMealButtonSelector).Displayed, "Smoke test failed. Object " + mealDescNewMealButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(mealDescBreakfastIncludedSelector).Displayed, "Smoke test failed. Object " + mealDescBreakfastIncludedSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(mealDescMealTypeFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescMealTypeFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescEstimatedCostsPerMealSelector).Count() == 0, "Smoke test failed. Object " + mealDescEstimatedCostsPerMealSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescNumberOfMealsFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescNumberOfMealsFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescCurrencyFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescCurrencyFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescRestaurantNameFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescRestaurantNameFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescAddCommentsFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescAddCommentsFieldSelector + " should not be displayed on page!");
            //summmary cost subsection assertions
            Assert.True(Driver.FindElements(mealDescSummaryCostFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescSummaryCostFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(mealDescCurrencySummaryCostsFieldSelector).Count() == 0, "Smoke test failed. Object " + mealDescCurrencySummaryCostsFieldSelector + " should not be displayed on page!");

            //Travel Details assertions
            Assert.True(Driver.FindElement(travelDetNoTravelFieldSelector).Displayed, "Smoke test failed. Object " + travelDetNoTravelFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetNewTravelButtonSelector).Displayed, "Smoke test failed. Object " + travelDetNewTravelButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetTravelTypeFieldSelector).Displayed, "Smoke test failed. Object " + travelDetTravelTypeFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetCategoryFieldSelector).Displayed, "Smoke test failed. Object " + travelDetCategoryFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetEstimatedCostsFieldSelector).Displayed, "Smoke test failed. Object " + travelDetEstimatedCostsFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetCurrencyFieldSelector).Displayed, "Smoke test failed. Object " + travelDetCurrencyFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(travelDetDescriptionFieldSelector).Displayed, "Smoke test failed. Object " + travelDetDescriptionFieldSelector + " cannot be found on page!");

            //Other Costs assertions
            Assert.True(Driver.FindElement(othCostsNewCostButtonSelector).Displayed, "Smoke test failed. Object " + othCostsNewCostButtonSelector + " cannot be found on page!");
            Assert.True(Driver.FindElements(othCostsCostTypeFieldSelector).Count() == 0, "Smoke test failed. Object " + othCostsCostTypeFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(othCostsAmountFieldSelector).Count() == 0, "Smoke test failed. Object " + othCostsAmountFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(othCostsCurrencyFieldSelector).Count() == 0, "Smoke test failed. Object " + othCostsCurrencyFieldSelector + " should not be displayed on page!");
            Assert.True(Driver.FindElements(othCostsAddCommentsFieldSelector).Count() == 0, "Smoke test failed. Object " + othCostsAddCommentsFieldSelector + " should not be displayed on page!");

            //Local Requirements assertions
            Assert.True(Driver.FindElement(locReqCountryReqCheckFieldSelector).Displayed, "Smoke test failed. Object " + locReqCountryReqCheckFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(locReqReqSubmittedFieldSelector).Displayed, "Smoke test failed. Object " + locReqReqSubmittedFieldSelector + " cannot be found on page!");
            Assert.True(Driver.FindElement(locReqPleaseSpecifyFieldSelector).Displayed, "Smoke test failed. Object " + locReqPleaseSpecifyFieldSelector + " cannot be found on page!");
        }

        /// <summary>
        /// Fill in each section of the form
        /// </summary>

        public override void FillInInformationSection()
        {
            base.FillInInformationSection();
            Driver.FindElement(infoAccurateCompleteFieldSelector).Click();
        }
        public override void FillInMeAsEngagementOwner()
        {
            base.FillInMeAsEngagementOwner();
            Driver.FindElement(engOwnerNameMeLinkSelector).Click();
        }
        public override void FillInEngagementOwnerOther(string engOwnerName)
        {
            base.FillInEngagementOwnerOther(engOwnerName);
            //ClickNameLookupButton(engOwnerNameLookupButtonSelector);
            //SwitchToPopUp(engOwnerNameLookupButtonSelector);

            HandlePopup(
                            () => Driver.FindElement(engOwnerNameLookupButtonSelector).Click(),
                            () => UseAsPopup<NameLookupPageModel>().PerformNameLookup(engOwnerName)
                        );
        }
        public override void FillInEngagementOwnerDetailsSection(string globalFunction, string jobTitle, string engagementPaidBy, string engagementFunction)
        {
            base.FillInEngagementOwnerDetailsSection(globalFunction, jobTitle, engagementPaidBy, engagementFunction);

            //Name, Department, Phone, Email, Country fields appear. They should be the same as in user details.
            WaitForObject(engOwnerEmailLabelSelector);

            if (globalFunction.Equals("Yes"))
            {
                if (!Driver.FindElement(engOwnerRadioYesButtonSelector).Selected)
                {
                    Driver.FindElement(engOwnerRadioYesButtonSelector).Click();
                }
            }
            else if (globalFunction.Equals("No"))
            {
                if (!Driver.FindElement(engOwnerRadioNoButtonSelector).Selected)
                {
                    Driver.FindElement(engOwnerRadioNoButtonSelector).Click();
                }
            }

            SendKeysToElement(engOwnerJobTitleFieldSelector, jobTitle);
            ChooseAvailableElementFromList(engOwnerEngagementPaidAvailableFieldSelector, engOwnerEngagementPaidAddButtonSelector, engagementPaidBy);
            WaitForSaveToFinish(loadingIndicator);
            ChooseAvailableElementFromList(engOwnerFunctionFieldSelector, engagementFunction);
        }
        public override void FillInMeAsHCPCoordinator()
        {
            base.FillInMeAsHCPCoordinator();
            Driver.FindElement(hcpCoordNameMeLinkSelector).Click();
        }
        public override void FillInHCPCoordinatorOther(string hcpCoord)
        {
            base.FillInHCPCoordinatorOther(hcpCoord);

            //ClickNameLookupButton(hcpCoordNameLookupButtonSelector);
            //SwitchToPopUp(hcpCoordNameLookupButtonSelector);
            HandlePopup(
                            () => Driver.FindElement(hcpCoordNameLookupButtonSelector).Click(),
                            () => UseAsPopup<NameLookupPageModel>().PerformNameLookup(hcpCoord)
                        );
        }
        public override void FillInLineManagerOther(string lineManager)
        {
            base.FillInLineManagerOther(lineManager);

            //ClickNameLookupButton(lineMgrNameLookupButtonSelector);
            //SwitchToPopUp(lineMgrNameLookupButtonSelector);

            HandlePopup(
                            () => Driver.FindElement(lineMgrNameLookupButtonSelector).Click(),
                            () => UseAsPopup<NameLookupPageModel>().PerformNameLookup(lineManager)
                        );
        }
        public override void FillInHealthcareProfessionalDetailsSection(string hcpDetailsCountry)
        {
            base.FillInHealthcareProfessionalDetailsSection(hcpDetailsCountry);
            
            ChooseAvailableElementFromList(hcpDetailsCountryFieldSelector, hcpDetailsCountry);
            WaitForSaveToFinish(loadingIndicator);
            WaitForObject(hcpDetailsOpenHCPListButtonSelector);
        }
        public override void FillInProductInformationSection(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
            base.FillInProductInformationSection(therapeuticArea, productBrandMolecule, prodIndication, protocolNumber);
            
            ChooseAvailableElementFromList(prodInfTherapeuticAreaFieldSelector, prodInfTherapeuticAreaAddbuttonSelector, therapeuticArea);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(prodInfProductBrandMoleculeFieldSelector, prodInfProductBrandMoleculeAddbuttonSelector, productBrandMolecule);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(prodInfIndicationFieldSelector, prodInfIndicationAddButtonSelector, prodIndication);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(prodInfProtocolNumberFieldSelector, protocolNumber);
        }
        public override void FillInEngagementDescriptionSection(string engagementTitle, string engagementCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engagementDescription)
        {
            base.FillInEngagementDescriptionSection(engagementTitle, engagementCongress, engagementType, allDayEngagement, engagementVenue, engagementCity, engagementCountry, engagementStateProvince, sciMedBusNeeds, engagementObjective, contractedService, engagementDescription);
            
            SendKeysToElement(engDescEngagementTitleFieldSelector, engagementTitle);

            ChooseAvailableElementFromList(engDescCongressFieldSelector, engagementCongress);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(engDescEngagementTypeFieldSelector, engDescEngagementTypeAddButtonSelector, engagementType);
            WaitForSaveToFinish(loadingIndicator);

            if (allDayEngagement.Equals("Yes"))
            {
                Driver.FindElement(engDescAllDayEngagementFieldSelector).Click();
                WaitForSaveToFinish(loadingIndicator);
            }

            //MOVED TEMPORARY to FillDateAndClickSavesHCPEngagementButton() at the end of form because of javascript validation of dates which causes date to disappear.
            //We could not establish why this happens. Maybe difference between browser and actual driver server we use.

            //Driver.FindElement(engDescStartDateFieldSelector).Click();
            //Driver.FindElement(engDescStartDatePickerTodayLinkSelector).Click();
            //Driver.FindElement(engDescEndDateFieldSelector).Click();
            //Driver.FindElement(engDescEndDatePickerTodayLinkSelector).Click();
            //Driver.FindElement(engDescEngagementVenueFieldSelector).Click();

            SendKeysToElement(engDescEngagementVenueFieldSelector, engagementVenue);
            SendKeysToElement(engDescEngagementCityFieldSelector, engagementCity);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(engDescEngagementCountryFieldSelector, engagementCountry);
            WaitForSaveToFinish(loadingIndicator);

            switch (engagementCountry)
            {
                case "US":
                    WaitForObject(engDescEngagementStateProvinceFieldSelector);
                    ChooseAvailableElementFromList(engDescEngagementStateProvinceFieldSelector, engagementStateProvince);
                    break;
                case "Other":
                    WaitForObject(engDescEngagementOtherCountryFieldSelector);
                    SendKeysToElement(engDescEngagementOtherCountryFieldSelector, engagementStateProvince);
                    break;
                default:
                    break;
            }

            SendKeysToElement(engDescScientificalMedicalBusinessNeedsFieldSelector, sciMedBusNeeds);
            SendKeysToElement(engDescEngagementObjectivesFieldSelector, engagementObjective);

            if (contractedService.Equals("Yes"))
            {
                if (Driver.FindElement(engDescContractedRadioYesButtonSelector).Selected)
                {
                    //
                }
                else
                {
                    Driver.FindElement(engDescContractedRadioYesButtonSelector).Click();
                }
            }
            else if (contractedService.Equals("No"))
            {
                if (Driver.FindElement(engDescContractedRadioNoButtonSelector).Selected)
                {
                    SendKeysToElement(engDescDescriptionFieldSelector, engagementDescription);
                }
                else
                {
                    Driver.FindElement(engDescContractedRadioNoButtonSelector).Click();
                    SendKeysToElement(engDescDescriptionFieldSelector, engagementDescription);
                }
            }
        }
        public override void FillInAffiliateContactListSection(string affContact)
        {
            base.FillInAffiliateContactListSection(affContact);
            
            ChooseAvailableElementFromList(affContAffiliateContactFieldSelector, affContact);
        }
        public override void FillInHCPRoleSection(string hcpRoleSelect, string rationalForHcp, string areaOfExpertise)
        {
            base.FillInHCPRoleSection(hcpRoleSelect, rationalForHcp, areaOfExpertise);
            
            ChooseAvailableElementFromList(hcpRoleHCPRoleFieldSelector, hcpRoleHCPRoleAddButtonSelector, hcpRoleSelect);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(hcpRoleRationalForHCPFieldSelector, hcpRoleRationalForHCPAddButtonSelector, rationalForHcp);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(hcpRoleAreaOfExpertiseFieldSelector, areaOfExpertise);
        }
        public override void FillInNoFeeForServiceSection(string noFee)
        {
            base.FillInNoFeeForServiceSection(noFee);
            
            Driver.FindElement(feeForServNoFeeForServiceFieldSelector).Click();
            WaitForSaveToFinish(feeForServTotalActivityTimeFieldSelector);
        }
        public override void FillInFeeForServiceSection(string noFee, string totalActivityTime, string feePrepTime, string feeHourlyRate, string feeFlatRate, string feeTotalDisturbanceFee, string feeCurrency)
        {
            base.FillInFeeForServiceSection(noFee, totalActivityTime, feePrepTime, feeHourlyRate, feeFlatRate, feeTotalDisturbanceFee, feeCurrency);
            
            SendKeysToElement(feeForServTotalActivityTimeFieldSelector, loadingIndicator, totalActivityTime);
            Driver.FindElement(feeForServTotalActivityTimeFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(feeForServPostActivityTimeFieldSelector, loadingIndicator, feePrepTime);
            Driver.FindElement(feeForServPostActivityTimeFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            if (feeFlatRate.Equals("0.00"))
            {
                SendKeysToElement(feeForServHourlyRateFieldSelector, loadingIndicator, feeHourlyRate);
                Driver.FindElement(feeForServHourlyRateFieldSelector).SendKeys(Keys.Tab);
                WaitForSaveToFinish(loadingIndicator);
            }

            if (feeHourlyRate.Equals("0.00"))
            {
                SendKeysToElement(feeForServFlatRateFieldSelector, loadingIndicator, feeFlatRate);
                Driver.FindElement(feeForServFlatRateFieldSelector).SendKeys(Keys.Tab);
                WaitForSaveToFinish(loadingIndicator);
            }

            SendKeysToElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector, loadingIndicator, feeTotalDisturbanceFee);
            Driver.FindElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);
            ChooseAvailableElementFromList(feeForServCurrencyFieldSelector, feeCurrency);
        }
        public override void FillInNoAccommodationDescriptionSection(string noAccomodation)
        {
            base.FillInNoAccommodationDescriptionSection(noAccomodation);
            
            Driver.FindElement(accDescNoAccomodationFieldSelector).Click();
            WaitForSaveToFinish(accDescAddHotelButtonSelector);
        }
        public override void FillInAccomodationHotelSection(string accNameToLookup)
        {
            base.FillInAccomodationHotelSection(accNameToLookup);

            Driver.FindElement(accDescAddHotelButtonSelector).Click();
            WaitForObject(accDescHotelNameLookupButtonSelector);

            HandlePopup(
                            () => Driver.FindElement(accDescHotelNameLookupButtonSelector).Click(),
                            () => UseAsPopup<NameLookupPageModel>().PerformNameLookup(accNameToLookup)
                        );

            //ClickNameLookupButton(accDescHotelNameLookupButtonSelector);
            //SwitchToPopUp(accDescHotelNameLookupButtonSelector);
            //List<string> WindowHandles = new List<string>();
            //do
            //{
            //    WindowHandles = Driver.WindowHandles.ToList();
            //} while (WindowHandles.Count() != 2);

            //Driver.SwitchTo().Window(WindowHandles[1]);


        }
        public override void FillInAccommodationDescriptionSection(string accCostsPerNight, string accNrOfNights, string accCurrency, string accDescription)
        {
            base.FillInAccommodationDescriptionSection(accCostsPerNight, accNrOfNights, accCurrency, accDescription);
            
            SendKeysToElement(accDescCostsPerNightFieldSelector, loadingIndicator, accCostsPerNight);
            Driver.FindElement(accDescCostsPerNightFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            //Ajax calls cause problems sometimes with accDescCostsPerNightFieldSelector field 
            //and it saves 0.00 value instead of intended, hence wait time.
            SecondsToWait(4);

            SendKeysToElement(accDescNumberOfNightsFieldSelector, loadingIndicator, accNrOfNights);
            Driver.FindElement(accDescNumberOfNightsFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(accDescCurrencyFieldSelector, accCurrency);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(accDescAddCommentFieldSelector, accDescription);
        }
        public override void FillInNoMealDescriptionSection(string noMeal)
        {
            base.FillInNoAccommodationDescriptionSection(noMeal);

            Driver.FindElement(mealDescNoMealFieldSelector).Click();
            WaitForSaveToFinish(mealDescNewMealButtonSelector);
        }
        public override void FillInMealBreakfastIncluded()
        {
            base.FillInMealBreakfastIncluded();
            if (Driver.FindElements(mealDescBreakfastIncludedSelector).Count() != 0)
            {
                Driver.FindElement(mealDescBreakfastIncludedSelector).Click();
                WaitForSaveToFinish(loadingIndicator);
            }
        }
        public override void FillInMealDescriptionSection(string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments)
        {
            base.FillInMealDescriptionSection(mealType, mealEstimatedCosts, mealNumberOfMeals, mealCurrency, mealRestaurantName, mealComments);
            
            Driver.FindElement(mealDescNewMealButtonSelector).Click();
            WaitForObject(mealDescAddCommentsFieldSelector);
            ChooseAvailableElementFromList(mealDescMealTypeFieldSelector, mealType);

            SendKeysToElement(mealDescEstimatedCostsPerMealSelector, loadingIndicator, mealEstimatedCosts);
            Driver.FindElement(mealDescEstimatedCostsPerMealSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(mealDescNumberOfMealsFieldSelector, loadingIndicator, mealNumberOfMeals);
            Driver.FindElement(mealDescNumberOfMealsFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            ChooseAvailableElementFromList(mealDescCurrencyFieldSelector, mealCurrency);
            Driver.FindElement(mealDescCurrencyFieldSelector).SendKeys(Keys.Tab);
            WaitForSaveToFinish(loadingIndicator);

            SendKeysToElement(mealDescRestaurantNameFieldSelector, mealRestaurantName);
            SendKeysToElement(mealDescAddCommentsFieldSelector, mealComments);
        }
        public override void FillInNoTravelDetailsSection(string noTravel)
        {
            base.FillInNoTravelDetailsSection(noTravel);
            
            Driver.FindElement(travelDetNoTravelFieldSelector).Click();
            WaitForSaveToFinish(travelDetTravelTypeFieldSelector);
        }
        public override void FillInTravelDetailsSection(string travelType, string travelCategory, string travelEstimatedCosts, string travelCurrency, string travelDescription)
        {
            base.FillInTravelDetailsSection(travelType, travelCategory, travelEstimatedCosts, travelCurrency, travelDescription);
            
            if (travelType != "Flight")
            {
                ChooseAvailableElementFromList(travelDetTravelTypeFieldSelector, travelType);
                WaitForSaveToFinish(loadingIndicator);
            }

            ChooseAvailableElementFromList(travelDetCategoryFieldSelector, travelCategory);
            SendKeysToElement(travelDetEstimatedCostsFieldSelector, travelEstimatedCosts);
            ChooseAvailableElementFromList(travelDetCurrencyFieldSelector, travelCurrency);
            SendKeysToElement(travelDetDescriptionFieldSelector, travelDescription);
        }
        public override void FillInOtherCostsSection(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
            base.FillInOtherCostsSection(noOtherCosts, otherCostsType, otherCostsAmount, otherCostsCurrency, otherCostsComment);
            
            Driver.FindElement(othCostsNewCostButtonSelector).Click();
            WaitForObject(othCostsCostTypeFieldSelector);
            SendKeysToElement(othCostsCostTypeFieldSelector, otherCostsType);
            SendKeysToElement(othCostsAmountFieldSelector, otherCostsAmount);
            ChooseAvailableElementFromList(othCostsCurrencyFieldSelector, otherCostsCurrency);
            SendKeysToElement(othCostsAddCommentsFieldSelector, otherCostsComment);
        }
        public override void FillInLocalRequirementsFullfilled(string locReqCheck)
        {
            base.FillInLocalRequirementsFullfilled(locReqCheck);
            
            WaitForSaveToFinish(loadingIndicator);
            Driver.FindElement(locReqCountryReqCheckFieldSelector).Click();
        }
        public override void FillInLocalRequirementsSection(string locReqSubmitted, string locReqSpecify)
        {
            base.FillInLocalRequirementsSection(locReqSubmitted, locReqSpecify);
            
            ChooseAvailableElementFromList(locReqReqSubmittedFieldSelector, locReqSubmitted);
            SendKeysToElement(locReqPleaseSpecifyFieldSelector, locReqSpecify);
        }

        /// <summary>
        /// Verify if each section was filled correctly
        /// </summary>

        public override void VerifyInformationSectionIsFilled()
        {
            //Information section assertions
            Assert.True(Driver.FindElement(infoAccurateCompleteFieldSelector).Selected, "Accurate Complete checkbox should be selected before validation !");
        }
        public override void VerifyEngagementOwnerSectionIsFilled(string engOwnerName, string globalFunction, string jobTitle, string engagementPaidBy, string engagementFunction)
        {
            //Engagement owner section assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerNameFieldSelector).GetAttribute("value"), "Name field is empty!");
            Assert.AreEqual(jobTitle, Driver.FindElement(engOwnerJobTitleFieldSelector).GetAttribute("value"), "Job Title field is incorrect!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerDepartmentLabelSelector).Text, "Department field is empty. Check if department field is set in user details!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerEmailLabelSelector).Text, "Email field is empty. Check if email field is set in user details!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerPhoneDetailsLabelSelector).Text, "Phone field is empty. Check if phone field is set in user details!");
            Assert.AreEqual(engagementPaidBy, Driver.FindElement(engOwnerEngagementPaidChosenOptionFieldSelector).Text, "Smoke test failed. Object cannot be found on page!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engOwnerCountryLabelSelector).Text, "Country field is empty. Check if country field is set in user details!");
            Assert.AreEqual(engagementFunction, Driver.FindElement(engOwnerFunctionFieldSelector).GetAttribute("value"), "Function field is incorrect!");
        }
        public override void VerifyHCPCoordinatorSectionIsFilled(string hcpCoordinator)
        {
            //HCP Coordinator/Assistant Details assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(hcpCoordNameFieldSelector).GetAttribute("value"), "HCP Coordinator Section is filled incorrectly!");
        }
        public override void VerifyLineManagerSectionIsFilled(string lineManager)
        {
            //Line Manager assertions
            Assert.IsNotNullOrEmpty(Driver.FindElement(lineMgrLineManagerFieldSelector).GetAttribute("value"), "Line Manager Section is filled incorrectly!");
        }
        public override void VerifyHealthcareProfessionalDetailsSectionIsFilled(string hcpDetailsCountry, string hcpFirstName, string hcpLastName)
        {
            // TO DO : Asserting second HCP chosen instead of just first
            Assert.IsNotNullOrEmpty(Driver.FindElement(hcpDetailsFullNameLabelSelector).Text, "HCP First Name field is incorrect!");
        }
        public override void VerifyProductInformationSectionIsFilled(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
            //Product Information assertions
            Assert.AreEqual(therapeuticArea, Driver.FindElement(prodInfTherapeuticAreaChosenOptionFieldSelector).Text, "Therapeutic Area does not have chosen item on list!");
            Assert.AreEqual(productBrandMolecule, Driver.FindElement(prodInfProductBrandMoleculeChosenOptionFieldSelector).Text, "Product/Brand/Molecule does not have chosen item on list!");
            Assert.AreEqual(prodIndication, Driver.FindElement(prodInfIndicationChosenOptionFieldSelector).Text, "Indication does not have chosen item on list!");
            Assert.AreEqual(protocolNumber, Driver.FindElement(prodInfProtocolNumberFieldSelector).GetAttribute("value"), "Protocol number field has incorrect value!");
        }
        public override void VerifyEngagementDescriptionSectionIsFilled(string engagementTitle, string engagementCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engagementDescription)
        {
            //Engagement description assertions
            Assert.AreEqual(engagementTitle, Driver.FindElement(engDescEngagementTitleFieldSelector).Text, "Engagement Title field has incorrect value!");
            Assert.AreEqual(engagementCongress, Driver.FindElement(engDescCongressFieldSelector).GetAttribute("value"), "Congress field does not contain any value!");
            Assert.AreEqual(engagementType, Driver.FindElement(engDescEngagementTypeChosenOptionFieldSelector).Text, "Engagement Type Chosen field does not contain any value!");
            Assert.AreEqual(sciMedBusNeeds, Driver.FindElement(engDescScientificalMedicalBusinessNeedsFieldSelector).GetAttribute("value"), "Scientific Medical Business needs field is not filled correctly!");
            Assert.AreEqual(engagementObjective, Driver.FindElement(engDescEngagementObjectivesFieldSelector).GetAttribute("value"), "Engagement Objectives field is not filled correctly!");
            Assert.AreEqual(engagementVenue, Driver.FindElement(engDescEngagementVenueFieldSelector).Text, "Engagement Venue field is not filled correctly!");
            Assert.AreEqual(engagementCity, Driver.FindElement(engDescEngagementCityFieldSelector).GetAttribute("value"), "Engagement City field is not filled correctly!");
            Assert.IsNotNullOrEmpty(Driver.FindElement(engDescEngagementCountryFieldSelector).GetAttribute("value"), "Engagement Country field is not filled correctly!");

            if (allDayEngagement.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(engDescAllDayEngagementFieldSelector).Selected, "All Day Engagement should be selected!");
            }

            switch (engagementStateProvince)
            {
                case "US":
                    Assert.AreEqual(engagementStateProvince, Driver.FindElement(engDescEngagementStateProvinceFieldSelector).GetAttribute("value"), "Engagement State/Province field is not filled correctly!");
                    break;
                case "Other":
                    Assert.AreEqual(engagementStateProvince, Driver.FindElement(engDescEngagementOtherCountryFieldSelector).GetAttribute("value"), "Other Country field is not filled correctly!");
                    break;
                default:
                    break;
            }

            if (contractedService.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(engDescContractedRadioYesButtonSelector).Selected, "Part of Contracted service YES option should be selected!");
            }
            else
            {
                Assert.True(Driver.FindElement(engDescContractedRadioNoButtonSelector).Selected, "Part of Contracted service NO option should be selected!");
                Assert.AreEqual(engagementDescription, Driver.FindElement(engDescDescriptionFieldSelector).GetAttribute("value"), "Description field is not filled correctly!");
            }
        }
        public override void VerifyAffiliateContactSectionIsFilled(string affContact)
        {
            //Affiliate Contact List assertions
            Assert.IsNotNullOrEmpty(affContact, Driver.FindElement(affContAffiliateContactFieldSelector).GetAttribute("value"), "Affiliate Contact field is not filled correctly!");
        }
        public override void VerifyHCPRoleSectionIsFilled(string hcpRoleSelect, string rationalForHcp, string areaOfExpertise)
        {
            //HCP Role in this activity assertions
            Assert.AreEqual(hcpRoleSelect, Driver.FindElement(hcpRoleHCPRoleChosenOptionFieldSelector).Text, "HCP Role field is not filled correctly!");
            Assert.AreEqual(rationalForHcp, Driver.FindElement(hcpRoleRationalForHCPChosenOptionFieldSelector).Text, "Rational For HCP field is not filled correctly!");
            Assert.AreEqual(areaOfExpertise, Driver.FindElement(hcpRoleAreaOfExpertiseFieldSelector).GetAttribute("value"), "Area of Expertise field is not filled correctly!");
        }
        public override void VerifyFeeForServiceSectionIsFilled(string noFee, string totalActivityTime, string feePrepTime, string feeHourlyRate, string feeFlatRate, string feeTotalDisturbanceFee, string feeCurrency)
        {
            //Fee for service assertions
            if (noFee.Equals("Yes"))
            {
                Assert.IsTrue(Driver.FindElement(feeForServNoFeeForServiceFieldSelector).Selected, "No Fee checkbox should be selected!");
            }
            else
            {
                Assert.AreEqual(totalActivityTime, Driver.FindElement(feeForServTotalActivityTimeFieldSelector).GetAttribute("value"), "Total activity time is not filled correctly!");
                Assert.AreEqual(feePrepTime, Driver.FindElement(feeForServPostActivityTimeFieldSelector).GetAttribute("value"), "Post Activity Time field is not filled correctly!");
                Assert.AreEqual(feeTotalDisturbanceFee, Driver.FindElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector).GetAttribute("value"), "Total Disturbance Fee field is not filled correctly!");
                Assert.AreEqual(CurrencySplitString(feeCurrency, '('), Driver.FindElement(feeForServCurrencyFieldSelector).GetAttribute("value"), "Currency field is not filled correctly!");

                double TotalField = 0.00;

                if (feeFlatRate.Equals("0.00"))
                {
                    Assert.AreEqual(feeHourlyRate, Driver.FindElement(feeForServHourlyRateFieldSelector).GetAttribute("value"), "Hourly Rate field is not filled correctly!");
                    TotalField = (double.Parse(Driver.FindElement(feeForServTotalActivityTimeFieldSelector).GetAttribute("value"))
                                + double.Parse(Driver.FindElement(feeForServPostActivityTimeFieldSelector).GetAttribute("value")))
                                * double.Parse(Driver.FindElement(feeForServHourlyRateFieldSelector).GetAttribute("value"))
                                + double.Parse(Driver.FindElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector).GetAttribute("value"));
                }

                if (feeHourlyRate.Equals("0.00"))
                {
                    Assert.AreEqual(feeFlatRate, Driver.FindElement(feeForServFlatRateFieldSelector).GetAttribute("value"), "Flat Rate field is not filled correctly!");
                    TotalField = (double.Parse(Driver.FindElement(feeForServTotalActivityTimeFieldSelector).GetAttribute("value"))
                                + double.Parse(Driver.FindElement(feeForServPostActivityTimeFieldSelector).GetAttribute("value")))
                                * double.Parse(Driver.FindElement(feeForServHourlyRateFieldSelector).GetAttribute("value"))
                                + double.Parse(Driver.FindElement(feeForServTotalDisturbanceFeeDescriptionFieldSelector).GetAttribute("value"));
                }

                Assert.AreEqual(TotalField.ToString("0.00"), Driver.FindElement(feeForServCalculatedTotalFieldSelector).Text, "CalculatedTotal cost has been incorrectly calculated.");
            }
        }
        public override void VerifyAccomodationSectionIsFilled(string noAccomodation, string accNameToLookup, string accCostsPerNight, string accNrOfNights, string accCurrency, string accDescription)
        {
            //Accommodation Description assertions
            if (noAccomodation.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(accDescNoAccomodationFieldSelector).Selected, "No Accomodation checkbox should be selected!");
                Assert.IsFalse(Driver.FindElements(mealDescBreakfastIncludedSelector).Count != 0, "Breakfast included checkbox should be hidden when there is no accomodation checkbox selected!");
            }
            else
            {
                Assert.IsNotNullOrEmpty(Driver.FindElement(accDescHotelNameFieldSelector).GetAttribute("value"), "Hotel name field is empty!");
                Assert.AreEqual(accCostsPerNight, Driver.FindElement(accDescCostsPerNightFieldSelector).GetAttribute("value"), "Costs per night field is incorrect!");
                Assert.AreEqual(accNrOfNights, Driver.FindElement(accDescNumberOfNightsFieldSelector).GetAttribute("value"), "Number of nights field is incorrect!");
                Assert.AreEqual(CurrencySplitString(accCurrency, '('), Driver.FindElement(accDescCurrencyFieldSelector).GetAttribute("value"), "Accomodation Currency field is incorrect!");
                Assert.AreEqual(accDescription, Driver.FindElement(accDescAddCommentFieldSelector).GetAttribute("value"), "Additional description field is incorrect!");

                //summmary cost subsection assertions
                Assert.IsNotNullOrEmpty(Driver.FindElement(accDescSummaryCostFieldSelector).Text, "Summary costs field is empty!");
                Assert.IsNotNullOrEmpty(Driver.FindElement(accDescCurrencySummaryCostsFieldSelector).Text, "Currency field is empty!");
            }
        }
        public override void VerifyMealSectionIsFilled(string noMeal, string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments, string breakfastIncluded)
        {
            //Meal Description assertions
            if (noMeal.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(mealDescNoMealFieldSelector).Selected, "No Meal checkbox should be selected!");
            }
            else
            {
                if (breakfastIncluded.Equals("Yes"))
                {
                    //Assert.True(Driver.FindElement(mealDescBreakfastIncludedSelector).Selected, "Breakfast included checkbox should be selected!");
                }

                Assert.AreEqual(mealType, Driver.FindElement(mealDescMealTypeFieldSelector).GetAttribute("value"), "Meal Type field is Incorrect!");
                Assert.AreEqual(mealEstimatedCosts, Driver.FindElement(mealDescEstimatedCostsPerMealSelector).GetAttribute("value"), "Estimated costs per meal field is incorrect!");
                Assert.AreEqual(mealNumberOfMeals, Driver.FindElement(mealDescNumberOfMealsFieldSelector).GetAttribute("value"), "Number of meals field is incorrect!");
                Assert.AreEqual(CurrencySplitString(mealCurrency, '('), Driver.FindElement(mealDescCurrencyFieldSelector).GetAttribute("value"), "Meal Currency field is incorrect!");
                Assert.AreEqual(mealRestaurantName, Driver.FindElement(mealDescRestaurantNameFieldSelector).GetAttribute("value"), "Restaurant Name field is incorrect!");
                Assert.AreEqual(mealComments, Driver.FindElement(mealDescAddCommentsFieldSelector).GetAttribute("value"), "Additional comments field is incorrect!");

                //summary costs assertions
                Assert.IsNotNullOrEmpty(Driver.FindElement(mealDescSummaryCostFieldSelector).Text, "Summary costs field is empty!");
                Assert.IsNotNullOrEmpty(Driver.FindElement(mealDescCurrencySummaryCostsFieldSelector).Text, "Meal Currency Summary costs field is empty!");
            }
        }
        public override void VerifyTravelDetailsSectionIsFilled(string noTravel, string travelType, string travelCategory, string travelEstimatedCosts, string travelCurrency, string travelDescription)
        {
            //Travel Details assertions
            if (noTravel.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(AddNewHCPFormPageModel.travelDetNoTravelFieldSelector).Displayed, "No Travel checkbox should be selected!");
            }
            else
            {
                Assert.AreEqual(travelType, Driver.FindElement(travelDetTravelTypeFieldSelector).GetAttribute("value"), "Travel Type field is Incorrect!");
                Assert.AreEqual(travelCategory, Driver.FindElement(travelDetCategoryFieldSelector).GetAttribute("value"), "Travel Category field is incorrect!");
                Assert.AreEqual(travelEstimatedCosts, Driver.FindElement(travelDetEstimatedCostsFieldSelector).GetAttribute("value"), "Travel Estimated costs field is incorrect!");
                Assert.AreEqual(CurrencySplitString(travelCurrency, '('), Driver.FindElement(travelDetCurrencyFieldSelector).GetAttribute("value"), "Travel Currency field is incorrect!");
                Assert.AreEqual(travelDescription, Driver.FindElement(travelDetDescriptionFieldSelector).GetAttribute("value"), "Travel Description field is incorrect!");
            }
        }
        public override void VerifyOtherCostsSectionIsFilled(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
            //Other Costs assertions
            if (noOtherCosts.Equals("Yes"))
            {
                Assert.IsFalse(Driver.FindElements(othCostsCostTypeFieldSelector).Count() != 0, "Other costs section should be hidden when there are no other costs declared!");
            }
            else
            {
                Assert.AreEqual(otherCostsType, Driver.FindElement(othCostsCostTypeFieldSelector).GetAttribute("value"), "Other costs Type field is Incorrect!");
                Assert.AreEqual(otherCostsAmount, Driver.FindElement(othCostsAmountFieldSelector).GetAttribute("value"), "Other costs Amount field is incorrect!");
                Assert.AreEqual(CurrencySplitString(otherCostsCurrency, '('), Driver.FindElement(othCostsCurrencyFieldSelector).GetAttribute("value"), "Other costs Currency field is incorrect!");
                Assert.AreEqual(otherCostsComment, Driver.FindElement(othCostsAddCommentsFieldSelector).GetAttribute("value"), "Other costs Additional Comment field is incorrect!");
            }
        }
        public override void VerifyLocalRequirementsSectionIsFilled(string locReqCheck, string locReqSubmitted, string locReqSpecify)
        {
            //Local Requirements assertions
            if (locReqCheck.Equals("Yes"))
            {
                Assert.True(Driver.FindElement(locReqCountryReqCheckFieldSelector).Selected, "Local requirements checked should be selected!");
            }

            Assert.AreEqual(locReqSubmitted, Driver.FindElement(locReqReqSubmittedFieldSelector).GetAttribute("value"), "Local requirements submitted field is filled incorrectly!");
            Assert.AreEqual(locReqSpecify, Driver.FindElement(locReqPleaseSpecifyFieldSelector).GetAttribute("value"), "Please specify field is filled incorrectly!");
        }

        public override void ClickOPenAddHCPListForSelection()
        {
            Driver.FindElement(hcpDetailsOpenHCPListButtonSelector).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(topCancelButtonSelector).Click();
        }
        public void ClickSaveButton()
        {
            Driver.FindElement(topSaveButtonSelector).Click();
        }
        public override void ClickSaveFormButton()
        {
            //Because date has incorrect validation which causes it to disappear sometimes date filling needs to be last operation on page before save.
            Driver.FindElement(engDescStartDateFieldSelector).Click();
            Driver.FindElement(engDescStartDatePickerTodayLinkSelector).Click();
            Driver.FindElement(engDescEndDateFieldSelector).Click();
            Driver.FindElement(engDescEndDatePickerTodayLinkSelector).Click();
            //

            Driver.FindElement(topSaveButtonSelector).Click();
        }
    }
}