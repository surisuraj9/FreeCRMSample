using FreeCRMSample.testbase;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMSample.pages
{
    public class ContactsPage : TestBase
    {
        [FindsBy(How = How.XPath, Using= "//td[contains(text(),'Contacts')]")]
        IWebElement contactsLabel;

        [FindsBy(How = How.Id, Using= "first_name")]
        IWebElement firstName;

        [FindsBy(How = How.Id, Using = "surname")]
        IWebElement lastName;

        [FindsBy(How = How.Name, Using = "client_lookup")]
        IWebElement company;

        [FindsBy(How = How.XPath, Using= "//input[@type='submit' and @value='Save']")]
        IWebElement saveBtn;



        // Initializing the Page Objects:
        public ContactsPage()
        {
            PageFactory.InitElements(driver, this);
        }


        public Boolean VerifyContactsLabel()
        {
            return contactsLabel.Displayed;
        }


        public void SelectContactsByName(String name)
        {
            driver.FindElement(By.XPath("//a[text()='" + name + "']//parent::td[@class='datalistrow']"
                    + "//preceding-sibling::td[@class='datalistrow']//input[@name='contact_id']")).Click();
        }


        public void CreateNewContact(String title, String ftName, String ltName, String comp)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.Name("title")));
            select.SelectByText(title);

            firstName.SendKeys(ftName);
            lastName.SendKeys(ltName);
            company.SendKeys(comp);
            saveBtn.Click();

        }
    }
}
