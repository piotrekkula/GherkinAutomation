using System.Configuration;
using OpenQA.Selenium;

namespace GherkinAutomation.Pages
{
    /// <summary>
    /// Class representing Login page and all actions that can be performed on it. 
    /// </summary>

    public class LoginPageModel : PageModel
    {
        //Login Page selectors
        public static readonly By loginInputSelector = By.XPath("//*[@id='username']");
        public static readonly By passwordInputSelector = By.XPath("//*[@id='password']");
        public static readonly By loginButtonSelector = By.XPath("//*[@id='Login']");
        
        //Logout Page selectors
        public static readonly By logoutMessageSelector = By.XPath("//div/div/h2[contains(text(),'You Are Now Logged Out.')]");
        
        public LoginPageModel(IWebDriver driver,string loadUrl = "baseUrl")
            : base(driver, loginInputSelector, ConfigurationManager.AppSettings[loadUrl])
        {
            ReadAppSettings();
        }

        /// <summary>
        /// Constructor used when object of child class instantiated.
        /// </summary>
        public LoginPageModel(IWebDriver driver, By knownElementOnPage)
            : base(driver, knownElementOnPage)
        {
        }

        /// <summary>
        /// Login information. Get user details from config.
        /// </summary>
        /// <param name="userToLogin">send which user should be log in</param>
        public void LogInToApplication(string userToLogin)
        {            
            string loginName = ConfigurationManager.AppSettings[userToLogin];
            string passwordText = ConfigurationManager.AppSettings[userToLogin + "Password"];

            WaitForObject(loginInputSelector);
            SendKeysToElement(loginInputSelector, loginName);

            WaitForObject(passwordInputSelector);
            SendKeysToElement(passwordInputSelector, passwordText);
        }
        public void ClickLoginButton()
        {
            Driver.FindElement(loginButtonSelector).Click();
        }
    }
}