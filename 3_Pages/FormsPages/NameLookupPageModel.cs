using OpenQA.Selenium;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing pop-up Name Lookup page used to choose user for lookup fields
    /// </summary>

    public class NameLookupPageModel : AddNewHCPFormPageModel
    {
        //NameLookup Pop-up selectors
        public static readonly By popUpFramesetSelector = By.XPath("//frameset");
        public static readonly By searchFrameSelector = By.Id("searchFrame");
        public static readonly By resultsFrameSelector = By.Id("resultsFrame");
        public static readonly By nameSearchFieldSelector = By.XPath("//input[@id='lksrch']");
        public static readonly By GoButtonSelector = By.Name("go");
        public static readonly By listFieldSelector = By.XPath("//table[@class='list']");
        public static readonly By listFieldResultSelector = By.XPath("//a[contains(@onclick,'top.window.opener.lookupPick')]");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public NameLookupPageModel(IWebDriver driver)
            : base(driver, searchFrameSelector)
        {
        }

        /// <summary>
        /// Perform name lookup on NameLookup pop-up
        /// </summary>
        /// <param name="userToLookup">which user to find</param>
        public void PerformNameLookup(string userToLookup)
        {
            SwitchToFrame(0);
            SendKeysToElement(nameSearchFieldSelector, userToLookup);
            Driver.FindElement(GoButtonSelector).Click();
            //WaitForObject(resultsFrameSelector);
            SwitchToDefault();
            SwitchToFrame(1);
            WaitForObject(listFieldResultSelector);
            Driver.FindElement(listFieldResultSelector).Click();
        }

        /// <summary>
        /// Choose 1st user on list that was found
        /// </summary>
        /// <param name="userToChoose"></param>
        public void ChooseUserFromLookup()
        {
            
        }
    }
}