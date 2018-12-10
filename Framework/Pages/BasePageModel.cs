using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions.Internal;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Drawing.Imaging;

namespace WebTestAutomation.Pages
{
    public class BasePageModel
    {

        protected static readonly byte defaultWaitTime = 15;
        private IWebDriver driver;

        private void FindKnownElementOnPage(By knownElementOnPage)
        {
            Driver.GetElement(knownElementOnPage);
        }

        protected BasePageModel(IWebDriver webDriver, By knownElementOnPage, String loadUrl = "")
        {
            driver = webDriver;
            if (loadUrl != String.Empty)
            {
                driver.Navigate().GoToUrl(loadUrl);
            }
            FindKnownElementOnPage(knownElementOnPage);
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public IWebDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        protected T UseAsPopup<T>(IWebDriver driver)
        {
            try
            {
                ConstructorInfo c = typeof(T).GetConstructor(new Type[] { typeof(IWebDriver) });
                T t = (T)c.Invoke(new object[] { driver });
                return t;
            }
            catch (System.Reflection.TargetInvocationException)
            {
                throw new Exception("Page model constructor failed: " + typeof(T).ToString());
            }
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

        protected void ClickElement(By locator)
        {
            try
            {
                Driver.FindElement(locator).Click();
            }
            catch (ElementNotVisibleException)
            {
                throw new ElementNotVisibleException("Cannot click the element - element is not visible.\n Locator: " + locator.ToString());
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot click the element - element not found.\n Locator: " + locator.ToString());
            }
        }

        protected void SendKeysToElement(By locator, String text)
        {
            if (text != null)
            {
                try
                {
                    Driver.FindElement(locator).Clear();
                    Driver.FindElement(locator).SendKeys(text);
                }
                catch (NoSuchElementException)
                {
                    throw new NoSuchElementException("Cannot send text to the element - element not found.\n Locator: " + locator.ToString());
                }
                catch (ElementNotVisibleException)
                {
                    throw new ElementNotVisibleException("Cannot send text to the element - element is not visible.\n Locator: " + locator.ToString());
                }
            }
        }

        protected void SetCheckboxValue(By locator, bool state)
        {
            try
            {
                if (!Driver.FindElement(locator).Selected)
                {
                    if (state == true) Driver.FindElement(locator).Click();
                }
                else
                {
                    if (state == false) Driver.FindElement(locator).Click();
                }
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot set checkbox value - element not found.\n Locator: " + locator.ToString());
            }
            catch (ElementNotVisibleException)
            {
                throw new ElementNotVisibleException("Cannot set checkbox value - element is not visible.\n Locator: " + locator.ToString());
            }
        }

        protected void SetCheckboxValue(By locator, String state)
        {
            bool s;
            bool.TryParse(state, out s);
            SetCheckboxValue(locator, s);
        }

        protected void SelectFromDropdown(By locator, String name)
        {
            try
            {
                SelectElement s = new SelectElement(Driver.FindElement(locator));
                s.SelectByText(name);
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot select element from dropdown list - element not found.\n Locator: " + locator.ToString());
            }
        }

        protected String GetTextFromElement(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Text;
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot get text from element - element not found.\n Locator: " + locator.ToString());
            }
        }

        protected String GetValueFromElement(By locator)
        {
            try
            {
                return Driver.FindElement(locator).GetAttribute("value");
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot get value from element - element not found.\n Locator: " + locator.ToString());
            }
        }

        protected void SelectElementInMultiselect(By locator, String name)
        {
            try
            {
                SelectElement s = new SelectElement(Driver.FindElement(locator));
                IList<IWebElement> list = s.AllSelectedOptions;
                s.SelectByText(name);
                foreach (IWebElement e in list)
                {
                    if (e.Text != name)
                        s.DeselectByValue(e.GetAttribute("value"));
                }
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Cannot select element - element not found.\n Locator: " + locator.ToString());
            }
        }

        protected void WaitForObject(By expectedObject)
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(defaultWaitTime), TimeSpan.FromMilliseconds(100));
            IWebElement elementToWait = wait.Until<IWebElement>((d) => { return d.FindElement(expectedObject); });
        }

        private IAlert IsAlertPresent()
        {
            try
            {
                return Driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }

        protected void AcceptAlert()
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(defaultWaitTime), TimeSpan.FromMilliseconds(100));
            IAlert alert = wait.Until(Drv => IsAlertPresent());
            alert.Accept();
        }

        protected void DismissAlert()
        {
            WebDriverWait wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(defaultWaitTime), TimeSpan.FromMilliseconds(100));
            IAlert alert = wait.Until(Drv => IsAlertPresent());
            alert.Dismiss();
        }

        protected void ReadApplicationSettings()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("Error reading application settings: {0}]", e.ToString());
            }
        }

        protected void TakeScreenshot(String fileName)
        {
            Screenshot s = ((ITakesScreenshot)Driver).GetScreenshot();
            s.SaveAsFile(fileName, ImageFormat.Png);
        }
    }
}