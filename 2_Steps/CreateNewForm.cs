using System.Linq;
using TechTalk.SpecFlow;
using NUnit.Framework;
using GherkinAutomation.Pages;
using WebTestAutomation.Steps;

namespace GherkinAutomation.Steps
{
    [Binding]
    public class CreateNewForm : BaseStepDefinitions
    {
        /// <summary>
        /// CREATE NEW FORM STEPS ######
        /// </summary>

        [When(@"I clicked New Form button")]
        public void WhenIClickedNewFormButton()
        {
            Use<IHCPHomeBasePageModel>().ClickSearchEventButton();
            Create(new NewHCPEngagementPageModel(Driver));
            Use<NewHCPEngagementPageModel>();
        }

        [Then(@"sHCP Form option is visible")]
        public void ThenSHCPFormOptionIsVisible()
        {
            Assert.True(Driver.FindElements(NewHCPEngagementPageModel.sHCPFormButton).Count != 0, "Bug: sHCP option was not found! Maybe not logged in as engagement owner?");
            
        }

        [Then(@"mHCP Form option is visible")]
        public void ThenMHCPFormOptionIsVisible()
        {
            Assert.True(Driver.FindElements(NewHCPEngagementPageModel.mHCPFormButton).Count != 0, "Bug: mHCP option was not found! Maybe not logged in as engagement owner?");
        }

        [Then(@"uHCP Form option is visible")]
        public void ThenUHCPFormOptionIsVisible()
        {
            Assert.True(Driver.FindElements(NewHCPEngagementPageModel.uHCPFormButton).Count != 0, "Bug: uHCP option was not found! Maybe not logged in as engagement owner?");
        }

        [When(@"I click Next button")]
        public void WhenIClickNextButton()
        {
            if (Use<NewHCPEngagementPageModel>().IsNewsHCPFormButtonSelected())
            {
                Use<NewHCPEngagementPageModel>().ClickNextButton();
                Create(new AddNewsHCPFormPageModel(Driver));
            }
            else if (Use<NewHCPEngagementPageModel>().IsNewmHCPFormButtonSelected())
            {
                Use<NewHCPEngagementPageModel>().ClickNextButton();
                Create(new AddNewmHCPFormPageModel(Driver));
            }
            else if (Use<NewHCPEngagementPageModel>().IsNewuHCPFormButtonSelected())
            {
                Use<NewHCPEngagementPageModel>().ClickNextButton();
                Create(new AddNewuHCPFormPageModel(Driver));
            }
        }
        
        /// <summary>
        /// SHCP FORM CREATION STEPS ######
        /// </summary>

        [When(@"I select sHCP option")]
        public void WhenISelectSHCPOption()
        {
            if (Use<NewHCPEngagementPageModel>().IsNewsHCPFormButtonSelected())
            {

            }
            else
            {
                Use<NewHCPEngagementPageModel>().ClicksHCPFormRadioButton();
            }
        }

        [Then(@"New sHCP Form opens")]
        public void ThenNewSHCPFormOpens()
        {
            Assert.AreEqual(AddNewsHCPFormPageModel.formTypesHCP, Driver.FindElement(AddNewsHCPFormPageModel.infoFormTypeLabelSelector).Text, "Form type is not set to sHCP.");
        }

