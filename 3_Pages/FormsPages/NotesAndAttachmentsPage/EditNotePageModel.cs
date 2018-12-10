using System.Linq;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Note add/edit page and all actions that can be performed from it. 
    /// </summary>

    public class EditNotePageModel : ViewHCPFormPageModel, IHasSaveButton, IHasCancelButton
    {
        //Note Information section selectors
        private static readonly By notePrivateFieldSelector = By.XPath("//label[contains(text(),'Private')]/../../td[2]/input");
        private static readonly By noteTitleFieldSelector = By.XPath("//label[contains(text(),'Title')]/../../td[2]/div/input");
        private static readonly By noteBodyFieldSelector = By.XPath("//label[contains(text(),'Body')]/../../td[2]/textarea");

        //Button field locators
        public static readonly By topSaveNoteButtonSelector = By.XPath("//h2[contains(text(),'Note Edit')]/../../td[2]/input[1]");
        public static readonly By topCancelNoteButtonSelector = By.XPath("//h2[contains(text(),'Note Edit')]/../../td[2]/input[3]");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public EditNotePageModel(IWebDriver driver)
            : base(driver, noteBodyFieldSelector)
        {
        }

        public void FillInNoteInformation(bool isNotePrivate,string noteTitle, string noteBody)
        {
            
            if (isNotePrivate.Equals("true"))
            {
                Driver.FindElement(notePrivateFieldSelector).Click();    
            }

            SendKeysToElement(noteTitleFieldSelector, noteTitle);
            SendKeysToElement(noteBodyFieldSelector, noteBody);
        }
        public void ClickSaveButton()
        {
            Driver.FindElement(topSaveNoteButtonSelector).Click();
        }
        public void ClickCancelButton()
        {
            Driver.FindElement(topCancelNoteButtonSelector).Click();
        }
    }
}
