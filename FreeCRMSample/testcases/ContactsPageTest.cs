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
    public class ContactsPageTest : TestBase
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }
        LoginPage loginPage;
        HomePage homePage;
        TestUtil testUtil;
        ContactsPage contactsPage;

        public ContactsPageTest() : base()
        {
            Console.WriteLine("In Contacts Test Page");

        }


        [TestInitialize]
        public void SetUp()
        {
            initialization();
	        testUtil = new TestUtil();
            contactsPage = new ContactsPage();
            loginPage = new LoginPage();
            homePage = loginPage.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
	        //TestUtil.runTimeInfo("error", "login successful");
	        testUtil.switchToFrame();
	        contactsPage = homePage.clickOnContactsLink();
        }

        [TestMethod]
        public void VerifyContactsPageLabel()
        {
            Assert.IsTrue(contactsPage.VerifyContactsLabel(), "contacts label is missing on the page");
        }

        [TestMethod]
        public void SelectSingleContactsTest()
        {
            contactsPage.SelectContactsByName("suraj suraj");
        }

    /*	@Test(priority=3)
        public void selectMultipleContactsTest(){
            contactsPage.selectContactsByName("test2 test2");
            contactsPage.selectContactsByName("ui uiii");

        }*/

        [TestMethod]
        [DeploymentItem("FreeCRMSample\\resources\\FreeCRMTestData.xlsx")]
        [DataSource("MyExcelDataSource")]
        public void ValidateCreateNewContact()
        {
            homePage.clickOnNewContactLink();
            contactsPage.CreateNewContact(_testContextInstance.DataRow["title"].ToString(), _testContextInstance.DataRow["firstName"].ToString(),
                _testContextInstance.DataRow["lastName"].ToString(), _testContextInstance.DataRow["company"].ToString());

        }


        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