        [Then(@"New sHCP form is verified")]
        public void ThenNewSHCPFormIsVerified(Table allvars)
        {
            string engOwnerName = allvars.Header.ElementAt(0);
            string engOwnerGlobalFunction = allvars.Header.ElementAt(1);
            string engOwnerJobTitle = allvars.Header.ElementAt(2);
            string engOwnerEngagementPaidBy = allvars.Header.ElementAt(3);
            string engOwnerFunction = allvars.Header.ElementAt(4);
            string hcpCoordName = allvars.Header.ElementAt(5);
            string lineManagerName = allvars.Header.ElementAt(6);
            string hcpDetailsCountry = allvars.Header.ElementAt(7);
            string hcpDetailsFirstName = allvars.Header.ElementAt(8);
            string hcpDetailsLastName = allvars.Header.ElementAt(9);
            string prodInfTherapeuticArea = allvars.Header.ElementAt(10);
            string prodInfProductBrandMolecule = allvars.Header.ElementAt(11);
            string prodInfIndication = allvars.Header.ElementAt(12);
            string prodInfProtocolNumber = allvars.Header.ElementAt(13);
            string engDescEngagementTitle = allvars.Header.ElementAt(14);
            string engDescCongress = allvars.Header.ElementAt(15);
            string engDescEngagementType = allvars.Header.ElementAt(16);
            string engDescAllDayEngagement = allvars.Header.ElementAt(17);
            string engDescEngagementVenue = allvars.Header.ElementAt(18);
            string engDescEngagementCity = allvars.Header.ElementAt(19);
            string engDescEngagementCountry = allvars.Header.ElementAt(20);
            string engDescEngagementStateProvince = allvars.Header.ElementAt(21);
            string engDescSciMedBusNeeds = allvars.Header.ElementAt(22);
            string engDescEngagementObjective = allvars.Header.ElementAt(23);
            string engDescContractedService = allvars.Header.ElementAt(24);
            string engDescDescription = allvars.Header.ElementAt(25);
            string affContactName = allvars.Header.ElementAt(26);
            string hcpRoleSelect = allvars.Header.ElementAt(27);
            string hcpRoleRationalForHCP = allvars.Header.ElementAt(28);
            string hcpRoleAreaOfExpertise = allvars.Header.ElementAt(29);
            string feeForServiceNoFee = allvars.Header.ElementAt(30);
            string feeForServiceTotalActivityTime = allvars.Header.ElementAt(31);
            string feeForServicePrepTime = allvars.Header.ElementAt(32);
            string feeForServiceHourlyRate = allvars.Header.ElementAt(33);
            string feeForServiceFlatRate = allvars.Header.ElementAt(34);
            string feeForServiceTotalDisturbanceFee = allvars.Header.ElementAt(35);
            string feeForServiceCurrency = allvars.Header.ElementAt(36);
            string accDescNoAccomodation = allvars.Header.ElementAt(37);
            string accDescAccNameToLookup = allvars.Header.ElementAt(38);
            string accDescCostsPerNight = allvars.Header.ElementAt(39);
            string accDescNrOfNights = allvars.Header.ElementAt(40);
            string accDescCurrency = allvars.Header.ElementAt(41);
            string accDescDescription = allvars.Header.ElementAt(42);
            string mealDescNoMeal = allvars.Header.ElementAt(43);
            string mealDescMealType = allvars.Header.ElementAt(44);
            string mealDescMealEstCosts = allvars.Header.ElementAt(45);
            string mealDescNumberOfMeals = allvars.Header.ElementAt(46);
            string mealDescMealCurrency = allvars.Header.ElementAt(47);
            string mealDescMealRestaurantName = allvars.Header.ElementAt(48);
            string mealDescMealComments = allvars.Header.ElementAt(49);
            string mealDescBreakfastIn = allvars.Header.ElementAt(50);
            string travelDetailsNoTravel = allvars.Header.ElementAt(51);
            string travelDetailsTravelType = allvars.Header.ElementAt(52);
            string travelDetailsTravelCategory = allvars.Header.ElementAt(53);
            string travelDetailsTravelEstCosts = allvars.Header.ElementAt(54);
            string travelDetailsTravelCurrency = allvars.Header.ElementAt(55);
            string travelDetailsTravelDescription = allvars.Header.ElementAt(56);
            string otherCostsNoOtherCosts = allvars.Header.ElementAt(57);
            string otherCostsOthCostsType = allvars.Header.ElementAt(58);
            string otherCostsOthCostsAmount = allvars.Header.ElementAt(59);
            string otherCostsOthCostsCurrency = allvars.Header.ElementAt(60);
            string otherCostsOthCostsComment = allvars.Header.ElementAt(61);
            string localReqLocRequirementFulfilled = allvars.Header.ElementAt(62);
            string localReqSubmitted = allvars.Header.ElementAt(63);
            string localReqPleaseSpecify = allvars.Header.ElementAt(64);

            Use<ViewsHCPFormPageModel>().VerifyIfEngOwnerSectionIsSaved(engOwnerName, engOwnerGlobalFunction, engOwnerJobTitle, engOwnerEngagementPaidBy, engOwnerFunction);
            Use<ViewsHCPFormPageModel>().VerifyIfHCPCoordSectionIsSaved(hcpCoordName);
            Use<ViewsHCPFormPageModel>().VerifyIfLineManagerSectionIsSaved(lineManagerName);
            Use<ViewsHCPFormPageModel>().VerifyIfHCPDetailsSectionIsSaved(hcpDetailsCountry, hcpDetailsFirstName, hcpDetailsLastName);
            Use<ViewsHCPFormPageModel>().VerifyIfProdInfSectionIsSaved(prodInfTherapeuticArea, prodInfProductBrandMolecule, prodInfIndication, prodInfProtocolNumber);
            Use<ViewsHCPFormPageModel>().VerifyIfEngDescSectionIsSaved(engDescEngagementTitle, engDescCongress, engDescEngagementType, engDescAllDayEngagement, engDescEngagementVenue, engDescEngagementCity, engDescEngagementCountry, engDescEngagementStateProvince, engDescSciMedBusNeeds, engDescEngagementObjective, engDescContractedService, engDescDescription);
            Use<ViewsHCPFormPageModel>().VerifyIfAffiliateContSectionIsSaved(affContactName);
            Use<ViewsHCPFormPageModel>().VerifyIfHCPRoleSectionIsSaved(hcpRoleSelect, hcpRoleRationalForHCP, hcpRoleAreaOfExpertise);
            Use<ViewsHCPFormPageModel>().VerifyIfFeeForServiceSectionIsSaved(feeForServiceNoFee, feeForServiceTotalActivityTime, feeForServicePrepTime, feeForServiceHourlyRate, feeForServiceFlatRate, feeForServiceTotalDisturbanceFee, feeForServiceCurrency);
            Use<ViewsHCPFormPageModel>().VerifyIfAccDescSectionIsSaved(accDescNoAccomodation, accDescAccNameToLookup, accDescCostsPerNight, accDescNrOfNights, accDescCurrency, accDescDescription);
            Use<ViewsHCPFormPageModel>().VerifyIfMealDescSectionIsSaved(mealDescNoMeal, mealDescMealType, mealDescMealEstCosts, mealDescNumberOfMeals, mealDescMealCurrency, mealDescMealRestaurantName, mealDescMealComments, mealDescBreakfastIn);
            Use<ViewsHCPFormPageModel>().VerifyIfTravelDetailsSectionIsSaved(travelDetailsNoTravel, travelDetailsTravelType, travelDetailsTravelCategory, travelDetailsTravelEstCosts, travelDetailsTravelCurrency, travelDetailsTravelDescription);
            Use<ViewsHCPFormPageModel>().VerifyIfOtherCostsSectionIsSaved(otherCostsNoOtherCosts, otherCostsOthCostsType, otherCostsOthCostsAmount, otherCostsOthCostsCurrency, otherCostsOthCostsComment);
            Use<ViewsHCPFormPageModel>().VerifyIfLocalReqSectionIsSaved(localReqLocRequirementFulfilled, localReqSubmitted, localReqPleaseSpecify);
        }

        /// <summary>
        /// MHCP FORM CREATION STEPS ######
        /// </summary>

        [When(@"I select mHCP option")]
        public void WhenISelectMHCPOption()
        {
            if (Use<NewHCPEngagementPageModel>().IsNewmHCPFormButtonSelected())
            {

            }
            else
            {
                Use<NewHCPEngagementPageModel>().ClickmHCPFormRadioButton();
            }
        }

        [Then(@"New mHCP Form opens")]
        public void ThenNewMHCPFormOpens()
        {
            Assert.AreEqual(AddNewmHCPFormPageModel.formTypemHCP, Driver.FindElement(AddNewmHCPFormPageModel.infoFormTypeLabelSelector).Text, "Form type is not set to mHCP.");
        }

