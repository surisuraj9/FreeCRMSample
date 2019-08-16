using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using FreeCRMSample.util;

namespace FreeCRMSample.testbase
{
    public class TestBase
    {
        public static IWebDriver driver;

        public TestBase()
        {
            Console.WriteLine("Test base class Invoked");

        }
        public static void initialization()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            if (browserName.Equals("ff"))
                driver = new FirefoxDriver();
            if (browserName.Equals("chrome"))
                driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = ConfigurationManager.AppSettings["url"];
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(TestUtil.PAGE_LOAD_TIMEOUT);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(TestUtil.IMPLICIT_WAIT);

            

        }
    }
}
