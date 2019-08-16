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
        LoginPage loginPage;
        HomePage homePage;
        TestUtil testUtil;
        ContactsPage contactsPage;

        int SheetNum = 1;


        public ContactsPageTest() : base()
        {
            Console.WriteLine("In Contacts Test Page");

        }


        [TestInitialize]
        public void setUp()
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
        public void selectSingleContactsTest()
        {
            contactsPage.SelectContactsByName("suraj suraj");
        }

    /*	@Test(priority=3)
        public void selectMultipleContactsTest(){
            contactsPage.selectContactsByName("test2 test2");
            contactsPage.selectContactsByName("ui uiii");

        }*/

        public Object[][] GetCRMTestData()
        {
            Object[][] data= TestUtil.GetTestData(SheetNum);
		    return data;
	    }


        [DataTestMethod]

        public void ValidateCreateNewContact(String title, String firstName, String lastName, String company)
        {
            homePage.clickOnNewContactLink();
            contactsPage.CreateNewContact(title, firstName, lastName, company);

        }


        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
