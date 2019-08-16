using System;
using System.Collections.Generic;
using System.Text;
using FreeCRMSample.pages;
using FreeCRMSample.testbase;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace FreeCRMSample.pages
{
    public class LoginPage : TestBase
    {
        //PageFactory [or] Object Repository
        [FindsBy(How = How.Name, Using = "username")]
        IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement password;

        [FindsBy(How = How.ClassName, Using = "btn btn-small")]
        IWebElement loginBtn;

        [FindsBy(How = How.LinkText, Using = "Sign Up")]
        IWebElement signUpBtn;

        [FindsBy(How = How.XPath, Using = "//a[@class='navbar-brand']//img[@class='img-responsive']")]
        IWebElement crmLogo;

        [Obsolete]
        public LoginPage()
        {
            PageFactory.InitElements(TestBase.driver, this);  /*To initialize all the web-elements with driver 													we can use this method*/
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
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@value='Login']"))).Click();
            }
            catch(Exception e)
            {
               Console.WriteLine(e.Message);
            }
            return new HomePage();
        }
    }
}