        [Then(@"New mHCP form is verified")]
        public void ThenNewMHCPFormIsVerified(Table allvars)
        {
            string engOwnerName = allvars.Header.ElementAt(0);
            string engOwnerGlobalFunction = allvars.Header.ElementAt(1);
            string engOwnerJobTitle = allvars.Header.ElementAt(2);
            string engOwnerEngagementPaidBy = allvars.Header.ElementAt(3);
            string engOwnerFunction = allvars.Header.ElementAt(4);
            string hcpCoordName = allvars.Header.ElementAt(5);
            string lineManagerName = allvars.Header.ElementAt(6);
            string hcpDetailsCountry = allvars.Header.ElementAt(7);
            string hcpDetailsFirstName = allvars.Header.ElementAt(8);
            string hcpDetailsLastName = allvars.Header.ElementAt(9);
            string hcpDetailsFirstName2 = allvars.Header.ElementAt(10);
            string hcpDetailsLastName2 = allvars.Header.ElementAt(11);
            string prodInfTherapeuticArea = allvars.Header.ElementAt(12);
            string prodInfProductBrandMolecule = allvars.Header.ElementAt(13);
            string prodInfIndication = allvars.Header.ElementAt(14);
            string prodInfProtocolNumber = allvars.Header.ElementAt(15);
            string engDescEngagementTitle = allvars.Header.ElementAt(16);
            string engDescCongress = allvars.Header.ElementAt(17);
            string engDescEngagementType = allvars.Header.ElementAt(18);
            string engDescAllDayEngagement = allvars.Header.ElementAt(19);
            string engDescEngagementVenue = allvars.Header.ElementAt(20);
            string engDescEngagementCity = allvars.Header.ElementAt(21);
            string engDescEngagementCountry = allvars.Header.ElementAt(22);
            string engDescEngagementStateProvince = allvars.Header.ElementAt(23);
            string engDescSciMedBusNeeds = allvars.Header.ElementAt(24);
            string engDescEngagementObjective = allvars.Header.ElementAt(25);
            string engDescContractedService = allvars.Header.ElementAt(26);
            string engDescDescription = allvars.Header.ElementAt(27);
            string affContactName = allvars.Header.ElementAt(28);
            string hcpRoleSelect = allvars.Header.ElementAt(29);
            string hcpRoleRationalForHCP = allvars.Header.ElementAt(30);
            string hcpRoleAreaOfExpertise = allvars.Header.ElementAt(31);
            string feeForServiceNoFee = allvars.Header.ElementAt(32);
            string feeForServiceTotalActivityTime = allvars.Header.ElementAt(33);
            string feeForServicePrepTime = allvars.Header.ElementAt(34);
            string feeForServiceHourlyRate = allvars.Header.ElementAt(35);
            string feeForServiceFlatRate = allvars.Header.ElementAt(36);
            string feeForServiceTotalDisturbanceFee = allvars.Header.ElementAt(37);
            string feeForServiceCurrency = allvars.Header.ElementAt(38);
            string accDescNoAccomodation = allvars.Header.ElementAt(39);
            string accDescAccNameToLookup = allvars.Header.ElementAt(40);
            string accDescCostsPerNight = allvars.Header.ElementAt(41);
            string accDescNrOfNights = allvars.Header.ElementAt(42);
            string accDescCurrency = allvars.Header.ElementAt(43);
            string accDescDescription = allvars.Header.ElementAt(44);
            string mealDescNoMeal = allvars.Header.ElementAt(45);
            string mealDescMealType = allvars.Header.ElementAt(46);
            string mealDescMealEstCosts = allvars.Header.ElementAt(47);
            string mealDescNumberOfMeals = allvars.Header.ElementAt(48);
            string mealDescMealCurrency = allvars.Header.ElementAt(49);
            string mealDescMealRestaurantName = allvars.Header.ElementAt(50);
            string mealDescMealComments = allvars.Header.ElementAt(51);
            string mealDescBreakfastIn = allvars.Header.ElementAt(52);
            string travelDetailsNoTravel = allvars.Header.ElementAt(53);
            string travelDetailsTravelType = allvars.Header.ElementAt(54);
            string travelDetailsTravelCategory = allvars.Header.ElementAt(55);
            string travelDetailsTravelEstCosts = allvars.Header.ElementAt(56);
            string travelDetailsTravelCurrency = allvars.Header.ElementAt(57);
            string travelDetailsTravelDescription = allvars.Header.ElementAt(58);
            string otherCostsNoOtherCosts = allvars.Header.ElementAt(59);
            string otherCostsOthCostsType = allvars.Header.ElementAt(60);
            string otherCostsOthCostsAmount = allvars.Header.ElementAt(61);
            string otherCostsOthCostsCurrency = allvars.Header.ElementAt(62);
            string otherCostsOthCostsComment = allvars.Header.ElementAt(63);
            string localReqLocRequirementFulfilled = allvars.Header.ElementAt(64);
            string localReqSubmitted = allvars.Header.ElementAt(65);
            string localReqPleaseSpecify = allvars.Header.ElementAt(66);

            Use<ViewmHCPFormPageModel>().VerifyIfEngOwnerSectionIsSaved(engOwnerName, engOwnerGlobalFunction, engOwnerJobTitle, engOwnerEngagementPaidBy, engOwnerFunction);
            Use<ViewmHCPFormPageModel>().VerifyIfHCPCoordSectionIsSaved(hcpCoordName);
            Use<ViewmHCPFormPageModel>().VerifyIfLineManagerSectionIsSaved(lineManagerName);
            Use<ViewmHCPFormPageModel>().VerifyIfHCPDetailsSectionIsSaved(hcpDetailsCountry, hcpDetailsFirstName, hcpDetailsLastName, hcpDetailsFirstName2, hcpDetailsLastName2);
            Use<ViewmHCPFormPageModel>().VerifyIfProdInfSectionIsSaved(prodInfTherapeuticArea, prodInfProductBrandMolecule, prodInfIndication, prodInfProtocolNumber);
            Use<ViewmHCPFormPageModel>().VerifyIfEngDescSectionIsSaved(engDescEngagementTitle, engDescCongress, engDescEngagementType, engDescAllDayEngagement, engDescEngagementVenue, engDescEngagementCity, engDescEngagementCountry, engDescEngagementStateProvince, engDescSciMedBusNeeds, engDescEngagementObjective, engDescContractedService, engDescDescription);
            Use<ViewmHCPFormPageModel>().VerifyIfAffiliateContSectionIsSaved(affContactName);
            Use<ViewmHCPFormPageModel>().VerifyIfHCPRoleSectionIsSaved(hcpRoleSelect, hcpRoleRationalForHCP, hcpRoleAreaOfExpertise);
            Use<ViewmHCPFormPageModel>().VerifyIfFeeForServiceSectionIsSaved(feeForServiceNoFee, feeForServiceTotalActivityTime, feeForServicePrepTime, feeForServiceHourlyRate, feeForServiceFlatRate, feeForServiceTotalDisturbanceFee, feeForServiceCurrency);
            Use<ViewmHCPFormPageModel>().VerifyIfAccDescSectionIsSaved(accDescNoAccomodation, accDescAccNameToLookup, accDescCostsPerNight, accDescNrOfNights, accDescCurrency, accDescDescription);
            Use<ViewmHCPFormPageModel>().VerifyIfMealDescSectionIsSaved(mealDescNoMeal, mealDescMealType, mealDescMealEstCosts, mealDescNumberOfMeals, mealDescMealCurrency, mealDescMealRestaurantName, mealDescMealComments, mealDescBreakfastIn);
            Use<ViewmHCPFormPageModel>().VerifyIfTravelDetailsSectionIsSaved(travelDetailsNoTravel, travelDetailsTravelType, travelDetailsTravelCategory, travelDetailsTravelEstCosts, travelDetailsTravelCurrency, travelDetailsTravelDescription);
            Use<ViewmHCPFormPageModel>().VerifyIfOtherCostsSectionIsSaved(otherCostsNoOtherCosts, otherCostsOthCostsType, otherCostsOthCostsAmount, otherCostsOthCostsCurrency, otherCostsOthCostsComment);
            Use<ViewmHCPFormPageModel>().VerifyIfLocalReqSectionIsSaved(localReqLocRequirementFulfilled, localReqSubmitted, localReqPleaseSpecify);
        }

