using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FreeCRMSample.pages;
using FreeCRMSample.testbase;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_JSON;
using Sikuli4Net.sikuli_UTIL;

namespace FreeCRMSample.pages
{
    public class LoginPage : TestBase
    {
        //PageFactory [or] Object Repository
        [FindsBy(How = How.Name, Using = "username")]
        IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@value='login']")]
        IWebElement loginBtn;

        [FindsBy(How = How.LinkText, Using = "Sign Up")]
        IWebElement signUpBtn;

        [FindsBy(How = How.XPath, Using = "//a[@class='navbar-brand']//img[@class='img-responsive']")]
        IWebElement crmLogo;
        APILauncher launch;
        Pattern Image1;
        Screen scr;
        [Obsolete]
        public LoginPage()
        {
            PageFactory.InitElements(TestBase.driver, this);  /*To initialize all the web-elements with driver 													we can use this method*/
            launch = new APILauncher(true);
            Image1 = new Pattern(@"resources/login.PNG");
            scr = new Screen();
        }

        public String ValidatePageTittle()
        {
            return driver.Title;
        }

        public Boolean ValidateCRMImage()
        {
            return crmLogo.Displayed;
        }

        public HomePage Login(String un, String pwd)
        {
            username.SendKeys(un);
            password.SendKeys(pwd);
            //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + loginBtn.Location.X + ")");
            //Actions act = new Actions(driver);
            //act.MoveToElement(loginBtn).Click().Build().Perform();
            loginBtn.Submit();
            Thread.Sleep(10000);
            return new HomePage();
        }
    }
}
