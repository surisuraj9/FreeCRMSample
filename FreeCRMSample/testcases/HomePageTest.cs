using FreeCRMSample.pages;
using FreeCRMSample.testbase;
using FreeCRMSample.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMSample.testcases
{
    [TestClass]
    public class HomePageTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        TestUtil testUtil;
        ContactsPage contactsPage;

        public HomePageTest() : base()
        {
            Console.WriteLine("In Home Page Constructor");
        }

        //test cases should be separated -- independent with each other
        //before each test case -- launch the browser and login
        //@test -- execute test case
        //after each test case -- close the browser

        [TestInitialize]
        public void setUp()
        {
            initialization();
            testUtil = new TestUtil();
            contactsPage = new ContactsPage();
            loginPage = new LoginPage();
            homePage = loginPage.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }


        [TestMethod]
        public void VerifyHomePageTitleTest()
        {
            String homePageTitle = homePage.verifyHomePageTitle();
            Assert.AreEqual(homePageTitle, "CRMPRO", "Home page title not matched");
        }

        [TestMethod]

        public void VerifyUserNameTest()
        {
            testUtil.switchToFrame();
            Assert.IsTrue(homePage.verifyCorrectUserName());
        }

        [TestMethod]

        public void VerifyContactsLinkTest()
        {
            testUtil.switchToFrame();
            contactsPage = homePage.clickOnContactsLink();
        }



        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
