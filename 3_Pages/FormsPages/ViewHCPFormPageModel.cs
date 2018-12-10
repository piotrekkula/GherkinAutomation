using OpenQA.Selenium;

namespace GherkinAutomation.Pages
{
    public class ViewHCPFormPageModel : PageModel
    {
        //Button selectors
        public static readonly By topGeneratePDFButtonSelector = By.XPath("//input[@value='Edit']/../input[@value='Generate PDF']");
        public static readonly By topEditButtonSelector = By.XPath("//input[@value='Cancel']/../input[@value='Edit']");
        public static readonly By topCancelButtonSelector = By.XPath("//input[@value='Save']/../input[@value='Cancel']");
        public static readonly By topCloneButtonSelector = By.XPath("//input[@value='Cancel']/../td[2]/input[@value='Clone']");
        public static readonly By topSendUpdatedFormButtonSelector = By.XPath("//input[@value='Send Updated Form']");
        public static readonly By topSendToEngagementOwnerForVerificationButtonSelector = By.XPath("//input[@value='Send to engagement owner for verification']");

        //Success validation selectors
        public static readonly By successMessageLabelSelector = By.XPath("//img[@alt='CONFIRM']/../../td[2]/div/span/h4[contains(text(),'Success')]");

        //Information section selectors
        public static readonly By infoStatusLabelSelector = By.XPath("//td[contains(text(),'Status')]/../td[2]/span");
        public static readonly By infoHCPEngIDLabelSelector = By.XPath("//td[contains(text(),'HCP Engagement ID')]/../td[4]/span");
        public static readonly By infoAccurateCompleteFieldSelector = By.XPath("//td[contains(text(),'I certify that the information')]/../td[2]/span/img");
        public static readonly By infoFormTypeLabelSelector = By.XPath("//td[contains(text(),'I certify that the information')]/../td[4]/span");

        //Engagement owner section selectors
        public static readonly By engOwnerNameLabelSelector = By.XPath("//h3[contains(text(),'Engagement Owner Details')]/../../div[2]/table/tbody/tr[1]/td[2]/span");
        public static readonly By engOwnerRadioYesButtonSelector = By.XPath("//label[contains(text(),'Global Function')]/../../td[4]/table/tbody/tr/td[1]/input");
        public static readonly By engOwnerRadioNoButtonSelector = By.XPath("//label[contains(text(),'Global Function')]/../../td[4]/table/tbody/tr/td[2]/input");
        public static readonly By engOwnerJobTitleLabelSelector = By.XPath("//td[contains(text(),'Job Title')]/../td[2]/span");
        public static readonly By engOwnerDepartmentLabelSelector = By.XPath("//label[contains(text(),'Department')]/../../td[4]/span");
        public static readonly By engOwnerEmailLabelSelector = By.XPath("//label[contains(text(),'Department')]/../../../tr[3]/td[2]/span/a");
        public static readonly By engOwnerPhoneDetailsLabelSelector = By.XPath("//h3[contains(text(),'Engagement Owner Details')]/../../div[2]/table/tbody/tr[3]/td[4]/span");
        public static readonly By engOwnerEngagementPaidByLabelSelector = By.XPath("//label[contains(text(),'Engagement Paid')]/../../td[2]/span");
        public static readonly By engOwnerCountryLabelSelector = By.XPath("//h3[contains(text(),'Engagement Owner Details')]/../../div[2]/table/tbody/tr[5]/td[2]/span");
        //public static readonly By engOwnerEmploymentTypeLabelSelector = By.XPath("page:form:pb1:j_id93:j_id111");
        public static readonly By engOwnerFunctionLabelSelector = By.XPath("//td[contains(text(),'Function')]/../td[2]/span");

        //HCP Coordinator/Assistant Details section selectors
        public static readonly By hcpCoordNameLabelSelector = By.XPath("//h3[contains(text(),'HCP Coordinator')]/../../../div[3]/div[2]/table/tbody/tr[1]/td[2]/span");

        //Line Manager section selectors
        public static readonly By lineMgrLineManagerLabelSelector = By.XPath("//label[contains(text(),'Line Manager')]/../../td[2]/span");

