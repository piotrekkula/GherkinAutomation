using System;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using GherkinAutomation;
using NUnit.Framework;

namespace GherkinAutomation.Pages
{
    public class AddNewHCPFormPageModel : PageModel
    {
        //Button selectors
        public static readonly By topSaveButtonSelector = By.XPath("//h2[contains(text(),'International HCP Engagement')]/../../td[2]/input[1]");
        public static readonly By topCancelButtonSelector = By.XPath("//h2[contains(text(),'International HCP Engagement')]/../../td[2]/input[2]");

        //Success validation selectors
        public static readonly By successMessageLabelSelector = By.XPath("//img[@alt='CONFIRM']/../../td[2]/div/span/h4[contains(text(),'Success')]");

        //Information section selectors
        public static readonly By infoStatusLabelSelector = By.XPath("//td[contains(text(),'Status')]/../td[2]/span[contains(@id,'statusField')]");
        public static readonly By infoFormTypeLabelSelector = By.XPath("//label[contains(text(),'Form Type')]/../../td[2]/span");
        public static readonly By infoHCPEngIDLabelSelector = By.XPath("//td[contains(text(),'HCP Engagement ID')]/../td[4]/span");
        public static readonly By infoAccurateCompleteFieldSelector = By.XPath("//label[contains(text(),'I certify that the information')]/../../td[2]/input[@type='checkbox']");

