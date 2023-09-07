using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class InstructorsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void InstructorsTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expEmail = getDataParser().extractDataInstructors("expEmail");
            string expUserID = getDataParser().extractDataInstructors("expUserID");
            string fName = getDataParser().extractDataInstructors("fName");
            string lName = getDataParser().extractDataInstructors("lName");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            InstructorsPage instructorPage = new InstructorsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            instructorPage.navigateToInstructorspage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            instructorPage.selectClientDropdown(x);
            instructorPage.typeEmailAddress(expEmail);
            instructorPage.typeUserID(expUserID);
            instructorPage.typeFirstName(fName);
            instructorPage.typeLastName(lName);
            instructorPage.selectSearch(expError, email);
        }
    }
}