        /// <summary>
        /// UHCP FORM CREATION STEPS ######
        /// </summary>

        [When(@"I select uHCP option")]
        public void WhenISelectUHCPOption()
        {
            if (Use<NewHCPEngagementPageModel>().IsNewuHCPFormButtonSelected())
            {

            }
            else
            {
                Use<NewHCPEngagementPageModel>().ClickuHCPFormRadioButton();
            }
        }

        [Then(@"New uHCP Form opens")]
        public void ThenNewUHCPFormOpens()
        {
            Assert.AreEqual(AddNewuHCPFormPageModel.formTypeuHCP, Driver.FindElement(AddNewuHCPFormPageModel.infoFormTypeLabelSelector).Text, "Form type is not set to uHCP.");
        }

        [Then(@"New uHCP form is verified")]
        public void ThenNewUHCPFormIsVerified(Table allvars)
        {
            string engOwnerName = allvars.Header.ElementAt(0);
            string engOwnerGlobalFunction = allvars.Header.ElementAt(1);
            string engOwnerJobTitle = allvars.Header.ElementAt(2);
            string engOwnerEngagementPaidBy = allvars.Header.ElementAt(3);
            string engOwnerFunction = allvars.Header.ElementAt(4);
            string hcpCoordName = allvars.Header.ElementAt(5);
            string lineManagerName = allvars.Header.ElementAt(6);
            string hcpDetailsCountry = allvars.Header.ElementAt(7);
            string hcpDetailsFirstName = allvars.Header.ElementAt(8);
            string hcpDetailsLastName = allvars.Header.ElementAt(9);
            string hcpDetailsFirstName2 = allvars.Header.ElementAt(10);
            string hcpDetailsLastName2 = allvars.Header.ElementAt(11);
            string prodInfTherapeuticArea = allvars.Header.ElementAt(12);
            string prodInfProductBrandMolecule = allvars.Header.ElementAt(13);
            string prodInfIndication = allvars.Header.ElementAt(14);
            string prodInfProtocolNumber = allvars.Header.ElementAt(15);
            string engDescEngagementTitle = allvars.Header.ElementAt(16);
            string engDescCongress = allvars.Header.ElementAt(17);
            string engDescEngagementType = allvars.Header.ElementAt(18);
            string engDescAllDayEngagement = allvars.Header.ElementAt(19);
            string engDescEngagementVenue = allvars.Header.ElementAt(20);
            string engDescEngagementCity = allvars.Header.ElementAt(21);
            string engDescEngagementCountry = allvars.Header.ElementAt(22);
            string engDescEngagementStateProvince = allvars.Header.ElementAt(23);
            string engDescSciMedBusNeeds = allvars.Header.ElementAt(24);
            string engDescEngagementObjective = allvars.Header.ElementAt(25);
            string engDescContractedService = allvars.Header.ElementAt(26);
            string engDescDescription = allvars.Header.ElementAt(27);
            string affContactName = allvars.Header.ElementAt(28);
            string mealDescNoMeal = allvars.Header.ElementAt(29);
            string mealDescMealType = allvars.Header.ElementAt(30);
            string mealDescMealEstCosts = allvars.Header.ElementAt(31);
            string mealDescNumberOfMeals = allvars.Header.ElementAt(32);
            string mealDescMealCurrency = allvars.Header.ElementAt(33);
            string mealDescMealRestaurantName = allvars.Header.ElementAt(34);
            string mealDescMealComments = allvars.Header.ElementAt(35);
            string mealDescBreakfastIn = allvars.Header.ElementAt(36);
            string otherCostsNoOtherCosts = allvars.Header.ElementAt(37);
            string otherCostsOthCostsType = allvars.Header.ElementAt(38);
            string otherCostsOthCostsAmount = allvars.Header.ElementAt(39);
            string otherCostsOthCostsCurrency = allvars.Header.ElementAt(40);
            string otherCostsOthCostsComment = allvars.Header.ElementAt(41);

            Use<ViewuHCPFormPageModel>().VerifyIfEngOwnerSectionIsSaved(engOwnerName, engOwnerGlobalFunction, engOwnerJobTitle, engOwnerEngagementPaidBy, engOwnerFunction);
            Use<ViewuHCPFormPageModel>().VerifyIfHCPCoordSectionIsSaved(hcpCoordName);
            Use<ViewuHCPFormPageModel>().VerifyIfLineManagerSectionIsSaved(lineManagerName);
            Use<ViewuHCPFormPageModel>().VerifyIfHCPDetailsSectionIsSaved(hcpDetailsCountry, hcpDetailsFirstName, hcpDetailsLastName, hcpDetailsFirstName2, hcpDetailsLastName2);
            Use<ViewuHCPFormPageModel>().VerifyIfProdInfSectionIsSaved(prodInfTherapeuticArea, prodInfProductBrandMolecule, prodInfIndication, prodInfProtocolNumber);
            Use<ViewuHCPFormPageModel>().VerifyIfEngDescSectionIsSaved(engDescEngagementTitle, engDescCongress, engDescEngagementType, engDescAllDayEngagement, engDescEngagementVenue, engDescEngagementCity, engDescEngagementCountry, engDescEngagementStateProvince, engDescSciMedBusNeeds, engDescEngagementObjective, engDescContractedService, engDescDescription);
            Use<ViewuHCPFormPageModel>().VerifyIfAffiliateContSectionIsSaved(affContactName);
            Use<ViewuHCPFormPageModel>().VerifyIfMealDescSectionIsSaved(mealDescNoMeal, mealDescMealType, mealDescMealEstCosts, mealDescNumberOfMeals, mealDescMealCurrency, mealDescMealRestaurantName, mealDescMealComments, mealDescBreakfastIn);
            Use<ViewuHCPFormPageModel>().VerifyIfOtherCostsSectionIsSaved(otherCostsNoOtherCosts, otherCostsOthCostsType, otherCostsOthCostsAmount, otherCostsOthCostsCurrency, otherCostsOthCostsComment);
        }

