using OpenQA.Selenium;
using System.Diagnostics;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing New HCP Engagement page and all actions that can be performed on it.
    /// This is the page where User chooses which type of form to create.
    /// </summary>

    public class NewHCPEngagementPageModel : PageModel, IHasNextButton, IHasCancelButton
    {
        //Text selectors - for assertions
        public static readonly By NewHCPEngagementMainTitle = By.XPath("//tr/td/h2[contains(text(),'International HCP Engagement Request Form')]");
        
        //Radio-Button selectors
        public static readonly By sHCPFormButton = By.XPath("//label/b[contains(text(),'Single HCP Engagement Request Form (sHCP):')]/../../input");
        public static readonly By mHCPFormButton = By.XPath("//label/b[contains(text(),'Multiple HCP Engagement Request Form (mHCP):')]/../../input");
        public static readonly By LegacyFormButton = By.XPath("//label/b[contains(text(),'Unexpected Ad Hoc Spend Reporting iHCP Form (aHCP):')]/../../input");
        public static readonly By uHCPFormButton = By.XPath("//label/b[contains(text(),'Unexpected Ad Hoc Spend Reporting iHCP Form (uHCP):')]/../../input"); 
        
        //Next/Cancel selectors
        public static readonly By NewFormHCPNextButton = By.XPath("//input[@value='Cancel']/../input[@value='Next']");
        public static readonly By CancelButton = By.XPath("//input[@value='Next']/../input[@value='Cancel']");

        /// <summary>
        /// Constructor used when new object of current page is created for the first time. 
        /// </summary>
        public NewHCPEngagementPageModel(IWebDriver driver)
            : base(driver, NewHCPEngagementMainTitle)
        {
        }

        /// <summary>
        /// Legacy button should be hidden for users which do not have admin rights
        /// </summary>
        public bool IsNewLegacyFormButtonPresentOnPage()
        {
            if (Driver.FindElements(LegacyFormButton).Count != 0)
            {
                System.Diagnostics.Debug.WriteLine("Bug: Legacy button was found!");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Legacy button is hidden.");
                return false;
            }
        }

        /// <summary>
        /// Check which radio button is selected
        /// </summary>
        public bool IsNewsHCPFormButtonSelected()
        {
            if (Driver.FindElement(sHCPFormButton).Selected)
            {
                Debug.WriteLine("sHCP Form.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsNewmHCPFormButtonSelected()
        {
            if (Driver.FindElement(mHCPFormButton).Selected)
            {
                Debug.WriteLine("mHCP Form.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsNewuHCPFormButtonSelected()
        {
            if (Driver.FindElement(uHCPFormButton).Selected)
            {
                Debug.WriteLine("uHCP Form.");
                return true;
            }
            else
            {
                return false;
            }
        }

        ///
        /// Select type of form we want to create by selecting respective radio buttons
        /// 
        public void ClicksHCPFormRadioButton()
        {
            Driver.FindElement(sHCPFormButton).Click();
        }
        public void ClickmHCPFormRadioButton()
        {
            Driver.FindElement(mHCPFormButton).Click();
        }
        public void ClickuHCPFormRadioButton()
        {
            Driver.FindElement(uHCPFormButton).Click();
        }

        /// <summary>
        /// Create the form itself
        /// </summary>
        public void ClickNextButton()
        {
            Driver.FindElement(NewFormHCPNextButton).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(CancelButton).Click();
        }
    }
}