        //Product Information section selectors
        public static readonly By prodInfTherapeuticAreaLabelSelector = By.XPath("//td[contains(text(),'Therapeutic Area')]/../td[2]/span");
        public static readonly By prodInfProductBrandMoleculeLabelSelector = By.XPath("//label[contains(text(),'Product(s) / Brand')]/../../td[2]/span");
        public static readonly By prodInfIndicationLabelSelector = By.XPath("//td[contains(text(),'Indication')]/../td[2]/span");

        //Engagement description section selectors
        public static readonly By engDescEngagementTitleLabelSelector = By.XPath("//label[contains(text(),'Engagement Title')]/../../td[2]/span");
        public static readonly By engDescCongressLabelSelector = By.XPath("//td[contains(text(),'Congress')]/../td[4]/span");
        public static readonly By engDescEngagementTypeLabelSelector = By.XPath("//td[contains(text(),'Engagement Type')]/../td[2]/span");
        public static readonly By engDescAllDayEngagementLabelSelector = By.XPath("//td[contains(text(),'All Day Engagement')]/../td[2]/span/img");
        public static readonly By engDescStartDateLabelSelector = By.XPath("//td[contains(text(),'Start Date')]/../td[2]");
        public static readonly By engDescEndDateLabelSelector = By.XPath("//td[contains(text(),'End Date')]/../td[4]");
        public static readonly By engDescEngagementVenueLabelSelector = By.XPath("//td[contains(text(),'Engagement Venue')]/../td[2]/span");
        public static readonly By engDescEngagementCityLabelSelector = By.XPath("//td[contains(text(),'Engagement City')]/../td[2]/span");
        public static readonly By engDescEngagementCountryLabelSelector = By.XPath("//label[contains(text(),'Engagement Country')]/../../td[2]/span");
        public static readonly By engDescEngagementStateProvinceFieldSelector = By.XPath("//td[contains(text(),'Engagement State')]/../td[2]/span");
        public static readonly By engDescEngagementOtherCountryFieldSelector = By.XPath("//td[contains(text(),'Engagement Other Country')]/../td[2]/span");
        public static readonly By engDescScientificalMedicalBusinessNeedsLabelSelector = By.XPath("//label[contains(text(),'Scientific/Medical/Business')]/../../td[2]/span");
        public static readonly By engDescEngagementObjectivesLabelSelector = By.XPath("//label[contains(text(),'Engagement Objectives')]/../../td[4]/span");
        public static readonly By engDescContractedRadioYesButtonSelector = By.XPath("//label[contains(text(),'Is this engagement part of or will be part of')]/../../../td[2]/table/tbody/tr/td[1]/input");
        public static readonly By engDescContractedRadioNoButtonSelector = By.XPath("//label[contains(text(),'Is this engagement part of or will be part of')]/../../../td[2]/table/tbody/tr/td[2]/input");
        public static readonly By engDescDescriptionLabelSelector = By.XPath("//label[contains(text(),'Engagement part of Contracted')]/../../../td[2]/span");

        //Affiliate Contact List section selectors
        public static readonly By affContAffiliateContactLabelSelector = By.XPath("//span[contains(text(),'Primary Person')]/../../td[2]/span/a");

        //HCP Role in this activity section selectors
        public static readonly By hcpRoleHCPRoleLabelSelector = By.XPath("//td[contains(text(),'HCP Role in this activity')]/../td[2]/span");
        public static readonly By hcpRoleRationalForHCPLabelSelector = By.XPath("//td[contains(text(),'Rational for HCP selection')]/../td[2]/span");
        public static readonly By hcpRoleAreaOfExpertiseLabelSelector = By.XPath("//label[contains(text(),'Specify area of expertise and how it links')]/../../../td[2]/span");