        /// <summary>
        /// Legacy FORM CREATION STEPS ######
        /// </summary>

        

        /// <summary>
        /// GENERIC STEPS FOR FILLING FORMS ######
        /// </summary>

        [When(@"I fill in Information section")]
        public void WhenIFillInInformationSection()
        {
            Use<AddNewHCPFormPageModel>().FillInInformationSection();
        }

        [Then(@"Information Section is filled correctly")]
        public void ThenInformationSectionIsFilledCorrectly()
        {
            Use<AddNewHCPFormPageModel>().VerifyInformationSectionIsFilled();
        }

        [When(@"I fill in Engagement Owner Details with following data:")]
        public void WhenIFillInEngagementOwnerDetailsWithFollowingData(Table engdetails)
        {
            string engOwnerName = engdetails.Header.ElementAt(0);
            string globalFunction = engdetails.Header.ElementAt(1);
            string jobTitle = engdetails.Header.ElementAt(2);
            string engagementPaidBy = engdetails.Header.ElementAt(3);
            string function = engdetails.Header.ElementAt(4);

            if (engOwnerName.Equals("selectMe"))
            {
                Use<AddNewHCPFormPageModel>().FillInMeAsEngagementOwner();
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInEngagementOwnerOther(engOwnerName);
            }
            Use<AddNewHCPFormPageModel>().FillInEngagementOwnerDetailsSection(globalFunction, jobTitle, engagementPaidBy, function);
        }

        [Then(@"Engagement Owner Details is filled correctly")]
        public void ThenEngagementOwnerDetailsIsFilledCorrectly(Table engdetails)
        {
            string engOwnerName = engdetails.Header.ElementAt(0);
            string globalFunction = engdetails.Header.ElementAt(1);
            string jobTitle = engdetails.Header.ElementAt(2);
            string engagementPaidBy = engdetails.Header.ElementAt(3);
            string function = engdetails.Header.ElementAt(4);

            Use<AddNewHCPFormPageModel>().VerifyEngagementOwnerSectionIsFilled(engOwnerName, globalFunction, jobTitle, engagementPaidBy, function);
        }

        [When(@"I fill in HCP Coordinator Section as (.*)")]
        public void WhenIFillInHCPCoordinatorSectionAs(string hcpCoord)
        {
            if (hcpCoord.Equals("selectMe"))
            {
                Use<AddNewHCPFormPageModel>().FillInMeAsHCPCoordinator();
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInHCPCoordinatorOther(hcpCoord);

            }
        }

        [Then(@"HCP Coordinator Section is filled with (.*)")]
        public void ThenHCPCoordinatorSectionIsFilledWith(string hcpcoord)
        {
            Use<AddNewHCPFormPageModel>().VerifyHCPCoordinatorSectionIsFilled(hcpcoord);
        }

        [When(@"I fill in Line Manager as (.*)")]
        public void WhenIFillInLineManagerAs(string lineManager)
        {
            Use<AddNewHCPFormPageModel>().FillInLineManagerOther(lineManager);
        }

        [Then(@"Line Manager section is filled as (.*)")]
        public void ThenLineManagerSectionIsFilledAs(string lineManager)
        {
            Use<AddNewHCPFormPageModel>().VerifyLineManagerSectionIsFilled(lineManager);
        }

        [When(@"I fill in Healthcare Professional Details")]
        public void WhenIFillInHealthcareProfessionalDetails(Table hcpDetails)
        {
            string hcpCountry = hcpDetails.Header.ElementAt(0);
            string hcpFirstName = hcpDetails.Header.ElementAt(1);
            string hcpLastName = hcpDetails.Header.ElementAt(2);

            Use<AddNewHCPFormPageModel>().FillInHealthcareProfessionalDetailsSection(hcpCountry);
            Use<AddNewHCPFormPageModel>().ClickOPenAddHCPListForSelection();

            StoreCurrentPageType();
            Create(new HealthcareProfessionalDetailsPageModel(Driver));
            Use<HealthcareProfessionalDetailsPageModel>().SearchForExistingHCP(hcpFirstName, hcpLastName);
            Use<HealthcareProfessionalDetailsPageModel>().ChooseExistingHCP();
            Use<HealthcareProfessionalDetailsPageModel>().ClickSaveButton();
            RestoreCurrentPage();
        }

        [When(@"I fill in multiple Healthcare Professional Details")]
        public void WhenIFillInMultipleHealthcareProfessionalDetails(Table hcpDetails)
        {
            string hcpCountry = hcpDetails.Header.ElementAt(0);
            string hcpFirstName = hcpDetails.Header.ElementAt(1);
            string hcpLastName = hcpDetails.Header.ElementAt(2);
            string hcpFirstName2 = hcpDetails.Header.ElementAt(3);
            string hcpLastName2 = hcpDetails.Header.ElementAt(4);

            Use<AddNewHCPFormPageModel>().FillInHealthcareProfessionalDetailsSection(hcpCountry);
            Use<AddNewHCPFormPageModel>().ClickOPenAddHCPListForSelection();

            StoreCurrentPageType();
            Create(new HealthcareProfessionalDetailsPageModel(Driver));
            Use<HealthcareProfessionalDetailsPageModel>().SearchForExistingHCP(hcpFirstName, hcpLastName);
            Use<HealthcareProfessionalDetailsPageModel>().ChooseExistingHCP();
            Use<HealthcareProfessionalDetailsPageModel>().SearchForExistingHCP(hcpFirstName2, hcpLastName2);
            Use<HealthcareProfessionalDetailsPageModel>().ChooseExistingHCP();
            Use<HealthcareProfessionalDetailsPageModel>().ClickSaveButton();
            RestoreCurrentPage();
        }

