using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHCP._3_Pages.unused
{
    class Class1
    {
        /// <summary>
        /// Method that waits 'secondsToWait' for 'objectExpected' that needs to appear when we click 'objectClicked'.
        /// </summary>
        /// <param name="objectClicked">Object clicked</param>
        /// <param name="objectExpected">Object which we expect to appear</param>
        /// <param name="secondsToWait">How much time we want to wait</param>
        public void WaitForObjectAfterClick(By objectClicked, By objectExpected, byte secondsToWait)
        {
            int counter = 0;
            driver.FindElement(objectClicked).Click();

            do
            {
                System.Threading.Thread.Sleep(100);
                counter++;
                if (counter > secondsToWait * 10)
                {
                    System.Diagnostics.Debug.WriteLine("Expected element: " + objectExpected + " is not present");
                    //TakeScreenshotOfCurrentPage(objectExpected.);
                }
            }
            while (driver.FindElements(objectExpected).Count == 0);
        }


        /// <summary>
        /// Method serves multiple click 
        /// Sometimes Click() neither causes results nor returns error - then multiple calling of Click() is needed.
        /// </summary>
        /// <param name="bySelector"></param>
        public void ClickLinkWhileAddressRemainsUnchanged(By bySelector, int timeout = 10)
        {
            string basicAddress = Driver.Url;
            string newAddress = basicAddress;
            int time = 0;
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 2));
            do
            {
                try
                {
                    Driver.FindElement(bySelector).Click();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                newAddress = Driver.Url;
                SecondsToWait(1);
                time++;
            }
            while (basicAddress.Equals(newAddress) && (time != timeout));
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, defaultWaitTime));
        }

        /// <summary>
        /// Method checks if Picture Preview changes itself after mouse hover above link
        /// </summary>
        /// <param name="Object_1">is an object above which mouse pointer is hover </param>
        /// <param name="Object_2">in a preview object</param>
        /// <param name="secondsToWait"> is deadline for the method</param>
        public void WaitForObjectAfterHover(IWebElement Object_1, IWebElement Object_2, byte secondsToWait)
        {
            Actions action = new Actions(Driver);
            int counter = 0;
            action.MoveToElement(Object_1).Perform();
            do
            {
                System.Threading.Thread.Sleep(100);
                counter++;
                if (counter > secondsToWait * 10)
                {
                    TakeScreenshotOfCurrentPage(Object_1.Text);
                    Assert.Fail("Preview of: " + Object_1.Text + " is not present");
                }
            }
            while (!(Object_1.Text.Equals(Object_2.Text)));
        }

        /// <summary>
        /// Method to manage specific event
        /// </summary>
        /// <param name="Object">Object which method wait for</param>
        /// <param name="secondsToWait">Time Method waits while object is not visible</param>
        public void WaitForObjectAfterPerform(IWebElement Object, byte secondsToWait)
        {
            Actions action = new Actions(Driver);
            int counter = 0;
            do
            {
                try
                {
                    action.MoveToElement(Object).Perform();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                System.Threading.Thread.Sleep(100);
                counter++;
                if (counter > secondsToWait * 10)
                {
                    TakeScreenshotOfCurrentPage(Object.Text);
                    Assert.Fail(Object.Text + " is not visible");
                }
            }
            while (!Object.Displayed);
        }

        /// <summary>
        /// Method that checks if at least one occurence of the link element, which name is passed to the function as the parameter, is visible on the current page.
        /// Criteria for search is: element has to be of 'link' type and must have 'elementLinkText' phrase as the exact content of the text attribute. 
        /// </summary>
        /// <param name="elementLinkText">full name of the sought element.</param>
        /// <param name="searchingTime">maximum search time if no element is found (in seconds).</param>
        /// <returns>'true' if at least one element was found on the page, 'false' if no elements were found.</returns>
        public bool IsLinkElementOnCurrentPage(string elementLinkText, int searchingTime = 3)
        {
            SecondsToWait(2);
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, searchingTime));
            if (Driver.FindElements(By.LinkText(elementLinkText)).Count != 0)
            {
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, defaultWaitTime));
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Link Element " + elementLinkText + " was not found!");
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, defaultWaitTime));
                return false;
            }
        }

        /// <summary>
        /// Method that check if at least one occurence of the element, which name is passed to the function as the parameter, is visible on the current page.
        /// Criteria for search is: element must have 'elementText' phrase as the part of the 'text' attribute.
        /// </summary>
        /// <param name="elementText">name of the sought element. It may be only part of the name.</param>
        /// <param name="searchingTime">maximum search time if no element is found (in seconds).</param>
        /// <returns>'true' if at least one element was found on the page, 'false' if no elements were found.</returns>
        public bool IsTextElementOnCurrentPage(string elementText, int searchingTime = 3)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, searchingTime));
            if (Driver.FindElements(By.XPath(string.Format("//*[contains(text(),'{0}')]", elementText))).Count != 0)
            {
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, defaultWaitTime));
                return true;
            }
            else
            {
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, defaultWaitTime));
                return false;
            }
        }

        /// <summary>
        /// Set Current.Page to specific type of page model we have chosen
        /// Use this method when changing pages (from one page model to another).
        /// </summary>
        /// <param name="page">Page we want to use</param>
        protected void Create<T>(T page)
        {
            //ScenarioContext.Current[typeof(T).Name] = page;
        }

        /// <summary>
        /// To use any methods in declared page models, we need to utilize Use.
        /// It points to page model that we are using right now.
        /// </summary>
        /// <returns>Current page model type</returns>
        protected T Use<T>()
        {
            //return (T)ScenarioContext.Current[typeof(T).Name];
        }

        /// <summary>
        /// Method used to wait for text to appear(is not empty or null). 
        /// </summary>
        public void WaitForObjectText(string objectExpected)
        {
            byte counter = 0;
            do
            {
                Thread.Sleep(100);
                counter++;
                if (counter > secondsToWait * 10)
                {
                    System.Diagnostics.Debug.WriteLine("Expected Value: " + objectExpected + " is not present");
                }
            }
            while (Driver.FindElement(objectExpected).Text == "" || Driver.FindElement(objectExpected).Text == "&nbsp");
            
        }

        /// <summary>
        /// Method used to get optionID from select fields which do not have values but autogenerated ID.
        /// List of all select autogeneratedIDs is created. If value of selectOptionField has elementToCompare, then we receive OptionIDToCompare.
        /// </summary>
        /// <param name="selectOptionField">select field we give as parameter</param>
        /// <param name="elementToCompare">element to which we want to compare select field value</param>
        /// <returns>Option ID To compare</returns>
        public string CompareSelectWithOptionChosen(By selectOptionField, string elementToCompare)
        {
            List<IWebElement> allOptionsOnList = new List<IWebElement>();
            allOptionsOnList = Driver.FindElements(selectOptionField).ToList();
            string OptionIdToCompare = "";

            foreach (IWebElement Value in allOptionsOnList)
            {
                if (Value.Text == elementToCompare)
                {
                    OptionIdToCompare = Value.GetAttribute("id");
                }
            }
            return OptionIdToCompare;
        }


        /// <summary>
        /// Used to create instance without checking for ssl.rev_checks
        /// </summary>

        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-website-settings", "--disable-crl-sets", "--disable-web-security", "--disable-login-animations");
        Driver = new ChromeDriver(options);

        DesiredCapabilities cpb = DesiredCapabilities.Chrome();
        cpb.SetCapability("noWebsiteTestingDefaults", true);
        RemoteWebDriver driver = new RemoteWebDriver(cpb);
    }
}