        //Fee for service section selectors
        public static readonly By feeForServNoFeeForServiceLabelSelector = By.XPath("//td[contains(text(),'No fee for service')]/../td[2]/span/img");
        public static readonly By feeForServTotalActivityTimeLabelSelector = By.XPath("//label[contains(text(),'Total activity time')]/../../../td[2]/span");
        public static readonly By feeForServPostActivityTimeLabelSelector = By.XPath("//td[contains(text(),'Preparation/post activity')]/../td[2]/span");
        public static readonly By feeForServHourlyRateLabelSelector = By.XPath("//td[contains(text(),'Hourly rate')]/../td[2]/span");
        public static readonly By feeForServFlatRateLabelSelector = By.XPath("//label[contains(text(),'Flat Rate')]/../../../td[2]/span");
        public static readonly By feeForServTotalDisturbanceFeeDescriptionLabelSelector = By.XPath("//label[contains(text(),'Total Disturbance Fee')]/../../../td[2]/span");
        public static readonly By feeForServCurrencyLabelSelector = By.XPath("//label[contains(text(),'Currency')]/../../../td[2]/span");
        public static readonly By feeForServCalculatedTotalLabelSelector = By.XPath("//td[contains(text(),'Calculated Total')]/../td[2]/span");

        //Accommodation Description section selectors
        public static readonly By accDescNoAccomodationFieldSelector = By.XPath("//td[contains(text(),'No accommodation')]/../td[2]/span/img");
        public static readonly By accDescHotelNameFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td/span/a");
        public static readonly By accDescCostsPerNightFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[2]/span");
        public static readonly By accDescNumberOfNightsFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[3]/span");
        public static readonly By accDescCurrencyFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[4]/span");
        public static readonly By accDescTotalCostPerHotelFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[5]/span");
        public static readonly By accDescAddCommentFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[6]/span");
        //--summmary cost subsection 
        public static readonly By accDescSummaryCostFieldSelector = By.XPath("//h3[contains(text(),'Accommodation Total')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[1]");
        public static readonly By accDescCurrencySummaryCostsFieldSelector = By.XPath("//h3[contains(text(),'Accommodation Total')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[2]");

        //Meal Description section selectors
        public static readonly By mealDescNoMealFieldSelector = By.XPath("//td[contains(text(),'No meal')]/../td[2]/span/img");
        public static readonly By mealDescBreakfastIncludedFieldSelector = By.XPath("//td[contains(text(),'Breakfast Included')]/../td[2]/span/img");
        public static readonly By mealDescMealTypeFieldSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[1]/span");
        public static readonly By mealDescEstimatedCostsPerMealLabelSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[2]/span");
        public static readonly By mealDescNumberOfMealsLabelSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[3]/span");
        public static readonly By mealDescCurrencyLabelSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[4]/span");
        public static readonly By mealDescRestaurantNameLabelSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[5]/span");
        public static readonly By mealDescAddCommentsLabelSelector = By.XPath("//div[contains(text(),'Meal type')]/../../../../tbody/tr/td[6]/span");
        //--summmary cost subsection
        public static readonly By mealDescSummaryCostLabelSelector = By.XPath("//h3[contains(text(),'Meal Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[1]");
        public static readonly By mealDescCurrencySummaryCostsLabelSelector = By.XPath("//h3[contains(text(),'Meal Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[2]");

        //Travel Details section selectors
        public static readonly By travelDetNoTravelFieldSelector = By.XPath("//td[contains(text(),'No travel')]/../td[2]/span/img");
        public static readonly By travelDetTravelTypeLabelSelector = By.XPath("//div[contains(text(),'Travel type')]/../../../../tbody/tr/td[1]/span");
        public static readonly By travelDetCategoryLabelSelector = By.XPath("//div[contains(text(),'Travel type')]/../../../../tbody/tr/td[2]/span");
        public static readonly By travelDetEstimatedCostsLabelSelector = By.XPath("//div[contains(text(),'Travel type')]/../../../../tbody/tr/td[3]/span");
        public static readonly By travelDetCurrencyLabelSelector = By.XPath("//div[contains(text(),'Travel type')]/../../../../tbody/tr/td[4]/span");
        public static readonly By travelDetDescriptionLabelSelector = By.XPath("//div[contains(text(),'Travel type')]/../../../../tbody/tr/td[5]/span");
        //--summmary cost subsection
        public static readonly By travelDetSummaryCostLabelSelector = By.XPath("//h3[contains(text(),'Travel Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[1]");
        public static readonly By travelDetCurrencySummaryCostsLabelSelector = By.XPath("//h3[contains(text(),'Travel Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[2]");

        //Other Costs section selectors
        public static readonly By othCostsCostTypeLabelSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[1]/span");
        public static readonly By othCostsAmountLabelSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[2]/span");
        public static readonly By othCostsCurrencyLabelSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[3]/span");
        public static readonly By othCostsAddCommentsLabelSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[4]/span");

