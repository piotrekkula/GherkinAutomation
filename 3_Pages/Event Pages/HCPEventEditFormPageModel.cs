using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Helper.Interfaces;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Event Edit Form page and all actions that can be performed from it. 
    /// Even Edit page is triggered when User wants to create a specific event.
    /// </summary>

    public class HCPEventEditFormPageModel : PageModel
    {
        //HCP Engagement selectors
        public static readonly By eventEditMainTitleLabelSelector = By.XPath("//h2[@class='mainTitle']");

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public HCPEventEditFormPageModel(IWebDriver driver)
            : base(driver, eventEditMainTitleLabelSelector)
        {
        }
    }
}