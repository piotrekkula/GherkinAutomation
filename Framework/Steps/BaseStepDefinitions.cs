using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Corsis.Xhtml;
using WebTestAutomation.Pages;
using WebTestAutomation.Steps.Helper;

namespace WebTestAutomation.Steps
{
    /// <summary>
    /// Base definitions to help navigate to different pages.
    /// </summary>
    [Binding]
    public class BaseStepDefinitions
    {
        public static IWebDriver Driver { get; set; }
        //private static ChromeDriverService ChromeBrowser;

        /// <summary>
        /// Set Current.Page to specific type of page model we have chosen
        /// Use this method when changing pages (from one page model to another).
        /// </summary>
        /// <param name="page">Page we want to use</param>
        protected void Create<T>(T page)
        {
            ScenarioContext.Current["Current.Page"] = page;
        }

        /// <summary>
        /// To use any methods in declared page models, we need to utilize Use.
        /// It points to page model that we are using right now.
        /// </summary>
        /// <returns>Current page model type</returns>
        protected T Use<T>()
        {
            try
            {
                return (ScenarioContext.Current.Get<T>("Current.Page"));
            }
            catch (InvalidCastException)
            {
                if (typeof(T).IsInterface)
                {
                    throw new Exception("Current Page model does not implement" + typeof(T).ToString() + " interface");
                }
                else
                {
                    throw new Exception("Current Page model cannot be cast to" + typeof(T).ToString() + " page model");
                }
            }
        }

        /// <summary>
        /// Store current page is usefull when we need to move to another page model,
        /// and we are not sure what page model we were using before switch.
        /// This happens when we are on dynamically chosen page model like pop-ups.
        /// </summary>
        /// <seealso cref="RestoreCurrentPage"/>
        protected void StoreCurrentPageType(){
            var t = ScenarioContext.Current["Current.Page"];
            ScenarioContext.Current["Current.PageType"] = t.GetType();
        }

        /// <summary>
        /// Restore current page is usefull when we need to move back to previously stored page model.
        /// Use this along with StoreCurrentPageType.
        /// </summary>
        /// <seealso cref="StoreCurrentPageType"/>
        protected void RestoreCurrentPage()
        {
            Type t = ScenarioContext.Current.Get<Type>("Current.PageType");
            try
            {
                ConstructorInfo c = t.GetConstructor(new Type[] { typeof(IWebDriver) });
                var n = c.Invoke(new object[] { Driver });
                ScenarioContext.Current["Current.Page"] = n;
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                String message = "Page model constructor failed: " + t.ToString();
                if (e.InnerException != null)
                {
                    message += "\n" + e.InnerException.Message;
                }
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Invoke constructor for chosen page which is inheriting from BasePageModel
        /// </summary>
        protected void SetCurrentPage<T>() where T : BasePageModel
        {
            try
            {
                ConstructorInfo c = typeof(T).GetConstructor(new Type[] { typeof(IWebDriver) });
                T t = (T)c.Invoke(new object[] { Driver });
                ScenarioContext.Current["Current.Page"] = t;
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                String message = "Page model constructor failed: " + typeof(T).ToString();
                if (e.InnerException != null)
                {
                    message += "\n" + e.InnerException.Message;
                }
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Choose a web browser on which tests will be performed from app.config file
        /// </summary>
        protected static void ChooseBrowser()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                switch (appSettings["browser"])
                {
                    case "IE":
                        InternetExplorerOptions optionIE = new InternetExplorerOptions();
                        optionIE.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        Driver = new InternetExplorerDriver(optionIE);
                        break;
                    case "Chrome":
                        ChromeOptions optionChrome = new ChromeOptions();
                        optionChrome.AddAdditionalCapability("chrome.noWebsiteTestingDefaults", true);
                        Driver = new ChromeDriver();
                        break;
                    case "Firefox":
                        Driver = new FirefoxDriver();
                        break;
                    default:
                        throw new Exception("Invalid browser specified in configuration file");
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("Error reading application settings: {0}]", e.ToString());
            }
        }

        /// <summary>
        /// Take a screenshot and save file!
        /// </summary>
        protected static void TakeScreenshot(String fileName)
        {
            Screenshot s = ((ITakesScreenshot)Driver).GetScreenshot();
            s.SaveAsFile(fileName, ImageFormat.Png);
        }

        /// <summary>
        /// If test fails we want to get Source code of the page.
        /// This method saves it as html file.
        /// </summary>
        protected static void DumpSource(String fileName)
        {
            String source = Driver.PageSource;
            var html = Html2Xhtml.RunAsFilter(stdin => stdin.Write(source), lineLength: 100, tabLength: 2).ReadToEnd();
            html = HttpUtility.HtmlEncode(html);
            File.WriteAllText(fileName, Reporting.preamble + html + Reporting.postamble);
        }
    }
}


