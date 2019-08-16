using FreeCRMSample.testbase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FreeCRMSample.pages;
using System.Configuration;

namespace FreeCRMSample.testcases
{
    [TestClass]
    public class LoginPageTest : TestBase
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }
        LoginPage loginPage;
        HomePage homePage;
        public LoginPageTest() : base()
        {
            Console.WriteLine("In Login Page Constructor");
        }
        [TestInitialize]
        public void SetUp()
        {
            TestBase.initialization();
            loginPage = new LoginPage();
        }

        [TestMethod]
        public void validatePageTittleTest()
        {
            Assert.AreEqual(loginPage.ValidatePageTittle(), "CRMPRO - CRM software for customer "
                    + "relationship management, sales, and support.");
        }

        [TestMethod]
        public void ValidateCRMImageTest()
        {
            TestBase.driver.SwitchTo().ParentFrame();
            Assert.IsTrue(loginPage.ValidateCRMImage());
        }

        [TestMethod]
        public void LoginTest()
        {
            TestBase.driver.SwitchTo().ParentFrame();
            homePage = loginPage.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

        }

        [TestMethod]
        [DeploymentItem("FreeCRMSample\\resources\\FreeCRMTestData.xlsx")]
        [DataSource("MyExcelDataSource")]
        public void Test()
        {
            _testContextInstance.WriteLine(_testContextInstance.DataRow["ConnectionStrings"].ToString());
            Assert.IsTrue(true);

        }

        [TestCleanup]
        public void Teardown()
        {
            TestBase.driver.Quit();
        }

    }
}