        [When(@"I create new Healthcare Professional Details")]
        public void WhenICreateNewHealthcareProfessionalDetails(Table hcpDetails)
        {
            string hcpCountry = hcpDetails.Header.ElementAt(0);
            string hcpFirstName = hcpDetails.Header.ElementAt(1);
            string hcpLastName = hcpDetails.Header.ElementAt(2);
            string hcpSpeciality = hcpDetails.Header.ElementAt(3);
            string hcpStateOfPractice = hcpDetails.Header.ElementAt(4);
            string hcpAddress = hcpDetails.Header.ElementAt(5);
            string hcpZipCode = hcpDetails.Header.ElementAt(6);
            string hcpCityName = hcpDetails.Header.ElementAt(7);

            Use<AddNewHCPFormPageModel>().FillInHealthcareProfessionalDetailsSection(hcpCountry);
            Use<AddNewHCPFormPageModel>().ClickOPenAddHCPListForSelection();

            StoreCurrentPageType();
            Create(new HealthcareProfessionalDetailsPageModel(Driver));
            Use<HealthcareProfessionalDetailsPageModel>().SearchForExistingHCP(hcpFirstName,hcpLastName);
            
            //We dont want to add already existing HCP so we check if there is one already in database
            if (Driver.FindElements(HealthcareProfessionalDetailsPageModel.AddHCPLinkSelector).Count() != 0)
            {
                Use<HealthcareProfessionalDetailsPageModel>().ChooseExistingHCP();
            }
            else
            {
                Use<HealthcareProfessionalDetailsPageModel>().ClickAddNewHCPManuallyButton();
                Create(new CreateNewHCPDetailsPageModel(Driver));
                Use<CreateNewHCPDetailsPageModel>().FillInNewHCPInformation(hcpFirstName, hcpLastName, hcpSpeciality, hcpStateOfPractice, hcpAddress, hcpZipCode, hcpCityName);
                Use<CreateNewHCPDetailsPageModel>().ClickSaveButton();
                Create(new HealthcareProfessionalDetailsPageModel(Driver));
            }
            
            Use<HealthcareProfessionalDetailsPageModel>().ClickSaveButton();
            RestoreCurrentPage();
        }

        [Then(@"Healthcare Professional Details is filled")]
        public void ThenHealthcareProfessionalDetailsIsFilled(Table hcpDetails)
        {
            //Healthcare Professional Details assertions
            string hcpCountry = hcpDetails.Header.ElementAt(0);
            string hcpFirstName = hcpDetails.Header.ElementAt(1);
            string hcpLastName = hcpDetails.Header.ElementAt(2);

            Use<AddNewHCPFormPageModel>().VerifyHealthcareProfessionalDetailsSectionIsFilled(hcpCountry, hcpFirstName, hcpLastName);
        }

        [When(@"I fill in Product Information with following data:")]
        public void WhenIFillInProductInformationWithFollowingData(Table prodinf)
        {
            string therapeuticArea = prodinf.Header.ElementAt(0);
            string productBrandMolecule = prodinf.Header.ElementAt(1);
            string prodIndication = prodinf.Header.ElementAt(2);
            string protocolNumber = prodinf.Header.ElementAt(3);

            Use<AddNewHCPFormPageModel>().FillInProductInformationSection(therapeuticArea, productBrandMolecule, prodIndication, protocolNumber);
        }

        [Then(@"Product Information is filled correctly")]
        public void ThenProductInformationIsFilledCorrectly(Table prodinf)
        {
            string therapeuticArea = prodinf.Header.ElementAt(0);
            string productBrandMolecule = prodinf.Header.ElementAt(1);
            string prodIndication = prodinf.Header.ElementAt(2);
            string protocolNumber = prodinf.Header.ElementAt(3);

            Use<AddNewHCPFormPageModel>().VerifyProductInformationSectionIsFilled(therapeuticArea, productBrandMolecule, prodIndication, protocolNumber);
        }

        [When(@"I fill in Engagement Description with following data:")]
        public void WhenIFillInEngagementDescriptionWithFollowingData(Table engdesc)
        {
            string engagementTitle = engdesc.Header.ElementAt(0);
            string engagementCongress = engdesc.Header.ElementAt(1);
            string engagementType = engdesc.Header.ElementAt(2);
            string allDayEngagement = engdesc.Header.ElementAt(3);
            string engagementVenue = engdesc.Header.ElementAt(4);
            string engagementCity = engdesc.Header.ElementAt(5);
            string engagementCountry = engdesc.Header.ElementAt(6);
            string engagementStateProvince = engdesc.Header.ElementAt(7);
            string sciMedBusNeeds = engdesc.Header.ElementAt(8);
            string engagementObjective = engdesc.Header.ElementAt(9);
            string contractedService = engdesc.Header.ElementAt(10);
            string engagementDescription = engdesc.Header.ElementAt(11);

            Use<AddNewHCPFormPageModel>().FillInEngagementDescriptionSection(engagementTitle, engagementCongress, engagementType, allDayEngagement, engagementVenue, engagementCity, engagementCountry, engagementStateProvince, sciMedBusNeeds, engagementObjective, contractedService, engagementDescription);
        }

        [Then(@"Engagement Description is filled correctly")]
        public void ThenEngagementDescriptionIsFilledCorrectly(Table engdesc)
        {
            string engagementTitle = engdesc.Header.ElementAt(0);
            string engagementCongress = engdesc.Header.ElementAt(1);
            string engagementType = engdesc.Header.ElementAt(2);
            string allDayEngagement = engdesc.Header.ElementAt(3);
            string engagementVenue = engdesc.Header.ElementAt(4);
            string engagementCity = engdesc.Header.ElementAt(5);
            string engagementCountry = engdesc.Header.ElementAt(6);
            string engagementStateProvince = engdesc.Header.ElementAt(7);
            string sciMedBusNeeds = engdesc.Header.ElementAt(8);
            string engagementObjective = engdesc.Header.ElementAt(9);
            string contractedService = engdesc.Header.ElementAt(10);
            string engagementDescription = engdesc.Header.ElementAt(11);

            Use<AddNewHCPFormPageModel>().VerifyEngagementDescriptionSectionIsFilled(engagementTitle, engagementCongress, engagementType, allDayEngagement, engagementVenue, engagementCity, engagementCountry, engagementStateProvince, sciMedBusNeeds, engagementObjective, contractedService, engagementDescription);
        }

        [When(@"I fill in Affiliate Contact as (.*)")]
        public void WhenIFillInAffiliateContactAs(string affcontact)
        {
            Use<AddNewHCPFormPageModel>().FillInAffiliateContactListSection(affcontact);
        }

        [Then(@"Affiliate Contact is filled as (.*)")]
        public void ThenAffiliateContactIsFilledAs(string affcontact)
        {
            Use<AddNewHCPFormPageModel>().VerifyAffiliateContactSectionIsFilled(affcontact);
        }

        [When(@"I fill in HCP Role with following data:")]
        public void WhenIFillInHCPRoleWithFollowingData(Table hcprole)
        {
            string hcproleselect = hcprole.Header.ElementAt(0);
            string rationalForHCP = hcprole.Header.ElementAt(1);
            string areaofexpertise = hcprole.Header.ElementAt(2);

            Use<AddNewHCPFormPageModel>().FillInHCPRoleSection(hcproleselect, rationalForHCP, areaofexpertise);
        }

