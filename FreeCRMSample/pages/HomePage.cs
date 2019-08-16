using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCRMSample.testbase;
using OpenQA.Selenium.Interactions;

namespace FreeCRMSample.pages
{
    public class HomePage : TestBase
    {
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'User: padmanabhuni suraj')]")]
        [CacheLookup]
        IWebElement userNameLabel;

	    [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Contacts')]")]
        IWebElement contactsLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'New Contact')]")]
        IWebElement newContactLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Deals')]")]
        IWebElement dealsLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Tasks')]")]
        IWebElement tasksLink;

        // Initializing the Page Objects:
        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }

        public String verifyHomePageTitle()
        {
            return driver.Title;
        }

        public Boolean verifyCorrectUserName()
        {
            return userNameLabel.Displayed;
        }

        public ContactsPage clickOnContactsLink()
        {
            contactsLink.Click();
            return new ContactsPage();
        }

        public DealsPage clickOnDealsLink()
        {
            dealsLink.Click();
            return new DealsPage();
        }


        public void clickOnNewContactLink()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(contactsLink).Build().Perform();
            newContactLink.Click();

        }
    }
}