        //Engagement owner selectors
        public static readonly By engOwnerNameFieldSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/div/span/input[@type='text']");
        public static readonly By engOwnerNameLookupButtonSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/div/span/input[@type='text']/../a[1]");
        public static readonly By engOwnerNameMeLinkSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/div/a[1]");
        public static readonly By engOwnerRadioYesButtonSelector = By.XPath("//label[contains(text(),'Yes')]/../input[@value='true']");
        public static readonly By engOwnerRadioNoButtonSelector = By.XPath("//label[contains(text(),'No')]/../input[@value='false']");
        public static readonly By engOwnerJobTitleFieldSelector = By.XPath("//label[contains(text(),'Job Title')]/../../td[2]/input[@type='text']");
        public static readonly By engOwnerDepartmentLabelSelector = By.XPath("//span[contains(text(),'Department')]/../../td[4]/span");
        public static readonly By engOwnerEmailLabelSelector = By.XPath("//td[contains(text(),'Email')]/../td[2]/span/a");
        public static readonly By engOwnerPhoneDetailsLabelSelector = By.XPath("//td[contains(text(),'Phone')]/../td[4]/span");
        public static readonly By engOwnerEngagementPaidAvailableFieldSelector = By.XPath("//label[contains(text(),'Engagement Paid By')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By engOwnerEngagementPaidAvailableOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Paid By')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By engOwnerEngagementPaidChosenFieldSelector = By.XPath("//label[contains(text(),'Engagement Paid By')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By engOwnerEngagementPaidChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Paid By')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]"); //does not work on firefox !
        public static readonly By engOwnerEngagementPaidAddButtonSelector = By.XPath("//select[contains(@title,'Engagement Paid By')]/../../td[2]/a[@title='Add']");
        public static readonly By engOwnerEngagementPaidRemoveButtonSelector = By.XPath("//select[contains(@title,'Engagement Paid By')]/../../td[2]/a[@title='Remove']");
        public static readonly By engOwnerCountryLabelSelector = By.XPath("//td[contains(text(),'Country')]/../td[2]/span");
        public static readonly By engOwnerEmploymentTypeLabelSelector = By.XPath("//td[contains(text(),'Employment Type')]/../td[4]/span");
        public static readonly By engOwnerFunctionFieldSelector = By.XPath("//label[contains(text(),'Function')]/../../td[2]/div/select");
        public static readonly By engOwnerFunctionOptionFieldSelector = By.XPath("//label[contains(text(),'Function')]/../../td[2]/div/select/option[@value]");

        //HCP Coordinator/Assistant Details selectors
        public static readonly By hcpCoordNameFieldSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/span/input[@type='text']");
        public static readonly By hcpCoordNameLookupButtonSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/span/input[@type='text']/../a[1]");
        public static readonly By hcpCoordNameMeLinkSelector = By.XPath("//label[contains(text(),'Name')]/../../../td[2]/span/input[@type='text']/../../a[1]");

        //Healthcare Professional Details selectors
        public static readonly By hcpDetailsCountryFieldSelector = By.XPath("//label[contains(text(),'HCP Country')]/../../td[2]/div/select");
        public static readonly By hcpDetailsCountryOptionFieldSelector = By.XPath("//label[contains(text(),'HCP Country')]/../../td[2]/div/select/option[@selected='selected']");

        //Product Information selectors
        public static readonly By prodInfTherapeuticAreaFieldSelector = By.XPath("//label[contains(text(),'Therapeutic Area')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By prodInfTherapeuticAreaOptionFieldSelector = By.XPath("//label[contains(text(),'Therapeutic Area')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By prodInfTherapeuticAreaAddbuttonSelector = By.XPath("//select[contains(@title,'Therapeutic Area')]/../../td[2]/a[@title='Add']");
        public static readonly By prodInfTherapeuticAreaRemoveButtonFieldSelector = By.XPath("//select[contains(@title,'Therapeutic Area')]/../../td[2]/a[@title='Remove']");
        public static readonly By prodInfTherapeuticAreaChosenFieldSelector = By.XPath("//label[contains(text(),'Therapeutic Area')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By prodInfTherapeuticAreaChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Therapeutic Area')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By prodInfProductBrandMoleculeFieldSelector = By.XPath("//label[contains(text(),'Product(s) / Brand / Molecule')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By prodInfProductBrandMoleculeOptionFieldSelector = By.XPath("//label[contains(text(),'Product(s) / Brand / Molecule')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By prodInfProductBrandMoleculeAddbuttonSelector = By.XPath("//select[contains(@title,'Product(s) / Brand / Molecule - Available')]/../../td[2]/a[@title='Add']");
        public static readonly By prodInfProductBrandMoleculeRemoveButtonFieldSelector = By.XPath("//select[contains(@title,'Product(s) / Brand / Molecule - Available')]/../../td[2]/a[@title='Remove']");
        public static readonly By prodInfProductBrandMoleculeChosenFieldSelector = By.XPath("//label[contains(text(),'Product(s) / Brand / Molecule')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By prodInfProductBrandMoleculeChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Product(s) / Brand / Molecule')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By prodInfIndicationFieldSelector = By.XPath("//label[contains(text(),'Indication(s)')]/../../td[2]/table/tbody/tr[2]/td[1]/select");
        public static readonly By prodInfIndicationOptionFieldSelector = By.XPath("//label[contains(text(),'Indication(s)')]/../../td[2]/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By prodInfIndicationAddButtonSelector = By.XPath("//select[contains(@title,'Indication(s)')]/../../td[2]/a[@title='Add']");
        public static readonly By prodInfIndicationRemoveButtonSelector = By.XPath("//select[contains(@title,'Indication(s)')]/../../td[2]/a[@title='Remove']");
        public static readonly By prodInfIndicationChosenFieldSelector = By.XPath("//label[contains(text(),'Indication(s)')]/../../td[2]/table/tbody/tr[2]/td[3]/select");
        public static readonly By prodInfIndicationChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Indication(s)')]/../../td[2]/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By prodInfProtocolNumberFieldSelector = By.XPath("//label[contains(text(),'Protocol Number')]/../../td[2]/input");

        //HCP Role in this activity
        public static readonly By hcpRoleHCPRoleFieldSelector = By.XPath("//label[contains(text(),'HCP Role')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By hcpRoleHCPRoleOptionFieldSelector = By.XPath("//label[contains(text(),'HCP Role')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By hcpRoleHCPRoleAddButtonSelector = By.XPath("//select[contains(@title,'HCP Role')]/../../td[2]/a[@title='Add']");
        public static readonly By hcpRoleHCPRoleRemoveButtonSelector = By.XPath("//select[contains(@title,'HCP Role')]/../../td[2]/a[@title='Remove']");
        public static readonly By hcpRoleHCPRoleChosenFieldSelector = By.XPath("//label[contains(text(),'HCP Role')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By hcpRoleHCPRoleChosenOptionFieldSelector = By.XPath("//label[contains(text(),'HCP Role')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By hcpRoleRationalForHCPFieldSelector = By.XPath("//label[contains(text(),'Rational for HCP')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By hcpRoleRationalForHCPOptionFieldSelector = By.XPath("//label[contains(text(),'Rational for HCP')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By hcpRoleRationalForHCPAddButtonSelector = By.XPath("//select[contains(@title,'Rational for HCP')]/../../td[2]/a[@title='Add']");
        public static readonly By hcpRoleRationalForHCPRemoveButtonSelector = By.XPath("//select[contains(@title,'Rational for HCP')]/../../td[2]/a[@title='Remove']");
        public static readonly By hcpRoleRationalForHCPChosenFieldSelector = By.XPath("//label[contains(text(),'Rational for HCP')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By hcpRoleRationalForHCPChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Rational for HCP')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By hcpRoleAreaOfExpertiseFieldSelector = By.XPath("//label[contains(text(),'Specify area of expertise')]/../../../td[2]/div/textarea");

        //Engagement description selectors
        public static readonly By engDescEngagementTitleFieldSelector = By.XPath("//label[contains(text(),'Engagement Title')]/../../../td[2]/div/textarea");
        public static readonly By engDescCongressFieldSelector = By.XPath("//label[contains(text(),'Engagement Title')]/../../../td[4]/select");
        public static readonly By engDescCongressOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Title')]/../../../td[4]/select/option[@value]");
        public static readonly By engDescEngagementTypeFieldSelector = By.XPath("//label[contains(text(),'Engagement Type')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select");
        public static readonly By engDescEngagementTypeOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Type')]/../../td[2]/div/table/tbody/tr[2]/td[1]/select/optgroup/option[@value]");
        public static readonly By engDescEngagementTypeAddButtonSelector = By.XPath("//select[contains(@title,'Engagement Type')]/../../td[2]/a[@title='Add']");
        public static readonly By engDescEngagementTypeRemoveButtonSelector = By.XPath("//select[contains(@title,'Engagement Type')]/../../td[2]/a[@title='Remove']");
        public static readonly By engDescEngagementTypeChosenFieldSelector = By.XPath("//label[contains(text(),'Engagement Type')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select");
        public static readonly By engDescEngagementTypeChosenOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Type')]/../../td[2]/div/table/tbody/tr[2]/td[3]/select/optgroup/option[@value]");
        public static readonly By engDescAllDayEngagementFieldSelector = By.XPath("//label[contains(text(),'All Day Engagement')]/../../td[2]/input");
        public static readonly By engDescStartDateFieldSelector = By.XPath("//label[contains(text(),'Start Date')]/../../td[2]/div/span/div/span/input");
        public static readonly By engDescStartDateFieldCheckerSelector = By.XPath("//label[contains(text(),'Start Date')]/../../td[2]/div/span/div/span/input and contains(@value,'/')]");
        public static readonly By engDescStartDatePickerTodayLinkSelector = By.ClassName("calToday");
        public static readonly By engDescEndDateFieldSelector = By.XPath("//label[contains(text(),'End Date')]/../../td[4]/div/span/div/span/input");
        public static readonly By engDescEndDateFieldCheckerSelector = By.XPath("//label[contains(text(),'End Date')]/../../td[4]/div/span/div/span/input and contains(@value,'/')]");
        public static readonly By engDescEndDatePickerTodayLinkSelector = By.ClassName("calToday");
        public static readonly By engDescEngagementVenueFieldSelector = By.XPath("//label[contains(text(),'Engagement Venue')]/../../../td[2]/div/textarea");
        public static readonly By engDescEngagementCityFieldSelector = By.XPath("//label[contains(text(),'Engagement City')]/../../td[2]/div/input");
        public static readonly By engDescEngagementCountryFieldSelector = By.XPath("//label[contains(text(),'Engagement Country')]/../../td[2]/div/select");
        public static readonly By engDescEngagementCountryOptionFieldSelector = By.XPath("//label[contains(text(),'Engagement Country')]/../../td[2]/div/select/option[@value]");
        public static readonly By engDescEngagementStateProvinceFieldSelector = By.XPath("//label[contains(text(),'Engagement State/Province')]/../../td[2]/div/select");
        public static readonly By engDescEngagementOtherCountryFieldSelector = By.XPath("page:form:pb1:pb1sec:EngagementOtherCountry");
        public static readonly By engDescScientificalMedicalBusinessNeedsFieldSelector = By.XPath("//label[contains(text(),'Scientific/Medical/Business needs')]/../../../td[2]/div/textarea");
        public static readonly By engDescEngagementObjectivesFieldSelector = By.XPath("//label[contains(text(),'Engagement Objectives')]/../../../td[4]/div/textarea");
        public static readonly By engDescContractedRadioYesButtonSelector = By.XPath("//label[contains(text(),'Yes')]/../input[@value='Yes']");
        public static readonly By engDescContractedRadioNoButtonSelector = By.XPath("//label[contains(text(),'No')]/../input[@value='No']");
        public static readonly By engDescDescriptionFieldSelector = By.XPath("//label[contains(text(),'Description')]/../../../td[2]/textarea");

        //Affiliate Contact List
        public static readonly By affContAffiliateContactFieldSelector = By.XPath("//label[contains(text(),'Affiliate Contact')]/../../../td[2]/div/select");
        public static readonly By affContAffiliateContactOptionFieldSelector = By.XPath("//label[contains(text(),'Affiliate Contact')]/../../../td[2]/div/select/option[@value]");

        //Fee for service
        public static readonly By feeForServNoFeeForServiceFieldSelector = By.XPath("//label[contains(text(),'No fee for service')]/../../td[2]/input[@type='checkbox']");
        public static readonly By feeForServTotalActivityTimeFieldSelector = By.XPath("//label[contains(text(),'Total activity time')]/../../../td[2]/div/input[@type='text']");
        public static readonly By feeForServPostActivityTimeFieldSelector = By.XPath("//label[contains(text(),'Preparation/post activity time')]/../../td[2]/div/input[@type='text']");
        public static readonly By feeForServHourlyRateFieldSelector = By.XPath("//label[contains(text(),'Hourly rate')]/../../td[2]/div/input[@type='text']");
        public static readonly By feeForServFlatRateFieldSelector = By.XPath("//label[contains(text(),'Flat Rate')]/../../../td[2]/div/input[@type='text']");
        public static readonly By feeForServTotalDisturbanceFeeDescriptionFieldSelector = By.XPath("//label[contains(text(),'Total Disturbance Fee')]/../../../td[2]/input[@type='text']");
        public static readonly By feeForServCurrencyFieldSelector = By.XPath("//label[contains(text(),'Currency')]/../../../../td[2]/span/select");
        public static readonly By feeForServCalculatedTotalFieldSelector = By.XPath("//label[contains(text(),'Calculated Total')]/../../td[2]/span");

        //Accommodation Description
        public static readonly By accDescNoAccomodationFieldSelector = By.XPath("//label[contains(text(),'No accommodation')]/../../td[2]/input[@type='checkbox']");
        public static readonly By accDescAddHotelButtonSelector = By.XPath("//input[contains(@value,'Add Hotel for engagement')]");
        public static readonly By accDescHotelNameFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[2]/div/span/input");
        public static readonly By accDescHotelNameLookupButtonSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[2]/div/span/a");
        public static readonly By accDescCostsPerNightFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[3]/div/input");
        public static readonly By accDescNumberOfNightsFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[4]/div/input");
        public static readonly By accDescCurrencyFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[5]/div/table/tbody/tr/td/select");
        public static readonly By accDescTotalCostPerHotelFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[6]");
        public static readonly By accDescAddCommentFieldSelector = By.XPath("//div[contains(text(),'Hotel')]/../../../../tbody/tr/td[7]/textarea");
        //--summmary cost subsection
        public static readonly By accDescSummaryCostFieldSelector = By.XPath("//h3[contains(text(),'Accommodation Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[1]");
        public static readonly By accDescCurrencySummaryCostsFieldSelector = By.XPath("//h3[contains(text(),'Accommodation Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[2]");

        //Meal Description
        public static readonly By mealDescNoMealFieldSelector = By.XPath("//label[contains(text(),'No meal')]/../../td[2]/input[@type='checkbox']");
        public static readonly By mealDescNewMealButtonSelector = By.XPath("//input[contains(@value,'New Meal')]");
        public static readonly By mealDescBreakfastIncludedSelector = By.XPath("//label[contains(text(),'Breakfast Included')]/../../td[2]/input[@type='checkbox']");
        public static readonly By mealDescMealTypeFieldSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[2]/div/select");
        public static readonly By mealDescEstimatedCostsPerMealSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[3]/div/input");
        public static readonly By mealDescNumberOfMealsFieldSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[4]/div/input");
        public static readonly By mealDescCurrencyFieldSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[5]/div/select");
        public static readonly By mealDescRestaurantNameFieldSelector = By.XPath("//div[contains(text(),'Meal Type')]/../../../../tbody/tr/td[6]/div/input");
        //--summmary cost subsection
        public static readonly By mealDescSummaryCostFieldSelector = By.XPath("//h3[contains(text(),'Meal Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[1]");
        public static readonly By mealDescCurrencySummaryCostsFieldSelector = By.XPath("//h3[contains(text(),'Meal Total Costs')]/../../div[2]/table/tbody/tr/td/table/tbody/tr/td[2]");

        //Travel Details
        public static readonly By travelDetNoTravelFieldSelector = By.XPath("//label[contains(text(),'No travel')]/../../td[2]/input[@type='checkbox']");
        public static readonly By travelDetNewTravelButtonSelector = By.XPath("//input[contains(@value,'New Travel')]");
        public static readonly By travelDetTravelTypeFieldSelector = By.XPath("//div[contains(text(),'Travel Type')]/../../../../tbody/tr/td[2]/div/select");
        public static readonly By travelDetCategoryFieldSelector = By.XPath("//div[contains(text(),'Travel Type')]/../../../../tbody/tr/td[3]/div/select");
        public static readonly By travelDetEstimatedCostsFieldSelector = By.XPath("//div[contains(text(),'Travel Type')]/../../../../tbody/tr/td[4]/div/input");
        public static readonly By travelDetCurrencyFieldSelector = By.XPath("//div[contains(text(),'Travel Type')]/../../../../tbody/tr/td[5]/div/span/select");
        public static readonly By travelDetDescriptionFieldSelector = By.XPath("//div[contains(text(),'Travel Type')]/../../../../tbody/tr/td[6]/textarea");

        //Other Costs
        public static readonly By othCostsNewCostButtonSelector = By.XPath("//input[contains(@value,'New Cost')]");
        public static readonly By othCostsCostTypeFieldSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[2]/div/input");
        public static readonly By othCostsAmountFieldSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[3]/div/input");
        public static readonly By othCostsCurrencyFieldSelector = By.XPath("//div[contains(text(),'Cost Type')]/../../../../tbody/tr/td[4]/div/select");

        //Local Requirements
        public static readonly By locReqCountryReqCheckFieldSelector = By.XPath("//label[contains(text(),'Country requirements')]/../../td[2]/input[@type='checkbox']");
        public static readonly By locReqReqSubmittedFieldSelector = By.XPath("//label[contains(text(),'Local requirements')]/../../../td[2]/div/select");
        public static readonly By locReqPleaseSpecifyFieldSelector = By.XPath("//label[contains(text(),'Local requirements')]/../../../td[4]/textarea");

        /// <summary>
        /// Constructor used when new object of current page is created for the first time. 
        /// </summary>
        public AddNewHCPFormPageModel(IWebDriver driver, By knownElementOnPage)
            : base(driver, knownElementOnPage)
        {

        }

        /// <summary>
        /// Fill in fields in each section.
        /// Methods contain information which is filled in all forms.
        /// If a section needs different activity, use override in each of the form's class, which inherit from this class.
        /// </summary>

        public virtual void FillInInformationSection()
        {
        }
        public virtual void FillInEngagementOwnerOther(string engOwnerName)
        {
        }
        public virtual void FillInMeAsEngagementOwner()
        {
        }
        public virtual void FillInEngagementOwnerDetailsSection(string globalFunction, string jobTitle, string engagementPaidBy, string engagementFunction)
        {
        }
        public virtual void FillInMeAsHCPCoordinator()
        {
        }
        public virtual void FillInHCPCoordinatorOther(string hcpCoord)
        {
        }
        public virtual void FillInLineManagerOther(string lineManager)
        {
        }
        public virtual void FillInHealthcareProfessionalDetailsSection(string hcpDetailsCountry)
        {
        }
        public virtual void FillInProductInformationSection(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
        }
        public virtual void FillInEngagementDescriptionSection(string engagementTitle, string engagementCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engagementDescription)
        {
        }
        public virtual void FillInAffiliateContactListSection(string affContact)
        {
        }
        public virtual void FillInHCPRoleSection(string hcpRoleSelect, string rationalForHcp, string areaOfExpertise)
        {
        }
        public virtual void FillInNoFeeForServiceSection(string noFee)
        {
        }
        public virtual void FillInFeeForServiceSection(string noFee, string totalActivityTime, string feePrepTime, string feeHourlyRate, string feeFlatRate, string feeTotalDisturbanceFee, string feeCurrency)
        {
        }
        public virtual void FillInNoAccommodationDescriptionSection(string noAccomodation)
        {
        }
        public virtual void FillInAccomodationHotelSection(string accNameToLookup)
        {
        }
        public virtual void FillInAccommodationDescriptionSection(string accCostsPerNight, string accNrOfNights, string accCurrency, string accDescription)
        {
        }
        public virtual void FillInNoMealDescriptionSection(string noMeal)
        {
        }
        public virtual void FillInMealBreakfastIncluded()
        {
        }
        public virtual void FillInMealDescriptionSection(string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments)
        {
        }
        public virtual void FillInNoTravelDetailsSection(string noTravel)
        {
        }
        public virtual void FillInTravelDetailsSection(string travelType, string travelCategory, string travelEstimatedCosts, string travelCurrency, string travelDescription)
        {
        }
        public virtual void FillInOtherCostsSection(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
        }
        public virtual void FillInLocalRequirementsFullfilled(string locReqCheck)
        {
        }
        public virtual void FillInLocalRequirementsSection(string locReqSubmitted, string locReqSpecify)
        {
        }

        /// <summary>
        /// Verify if information was put in correctly after each section. 
        /// Methods contain assertions common to all forms. 
        /// If a section needs different assertions, use override in each of the form's class, which inherit from this class.
        /// </summary>

        public virtual void VerifyInformationSectionIsFilled()
        {
        }
        public virtual void VerifyEngagementOwnerSectionIsFilled(string engOwnerName, string globalFunction, string jobTitle, string engagementPaidBy, string engagementFunction)
        {
        }
        public virtual void VerifyHCPCoordinatorSectionIsFilled(string hcpCoordinator)
        {
        }
        public virtual void VerifyLineManagerSectionIsFilled(string lineManager)
        {
        }
        public virtual void VerifyHealthcareProfessionalDetailsSectionIsFilled(string hcpCountry, string hcpFirstName, string hcpLastName)
        {
        }
        public virtual void VerifyProductInformationSectionIsFilled(string therapeuticArea, string productBrandMolecule, string prodIndication, string protocolNumber)
        {
        }
        public virtual void VerifyEngagementDescriptionSectionIsFilled(string engagementTitle, string engagementCongress, string engagementType, string allDayEngagement, string engagementVenue, string engagementCity, string engagementCountry, string engagementStateProvince, string sciMedBusNeeds, string engagementObjective, string contractedService, string engagementDescription)
        {
        }
        public virtual void VerifyAffiliateContactSectionIsFilled(string affContact)
        {
        }
        public virtual void VerifyHCPRoleSectionIsFilled(string hcpRoleSelect, string rationalForHcp, string areaOfExpertise)
        {
        }
        public virtual void VerifyFeeForServiceSectionIsFilled(string noFee, string totalActivityTime, string feePrepTime, string feeHourlyRate, string feeFlatRate, string feeTotalDisturbanceFee, string feeCurrency)
        {
        }
        public virtual void VerifyAccomodationSectionIsFilled(string noAccomodation, string accNameToLookup, string accCostsPerNight, string accNrOfNights, string accCurrency, string accAddComment)
        {
        }
        public virtual void VerifyMealSectionIsFilled(string noMeal, string mealType, string mealEstimatedCosts, string mealNumberOfMeals, string mealCurrency, string mealRestaurantName, string mealComments, string breakfastIncluded)
        {
        }
        public virtual void VerifyTravelDetailsSectionIsFilled(string noTravel, string travelType, string travelCategory, string travelEstimatedCosts, string travelCurrency, string travelDescription)
        {
        }
        public virtual void VerifyOtherCostsSectionIsFilled(string noOtherCosts, string otherCostsType, string otherCostsAmount, string otherCostsCurrency, string otherCostsComment)
        {
        }
        public virtual void VerifyLocalRequirementsSectionIsFilled(string locReqCheck, string locReqSubmitted, string locReqSpecify)
        {
        }

        public virtual void ClickOPenAddHCPListForSelection()
        {
        }
        public virtual void ClickSaveFormButton()
        {
        }

    }
}