        [Then(@"HCP Role is filled correctly")]
        public void ThenHCPRoleIsFilledCorrectly(Table hcprole)
        {
            string hcpRoleSelect = hcprole.Header.ElementAt(0);
            string rationalForHCP = hcprole.Header.ElementAt(1);
            string areaOfExpertise = hcprole.Header.ElementAt(2);

            Use<AddNewHCPFormPageModel>().VerifyHCPRoleSectionIsFilled(hcpRoleSelect, rationalForHCP, areaOfExpertise);
        }

        [When(@"I fill in Fee for Service with following data:")]
        public void WhenIFillInFeeForServiceWithFollowingData(Table feeforservice)
        {
            string noFee = feeforservice.Header.ElementAt(0);
            string feeTotalActivityTime = feeforservice.Header.ElementAt(1);
            string feePrepTime = feeforservice.Header.ElementAt(2);
            string feeHourlyRate = feeforservice.Header.ElementAt(3);
            string feeFlatRate = feeforservice.Header.ElementAt(4);
            string feeTotalDisturbanceFee = feeforservice.Header.ElementAt(5);
            string feeCurrency = feeforservice.Header.ElementAt(6);

            if (noFee.Equals("Yes"))
            {
                Use<AddNewHCPFormPageModel>().FillInNoFeeForServiceSection(noFee);
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInFeeForServiceSection(noFee, feeTotalActivityTime, feePrepTime, feeHourlyRate, feeFlatRate, feeTotalDisturbanceFee, feeCurrency);
            }
        }

        [Then(@"Fee for Service is filled correctly")]
        public void ThenFeeForServiceIsFilledCorrectly(Table feeforservice)
        {
            string noFee = feeforservice.Header.ElementAt(0);
            string feeTotalActivityTime = feeforservice.Header.ElementAt(1);
            string feePrepTime = feeforservice.Header.ElementAt(2);
            string feeHourlyRate = feeforservice.Header.ElementAt(3);
            string feeFlatRate = feeforservice.Header.ElementAt(4);
            string feeTotalDisturbanceFee = feeforservice.Header.ElementAt(5);
            string feeCurrency = feeforservice.Header.ElementAt(6);

            Use<AddNewHCPFormPageModel>().VerifyFeeForServiceSectionIsFilled(noFee, feeTotalActivityTime, feePrepTime, feeHourlyRate, feeFlatRate, feeTotalDisturbanceFee, feeCurrency);
        }

        [When(@"I fill in Accomodation Description with following data:")]
        public void WhenIFillInAccomodationDescriptionWithFollowingData(Table accdesc)
        {
            string noAccomodation = accdesc.Header.ElementAt(0);
            string accNameToLookup = accdesc.Header.ElementAt(1);
            string accCostsPerNight = accdesc.Header.ElementAt(2);
            string accNrOfNights = accdesc.Header.ElementAt(3);
            string accCurrency = accdesc.Header.ElementAt(4);
            string accAddComment = accdesc.Header.ElementAt(5);

            if (noAccomodation.Equals("Yes"))
            {
                Use<AddNewHCPFormPageModel>().FillInNoAccommodationDescriptionSection(noAccomodation);
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInAccomodationHotelSection(accNameToLookup);
                Use<AddNewHCPFormPageModel>().FillInAccommodationDescriptionSection(accCostsPerNight, accNrOfNights, accCurrency, accAddComment);
            }
        }

        [Then(@"Accomodation Description is filled correctly")]
        public void ThenAccomodationDescriptionIsFilledCorrectly(Table accdesc)
        {
            string noAccomodation = accdesc.Header.ElementAt(0);
            string accNameToLookup = accdesc.Header.ElementAt(1);
            string accCostsPerNight = accdesc.Header.ElementAt(2);
            string accNrOfNights = accdesc.Header.ElementAt(3);
            string accCurrency = accdesc.Header.ElementAt(4);
            string accAddComment = accdesc.Header.ElementAt(5);

            Use<AddNewHCPFormPageModel>().VerifyAccomodationSectionIsFilled(noAccomodation, accNameToLookup, accCostsPerNight, accNrOfNights, accCurrency, accAddComment);
        }

        [When(@"I fill in Meal Description with following data:")]
        public void WhenIFillInMealDescriptionWithFollowingData(Table mealdesc)
        {
            string noMeal = mealdesc.Header.ElementAt(0);
            string mealType = mealdesc.Header.ElementAt(1);
            string mealEstCosts = mealdesc.Header.ElementAt(2);
            string mealNumberOfMeals = mealdesc.Header.ElementAt(3);
            string mealCurrency = mealdesc.Header.ElementAt(4);
            string mealRestaurantName = mealdesc.Header.ElementAt(5);
            string mealComments = mealdesc.Header.ElementAt(6);
            string breakfastIncluded = mealdesc.Header.ElementAt(7);

            if (noMeal.Equals("Yes"))
            {
                Use<AddNewHCPFormPageModel>().FillInNoMealDescriptionSection(noMeal);
            }
            else
            {
                if (breakfastIncluded.Equals("Yes"))
                {
                    Use<AddNewHCPFormPageModel>().FillInMealBreakfastIncluded();
                }
                Use<AddNewHCPFormPageModel>().FillInMealDescriptionSection(mealType, mealEstCosts, mealNumberOfMeals, mealCurrency, mealRestaurantName, mealComments);
            }
        }

        [Then(@"Meal Description is filled correctly")]
        public void ThenMealDescriptionIsFilledCorrectly(Table mealdesc)
        {
            string noMeal = mealdesc.Header.ElementAt(0);
            string mealType = mealdesc.Header.ElementAt(1);
            string mealEstCosts = mealdesc.Header.ElementAt(2);
            string mealNumberOfMeals = mealdesc.Header.ElementAt(3);
            string mealCurrency = mealdesc.Header.ElementAt(4);
            string mealRestaurantName = mealdesc.Header.ElementAt(5);
            string mealComments = mealdesc.Header.ElementAt(6);
            string breakfastIncluded = mealdesc.Header.ElementAt(7);

            Use<AddNewHCPFormPageModel>().VerifyMealSectionIsFilled(noMeal, mealType, mealEstCosts, mealNumberOfMeals, mealCurrency, mealRestaurantName, mealComments, breakfastIncluded);
        }

