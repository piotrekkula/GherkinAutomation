using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// // Most basic class. All page classes inherit from PageModel class. Consists of methods and configuration paths.
    /// </summary>
    public class PageModel
    {
        private IWebDriver driver;

        //Define general properties
        protected static readonly byte defaultWaitTime = 15;
        public static readonly By successMessageNextActionLinkSelector = By.ClassName("hyper_link");
        
        //loading indicator for AUTOSAVE
        public static readonly By loadingIndicator = By.XPath("//*[@class='loading-indicator-overlay']");
        
        //Search field container selectors
        public static readonly By searchFormInputSelector = By.XPath("//div[@class='searchBoxClearContainer']/input[@name='str']");
        public static readonly By searchFormSearchButtonSelector = By.Id("phSearchButton");
        public static readonly By formListFormIDLinkSelector = By.XPath("//div[@id='j_id0:theForm:pblock:table:0:j_id48']/a[@text]");

        //User navigation selectors
        public static readonly By userNavigationMenuButtonSelector = By.XPath("//*[@id='userNavLabel']");
        public static readonly By userNavigationMyProfileButtonSelector = By.XPath("//*[@id='userNav-menuItems']/a[contains(text(),'My Profile')]");
        public static readonly By userNavigationSetupButtonSelector = By.XPath("//*[@id='userNav-menuItems']/a[contains(text(),'Setup')]");
        public static readonly By userNavigationLogoutButtonSelector = By.XPath("//*[@id='userNav-menuItems']/a[contains(text(),'Logout')]");

        //Tab selectors
        public static readonly By tabsHomeButtonSelector = By.XPath("//a[@text='Home']");
        public static readonly By tabsHCPFormsButtonSelector = By.XPath("//a[contains(@title,'HCP Forms')]");
        public static readonly By tabsMyTeamButtonSelector = By.XPath("//a[@text='My Team']");
        public static readonly By tabsReportsButtonSelector = By.XPath("//a[@text='Reports']");
        public static readonly By tabsAllButtonSelector = By.ClassName("allTabsArrow");

        //Text
        public static readonly By newHCPEngagementMainTitle = By.XPath("//h2[contains(text(),'International HCP Engagement')]");

        //generic selectors used for GetObjectId() method to resolve locators on page - needs to be moved to support class.
        public static readonly By genericLabelReader = By.XPath("../../td/span/label");
        public static readonly By genericSelectField = By.XPath("//select");
        public static readonly By genericInputField = By.XPath("//input[@type='text']");
        public static readonly By genericTextAreaField = By.XPath("//textarea");
        public static readonly By genericLink = By.XPath("//a[@id]");
        public static readonly By genericButton = By.XPath("//input[@type='button']");
        public static readonly By genericRadioButton = By.XPath("//input[@type='radio']");
        public static readonly By genericCheckBox = By.XPath("//input[@type='checkbox']");

        //generic form Type variables
        public static readonly string formTypesHCP = "sHCP";
        public static readonly string formTypemHCP = "mHCP";
        public static readonly string formTypeLegacyHCP = "Legacy";
        public static readonly string formTypeuHCP = "uHCP";

        //generic form statuses
        public static readonly string formStatusDraft = "Draft";
        public static readonly string formStatusVerified = "Verified";
        public static readonly string formStatusSubmitted = "Submitted";
        public static readonly string formStatusRejected = "Rejected";

        /// <summary>
        /// This constructor allows to call a public method within PageModel class 
        /// without a need to know on which page you are - useful when e.g. checking
        /// list columns on different pages with the same method
        /// </summary>
        /// <param name="webDriver"></param>
        public PageModel(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        /// <summary>
        /// This is initial constructor used for navigating to first page using specified URL.
        /// </summary>
        public PageModel(IWebDriver webDriver, By knownElementOnPage, String loadUrl = "")
        {
            Driver = webDriver;
            if (loadUrl != String.Empty)
            {
                Debug.WriteLine("URL ========== >>>>  " + loadUrl);
                Driver.Navigate().GoToUrl(new Uri(loadUrl));
            }
            System.Threading.Thread.Sleep(2000);
            WaitForObject(knownElementOnPage);
            //Driver.FindElement(knownElementOnPage);
        }

        /// <summary>
        /// Driver is created. Driver is accesible through getter and setter methods. 
        /// Below statements (get {} and set {}) are C# 4.0 specific 
        /// </summary>
        public IWebDriver Driver
        {
            get { return this.driver; }
            set { this.driver = value; }
        }

        /// <summary>
        /// Get project settings.        
        /// </summary>
        public static void ReadAppSettings()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                Console.WriteLine();
                Console.WriteLine("Using AppSettings property.");
                Console.WriteLine("Application settings:");

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("[ReadAppSettings: {0}]", "No settings specified.");
                }
                for (int i = 0; i < appSettings.Count; i++)
                {
                    Console.WriteLine("#{0} Key: {1} Value: {2}", i, appSettings.GetKey(i), appSettings[i]);
                }
                Console.WriteLine("");
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[ReadAppSettings: {0}]", e.ToString());
            }
        }

        /// <summary>
        /// Sometimes we need to wait for some specific amount of time.
        /// </summary>
        public void SecondsToWait(int wait_in_sec)
        {
            System.Threading.Thread.Sleep(wait_in_sec * 1000);
        }

        /// <summary>
        /// Method that simulates refreshing current page. If the alert occurs after refresh then it is bypassed (accepted) by the function.
        /// </summary>
        public void RefreshPage(bool fullRefresh = false)
        {
            Actions action = new Actions(Driver);
            action.SendKeys(OpenQA.Selenium.Keys.LeftControl).SendKeys(OpenQA.Selenium.Keys.F5).Perform();

            try
            {
                SecondsToWait(1);
                Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            SecondsToWait(2);
        }

        /// <summary>
        /// When we need to fill a field with text. Clears input/textarea and writes text to it.
        /// </summary>
        public void SendKeysToElement(By knownElementOnPage, string text)
        {
            Driver.FindElement(knownElementOnPage).Clear();
            Driver.FindElement(knownElementOnPage).SendKeys(text);
        }

        /// <summary>
        /// This overload allows user to wait for save to finish before typing into the field.
        /// Salesforce showloading() function triggers on element.clear() action so we need to wait for it to finish before typing into it.
        /// Warning ! this method is a bit slow.
        /// </summary>
        public void SendKeysToElement(By knownElementOnPage, By elementToWaitFor, string text)
        {
            Driver.FindElement(knownElementOnPage).Click();
            WaitForSaveToFinish(elementToWaitFor);
            Driver.FindElement(knownElementOnPage).SendKeys(OpenQA.Selenium.Keys.LeftControl + "a");
            Driver.FindElement(knownElementOnPage).SendKeys(text);
        }

        /// <summary>
        /// Method to select specific item from dropdown list.
        /// </summary>
        public void ChooseAvailableElementFromList(By availableList, string optionToSelect)
        {
            SelectElement itemToSelect = new SelectElement(Driver.FindElement(availableList));
            itemToSelect.SelectByText(optionToSelect);
        }

        /// <summary>
        /// When we need to select item from dropdown and click add button.
        /// </summary>
        public void ChooseAvailableElementFromList(By availableList, By addButton, string optionToSelect)
        {
            SelectElement itemToSelect = new SelectElement(Driver.FindElement(availableList));
            itemToSelect.SelectByText(optionToSelect);
            Driver.FindElement(addButton).Click();
        }

        /// <summary>
        /// Method to select itemAvailable from dropdown availableList when user specify optionToSelect explicitly in code(not in feature).
        /// </summary>
        public void ChooseAvailableElementFromList(By availableList, By itemAvailable, int optionToSelect)
        {
            List<string> ListOfValues = new List<string>();
            List<IWebElement> allItemsAvailable = new List<IWebElement>();
            
            allItemsAvailable = Driver.FindElements(itemAvailable).ToList();

            foreach (IWebElement Value in allItemsAvailable)
            {
                ListOfValues.Add(Value.Text);
            }

            SelectElement itemToSelect = new SelectElement(Driver.FindElement(availableList));
            itemToSelect.SelectByText(ListOfValues[optionToSelect]);          
        }

        /// <summary>
        /// Method used to remove element from Chosen list.
        /// </summary>
        public void RemoveChosenElementFromList(By availableList, By removeButton, string optionToSelect)
        {
            SelectElement itemToSelect = new SelectElement(Driver.FindElement(availableList));
            itemToSelect.SelectByText(optionToSelect);
            Driver.FindElement(removeButton).Click();
        }

        protected T UseAsPopup<T>()
        {
            ConstructorInfo c = typeof(T).GetConstructor(new Type[] { typeof(IWebDriver) });
            T t = (T)c.Invoke(new object[] { Driver });
            return t;
        }

        protected void HandlePopup(Action lookupTrigger, Action lookupAction)
        {
            PopupWindowFinder popupFinder = new PopupWindowFinder(driver);
            String popupHandle = popupFinder.Invoke(lookupTrigger);
            String currentWindowHandle = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(popupHandle);
            lookupAction();
            driver.SwitchTo().Window(currentWindowHandle);
        }

        public string SwitchToPopUp()
        {
            List<string> WindowHandles = new List<string>();
            do
            {
                WindowHandles = Driver.WindowHandles.ToList();
            } while (WindowHandles.Count() < 2);

            Driver.SwitchTo().Window(WindowHandles[1]);
            return WindowHandles[0];
        }

        /// <summary>
        /// Method used to switch focus to pop-up window and return main window handle so we can switch back to main window later.
        /// </summary>
        public void SwitchToPopUp(By elementThatCreatesPopup)
        {
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            string newHandle = finder.Click(Driver.FindElement(elementThatCreatesPopup));
            Driver.SwitchTo().Window(newHandle);
        }

        /// <summary>
        /// Method used to switch focus to other window using window number.Window numbering starts at 0. 0 is main window.
        /// </summary>
        public void SwitchToWindow(int windowNumber)
        {
            List<string> WindowHandles = new List<string>();
            WindowHandles = Driver.WindowHandles.ToList();
            Driver.SwitchTo().Window(WindowHandles[windowNumber]);
        }

        /// <summary>
        /// Method used to switch focus to other window using window name.
        /// </summary>
        public void SwitchToWindow(string windowName)
        {
            Driver.SwitchTo().Window(windowName);
        }

        public void SwitchToDefault()
        {
            Driver.SwitchTo().DefaultContent();
        
        }

        /// <summary>
        /// Method used to switch focus to other frame using frame number. Frame numbering starts at 0. 0 is main frame.
        /// </summary>
        public void SwitchToFrame(int frameNumber)
        {
            Driver.SwitchTo().Frame(frameNumber);
        }

        /// <summary>
        /// Method used to switch focus to other frame using frame name.
        /// </summary>
        public void SwitchToFrame(string frameName)
        {
            Driver.SwitchTo().Frame(frameName);
        }

        /// <summary>
        /// Wait for specific elemnt to receive Value. Used for input fields which do not have Text but Value instead.
        /// </summary>
        public void WaitForObjectValue(By objectExpected, byte secondsToWait)
        {
            byte counter = 0;
            do
            {
                Thread.Sleep(100);
                counter++;
                if (counter > secondsToWait * 10)
                {
                    Debug.WriteLine("Expected Value: " + objectExpected + " is not present");
                }
            }
            while (Driver.FindElement(objectExpected).GetAttribute("value") == "" || Driver.FindElement(objectExpected).GetAttribute("value") == "&nbsp");
        }

        /// <summary>
        /// Wait for object to appear(be found). 
        /// Method uses defaultWaitTime to specify Timeout.
        /// </summary>
        public void WaitForObject(By objectExpected)
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(defaultWaitTime), TimeSpan.FromMilliseconds(10));
            IWebElement elementToWait = wait.Until<IWebElement>((d) => { return d.FindElement(objectExpected); });
        }

        /// <summary>
        /// Method used to wait for object to appear(be found). 
        /// Method uses custom time defined by user as Timeout(for situation where defaultWaitTime is not sufficient/needed).
        /// </summary>
        public void WaitForObject(By objectExpected, byte secondsToWait)
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(secondsToWait), TimeSpan.FromMilliseconds(10));
            IWebElement elementToWait = wait.Until<IWebElement>((d) => { return d.FindElement(objectExpected); });
        }

        /// <summary>
        /// Method used to wait for ajax showLoading() function to finish.
        /// Ajax creates save overlay to prevent changes on page. Method uses sleep for saves which might occur under 0,5 sec.
        /// If Save is fast and under 0,5 sec, then method does not check for element.
        /// </summary>
        /// <param name="objectExpected">Save locator/Loading locator/Loading Div locator</param>
        public void WaitForSaveToFinish(By objectExpected)
        {
            Thread.Sleep(500);
            while (Driver.FindElements(objectExpected).Count() != 0)
            {
                //Debug.WriteLine("Expected object: " + objectExpected + " is still present");
            };
        }

        /// <summary>
        /// Method used to split currency name from format US(US Dollar) to US and (US Dollar).
        /// It is needed for assertions as only US should show as value.
        /// </summary>
        /// <param name="stringToSplit">Currency var</param>
        /// <param name="splitter">Splitter used, in case of currency it should be '(' .</param>
        /// <returns></returns>
        public static string CurrencySplitString(string stringToSplit, char splitter)
        {
            string[] words = stringToSplit.Split(splitter);
            return words[0];
        }

        /// <summary>
        /// Helper Method used to read IDs for selectors when user provides idToObtain | TODO:Improve to get Labels needed
        /// </summary>
        /// <param name="idToObtain">Id which we want to get for example select field, input fields, buttons (uses generic locators) etc.</param>
        public void GetElementsId(By idToObtain)
        {
            List<IWebElement> allItemsAvailable = new List<IWebElement>();
            List<string> ListOfValues = new List<string>();
            allItemsAvailable = Driver.FindElements(idToObtain).ToList();

            //Write to Screen preformatted locators so user can copy them and paste in new class.
            //Format is like: public static readonly By (idName) = By.Id("<id>");
            //User still needs to name locator.
            foreach (IWebElement Value in allItemsAvailable)
            {
                if (Value.GetAttribute("Id") != null)
                {
                    ListOfValues.Add(Value.GetAttribute("Id"));
                    Console.WriteLine("public static readonly By (idName) = By.Id(\"" + Value.GetAttribute("Id") + "\");");
                }
                else
                {
                    ListOfValues.Add(Value.GetAttribute("Name"));
                    Console.WriteLine("public static readonly By (idName) = By.Name(\"" + Value.GetAttribute("Name") + "']\");");
                }
            }
        }

        /// <summary>
        /// Method used to resolve objects on page and provide them in ordered fashion with comments and already declared.
        /// You can use it for getting object locators on page to speed up new page model creation.
        /// </summary>
        public void ResolveObjectsOnPage()
        {
            System.Diagnostics.Debug.WriteLine("//Select field locators");
            GetElementsId(genericSelectField);
            System.Diagnostics.Debug.WriteLine("//Input field locators");
            GetElementsId(genericInputField);
            System.Diagnostics.Debug.WriteLine("//Textarea field locators");
            GetElementsId(genericTextAreaField);
            System.Diagnostics.Debug.WriteLine("//Link field locators");
            GetElementsId(genericLink);
            System.Diagnostics.Debug.WriteLine("//Button field locators");
            GetElementsId(genericButton);
            System.Diagnostics.Debug.WriteLine("//Radio-button field locators");
            GetElementsId(genericRadioButton);
            System.Diagnostics.Debug.WriteLine("//Checkbox field locators");
            GetElementsId(genericCheckBox);
        }

        public void IsFormInStatus(By formStatusSelector,string formStatus)
        {
            switch (formStatus)
            {
                case "Draft":
                    Assert.True(Driver.FindElement(formStatusSelector).Text.Equals(formStatus), "Form is not in Draft Status!");
                    break;
                case "Verified":
                    Assert.True(Driver.FindElement(formStatusSelector).Text.Equals(formStatus), "Form is not in Verified Status!");
                    break;
                default:
                    break;
            }
        }
        public void ClickNameLookupButton(By LookupButton)
        {
            Driver.FindElement(LookupButton).Click();
        }
        public void LogOutOfApplication()
        {   
            Driver.FindElement(userNavigationMenuButtonSelector).Click();
            Driver.FindElement(userNavigationLogoutButtonSelector).Click();
        }
        public string GetCurrentPageTitle
        {
            get { return driver.Title; }
        }
        public void TakeScreenshotOfCurrentPage(string screenShotName)
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            string pathToFile = "";   // FULFILL path
            string fileName = string.Format("{0}{1}-{2:yyyy-MM-dd_hh-mm-ss-tt}", pathToFile, screenShotName, DateTime.Now);
            ss.SaveAsFile(fileName + ".png", ImageFormat.Png);
        }
        public static object GetClipboardData()
        {
            object ret = null;
            ThreadStart method = delegate()
            {
                System.Windows.Forms.IDataObject dataObject = Clipboard.GetDataObject();
                if (dataObject != null && dataObject.GetDataPresent(DataFormats.Text))
                {
                    ret = dataObject.GetData(DataFormats.Text);
                }
            };

            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                Thread thread = new Thread(method);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
            else
            {
                method();
            }

            return ret;
        }
        public static void ClearClipboard()
        {
            ThreadStart method = delegate()
            {
                Clipboard.Clear();
            };

            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                Thread thread = new Thread(method);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
            else
            {
                method();
            }
        }
        public static void SendTextToClipboard(string myText)
        {
            ThreadStart method = delegate()
            {
                Clipboard.Clear();
                Clipboard.SetText(myText);
            };

            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                Thread thread = new Thread(method);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
            else
            {
                method();
            }
        }
        public void ClickBackSpaceKey()
        {
            Actions action = new Actions(Driver);
            action.SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
        }
        public void NavigateBrowserBack()
        {
            Driver.Navigate().Back();
        }
        public void DoubleClickElement(By onElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(Driver.FindElement(onElement)).DoubleClick();
            action.Perform();
        }
    }
}