        //Local Requirements section selectors
        public static readonly By locReqCountryReqCheckFieldSelector = By.XPath("//td[contains(text(),'Country requirements')]/../td[2]/span/img");
        public static readonly By locReqReqSubmittedFieldSelector = By.XPath("//label[contains(text(),'Local requirements')]/../../td[2]/span");
        public static readonly By locReqPleaseSpecifyFieldSelector = By.XPath("//label[contains(text(),'Local requirements')]/../../td[4]/span");

        //Notes & Attachments section selectors
        public static readonly By notesNewNoteButtonSelector = By.XPath("//h3[contains(text(),'Notes & Attachments')]/../../td[2]/input[1]");
        public static readonly By notesNewAttachmentButtonSelector = By.XPath("//h3[contains(text(),'Notes & Attachments')]/../../td[2]/input[2]");

        //Supporting Roles section Selectors
        public static readonly By suppRoleAddSupportingRoletButtonSelector = By.XPath("//h2[contains(text(),'Supporting Roles')]/../../td[2]/input");

        /// <summary>
        /// Constructor used when object of child class is instantiated
        /// </summary>
        public ViewHCPFormPageModel(IWebDriver driver,By knownElementOnPage) 
            : base(driver, knownElementOnPage) 
        {
        }

        /// <summary>
        /// Verify if each section was saved correctly
        /// </summary>
        
        public virtual void VerifyIfInformationSectionIsSaved()
        {
        }
        public virtual void VerifyIfEngOwnerSectionIsSaved(string engOwnerName, string globalFunction, string jobTitle, string engagementPaidBy, string engFunction)
        {
        }
        public virtual void VerifyIfHCPCoordSectionIsSaved(string hcpCoord)
        {
        }
        public virtual void VerifyIfLineManagerSectionIsSaved(string lineManager)
        {
        }
        public virtual void VerifyIfHCPDetailsSectionIsSaved(string hcpCountry, string hcpFirstName, string hcpLastName, string hcpFirstName2 = "", string hcpLastName2 = "")
        {
        }
        public virtual void VerifyIfProdInfSectionIsSaved(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
        }
        public virtual void VerifyIfEngDescSectionIsSaved(string engagementTitle, string engDescCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engDescription)
        {
        }
        public virtual void VerifyIfAffiliateContSectionIsSaved(string affContact)
        {
        }
        public virtual void VerifyIfHCPRoleSectionIsSaved(string hcpRoleSelect, string rationalForHCP, string areaOfExpertise)
        {
        }
        public virtual void VerifyIfFeeForServiceSectionIsSaved(string noFee, string totalActivityTime, string feePrepTime, string feeHourlyRate, string feeFlatRate, string feeTotalDisturbanceFee, string feeCurrency)
        {
        }
        public virtual void VerifyIfAccDescSectionIsSaved(string noAccomodation, string accNameToLookup, string accCostsPerNight, string accNrOfNights, string accCurrency, string accDescription)
        {
        }
        public virtual void VerifyIfMealDescSectionIsSaved(string noMeal, string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments, string mealBreakfastIncluded)
        {
        }
        public virtual void VerifyIfTravelDetailsSectionIsSaved(string noTravel, string travelType, string travelCategory, string travelEstimatedCosts, string travelCurrency, string travelDescription)
        {
        }
        public virtual void VerifyIfOtherCostsSectionIsSaved(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
        }
        public virtual void VerifyIfLocalReqSectionIsSaved(string localReqFulfilled, string locReqSubmitted, string locReqSpecify)
        {
        }

        /// <summary>
        /// Adding Notes & Attachments
        /// </summary>
        public virtual void AddNewNoteToForm()
        {
        }
        public virtual void AddNewAttachmentToForm()
        {
        }

        /// <summary>
        /// Adding Supporting Role
        /// </summary>
        public virtual void ClickAddSupportingRoleButton()
        {
        }

        ///
        /// Store Forms ID
        ///
        public virtual void SaveFormIDToConfig() 
        {
        }
        public virtual void ClickSendUpdatedFormButton()
        {
        }
    }
}
