using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMSample.pages
{
    public class Test
    {
        public static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = "https://classic.crmpro.com/index.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.Name("username")).SendKeys("surajp");
            driver.FindElement(By.Name("password")).SendKeys("suraj1234");
            driver.FindElement(By.XPath("//input[@value='Login']")).Submit();


        }
    }
}
