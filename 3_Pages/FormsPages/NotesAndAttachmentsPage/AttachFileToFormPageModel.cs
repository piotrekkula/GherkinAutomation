using System.Linq;
using OpenQA.Selenium;
using System.IO;
using System;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Note add/edit page and all actions that can be performed from it. 
    /// </summary>

    public class AttachFileToFormPageModel : AddNewHCPFormPageModel
    {
        //Button field locators
        private static readonly By fileSelectFileToAttachButtonSelector = By.XPath("//input[@id='file']");
        private static readonly By fileAttachFileButtonSelector = By.XPath("//input[@value='Attach File']");
        private static readonly By fileDoneButtonSelector = By.XPath("//input[@title='Done']");
        private static readonly By fileDoneAttachingMessageLabelSelector = By.XPath("//*[contains(text(),'File Name')]/../td[2]");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public AttachFileToFormPageModel(IWebDriver driver)
            : base(driver, fileDoneButtonSelector)
        {
        }
        public void ChooseFileToAttachToForm()
        {
            string basePathToExecutable = Directory.GetCurrentDirectory();
            string fileToAttachPath = basePathToExecutable + "\\ProjectFiles\\AttachMe.txt";

            Driver.FindElement(fileSelectFileToAttachButtonSelector).SendKeys(fileToAttachPath);
            Driver.FindElement(fileAttachFileButtonSelector).Click();
            WaitForObject(fileDoneAttachingMessageLabelSelector);
            Driver.FindElement(fileDoneButtonSelector).Click();   
        }
    }
}