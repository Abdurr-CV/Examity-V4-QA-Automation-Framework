using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class InstructorsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void InstructorsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expEmail = getDataParser().extractDataInstructors("expEmail");
            string expUserID = getDataParser().extractDataInstructors("expUserID");
            string fName = getDataParser().extractDataInstructors("fName");
            string lName = getDataParser().extractDataInstructors("lName");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            InstructorsPage instructorPage = new InstructorsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            instructorPage.navigateToInstructorspage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            instructorPage.selectClientDropdown(x);
            instructorPage.typeEmailAddress(expEmail);
            instructorPage.typeUserID(expUserID);
            instructorPage.typeFirstName(fName);
            instructorPage.typeLastName(lName);
            instructorPage.selectSearch(expError, email, reportTab);
        }
    }
}