        [When(@"I fill in Travel Details with following data:")]
        public void WhenIFillInTravelDetailsWithFollowingData(Table travdet)
        {
            string noTravel = travdet.Header.ElementAt(0);
            string travelType = travdet.Header.ElementAt(1);
            string travelCategory = travdet.Header.ElementAt(2);
            string travelEstCosts = travdet.Header.ElementAt(3);
            string travelCurrency = travdet.Header.ElementAt(4);
            string travelDescription = travdet.Header.ElementAt(5);

            if (noTravel.Equals("Yes"))
            {
                Use<AddNewHCPFormPageModel>().FillInNoTravelDetailsSection(noTravel);
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInTravelDetailsSection(travelType, travelCategory, travelEstCosts, travelCurrency, travelDescription);
            }
        }

        [Then(@"Travel Details is filled correctly")]
        public void ThenTravelDetailsIsFilledCorrectly(Table travdet)
        {
            string noTravel = travdet.Header.ElementAt(0);
            string travelType = travdet.Header.ElementAt(1);
            string travelCategory = travdet.Header.ElementAt(2);
            string travelEstCosts = travdet.Header.ElementAt(3);
            string travelCurrency = travdet.Header.ElementAt(4);
            string travelDescription = travdet.Header.ElementAt(5);

            Use<AddNewHCPFormPageModel>().VerifyTravelDetailsSectionIsFilled(noTravel, travelType, travelCategory, travelEstCosts, travelCurrency, travelDescription);
        }

        [When(@"I fill in Other Costs with following data:")]
        public void WhenIFillInOtherCostsWithFollowingData(Table othcosts)
        {
            string noOtherCosts = othcosts.Header.ElementAt(0);
            string othCostsType = othcosts.Header.ElementAt(1);
            string othCostsAmount = othcosts.Header.ElementAt(2);
            string othCostsCurrency = othcosts.Header.ElementAt(3);
            string othCostsComment = othcosts.Header.ElementAt(4);

            if (noOtherCosts.Equals("Yes"))
            {
                // Skip section
            }
            else
            {
                Use<AddNewHCPFormPageModel>().FillInOtherCostsSection(noOtherCosts, othCostsType, othCostsAmount, othCostsCurrency, othCostsComment);
            }
        }

        [Then(@"Other Costs is filled correctly")]
        public void ThenOtherCostsIsFilledCorrectly(Table othcosts)
        {
            string noOtherCosts = othcosts.Header.ElementAt(0);
            string othCostsType = othcosts.Header.ElementAt(1);
            string othCostsAmount = othcosts.Header.ElementAt(2);
            string othCostsCurrency = othcosts.Header.ElementAt(3);
            string othCostsComment = othcosts.Header.ElementAt(4);

            Use<AddNewHCPFormPageModel>().VerifyOtherCostsSectionIsFilled(noOtherCosts, othCostsType, othCostsAmount, othCostsCurrency, othCostsComment);
        }

        [When(@"I fill in Local Requirements with following data:")]
        public void WhenIFillInLocalRequirementsWithFollowingData(Table locreq)
        {
            string localReqFull = locreq.Header.ElementAt(0);
            string locReqSubmit = locreq.Header.ElementAt(1);
            string locReqSpecify = locreq.Header.ElementAt(2);

            if (localReqFull.Equals("Yes"))
            {
                Use<AddNewHCPFormPageModel>().FillInLocalRequirementsFullfilled(localReqFull);
            }

            Use<AddNewHCPFormPageModel>().FillInLocalRequirementsSection(locReqSubmit, locReqSpecify);
        }

        [Then(@"Local Requirements is filled correctly")]
        public void ThenLocalRequirementsIsFilledCorrectly(Table locreq)
        {
            string localReqFull = locreq.Header.ElementAt(0);
            string locReqSubmit = locreq.Header.ElementAt(1);
            string locReqSpecify = locreq.Header.ElementAt(2);

            Use<AddNewHCPFormPageModel>().VerifyLocalRequirementsSectionIsFilled(localReqFull, locReqSubmit, locReqSpecify);
        }

        ///
        /// Other
        ///

        [When(@"I click Save Form Button")]
        public void WhenIClickSaveFormButton()
        {
            Use<AddNewHCPFormPageModel>().ClickSaveFormButton();
        }

        [When(@"User clicks Send updated form Button")]
        public void WhenUserClicksSendUpdatedFormButton()
        {
            Use<ViewHCPFormPageModel>().ClickSendUpdatedFormButton();
        }

        [Then(@"I write down form ID")]
        public void ThenIWriteDownFormID()
        {
            Use<ViewHCPFormPageModel>().SaveFormIDToConfig();
        }

        ///
        /// Notes and Attachments adding
        ///

        [When(@"User adds Note to Form")]
        public void WhenUserAddsNoteToForm()
        {
            Use<ViewHCPFormPageModel>().AddNewNoteToForm();
            StoreCurrentPageType();
            Create(new EditNotePageModel(Driver));
            Use<EditNotePageModel>().FillInNoteInformation(true,"yes","yes");
            Use<EditNotePageModel>().ClickSaveButton();
        }
        [Then(@"Note is added to form")]
        public void ThenNoteIsAddedToForm()
        {
            RestoreCurrentPage();
            //Assert
        }
        [When(@"User adds Attachment to Form")]
        public void WhenUserAddsAttachmentToForm()
        {
            Use<ViewHCPFormPageModel>().AddNewAttachmentToForm();
            StoreCurrentPageType();
            Create(new AttachFileToFormPageModel(Driver));
            Use<AttachFileToFormPageModel>().ChooseFileToAttachToForm();
        }
        [Then(@"Attachment is added to form")]
        public void ThenAttachmentIsAddedToForm()
        {
            RestoreCurrentPage();
            //Assert
        }

        /// <summary>
        /// Supporting roles adding
        /// </summary>
        
        [When(@"User adds (.*) as (.*) supporting role")]
        public void WhenUserAddsSupportingRole(string userName, string supportingRole)
        {
            Use<ViewHCPFormPageModel>().ClickAddSupportingRoleButton();
            StoreCurrentPageType();
            Create(new AddSupportingRolePageModel(Driver));
            Use<AddSupportingRolePageModel>().FillSupportingRole(userName, supportingRole);
            Use<AddSupportingRolePageModel>().ClickSaveButton();
        }

        [Then(@"User (.*) is added as (.*) supporting role")]
        public void ThenSupportingRoleIsAdded(string userName, string supportingRole)
        {
            RestoreCurrentPage();
            //assert
        }
        
        /// <summary>
        /// History section records connected steps
        /// </summary>

        [When(@"History Section has (.*) record")]
        public void WhenHistorySectionHasRecord(string recordToMatch)
        {
            //Assert if Created record is in history section
            //Make locator, put results to list and iterate over list to find matching record.
        }
    }
}
