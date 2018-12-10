using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading;
using Helper.ScreenshotRemoteWebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebTestAutomation.Steps;

namespace WebTestAutomation.Steps
{
    [Binding]
    public class Events : BaseStepDefinitions
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (Directory.Exists("report"))
            {
                string[] screenshotList = Directory.GetFiles("report/", "*.png");
                string[] sourceList = Directory.GetFiles("report/", "*.html");
                foreach (String screenshot in screenshotList)
                {
                    File.Delete(screenshot);
                }
                foreach (String source in sourceList)
                {
                    File.Delete(source);
                }
            }
            else
            {
                Directory.CreateDirectory("report");
            }

            DateTime start = DateTime.Now;
            TimeZoneInfo timezone = TimeZoneInfo.Local;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            String title = Assembly.GetExecutingAssembly().GetName().Name;
            Console.WriteLine("*** Project: " + title);
            Console.WriteLine("*** Test started: " + start.ToLongDateString() + " " + start.ToLongTimeString() + " " + timezone.Id);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ChooseBrowser();
            Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
            Driver.Manage().Window.Maximize();
            ICapabilities capabilities = ((IHasCapabilities)Driver).Capabilities;
            Console.WriteLine("*** Browser:" + capabilities.BrowserName + " " + capabilities.Version);
            FeatureInfo f = FeatureContext.Current.FeatureInfo;
            Console.WriteLine("*** Feature: " + f.Title);
            Console.WriteLine("*** Description: " + f.Description);
        }
        
        [BeforeScenario]
        public static void BeforeScenario()
        {
            ScenarioInfo s = ScenarioContext.Current.ScenarioInfo;
            Console.WriteLine("*** Scenario:" + s.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            //
        }

        [AfterStep]
        public void AfterStep()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                String guid = Guid.NewGuid().ToString();
                String screenshotFileName = guid + ".png";
                String sourceFileName = guid + ".html";
                TakeScreenshot("report/" + screenshotFileName);
                DumpSource("report/" + sourceFileName);
                Console.WriteLine("*** Screenshot: " + screenshotFileName);
                Console.WriteLine("*** Source: " + sourceFileName);
            }
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Driver.Quit();
        }

        [AfterTestRun]
        public static void ExecutePostTestActivities()
        {
            //Does not work with Nunit GUI
            //Hook is not implemented for this runner, addin only works for nunit-console
        }
    }
}