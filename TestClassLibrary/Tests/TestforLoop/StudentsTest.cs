using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class StudentsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void StudentsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClientGroup = getDataParser().extractDataStudents("expClientGroup");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expEmail = getDataParser().extractDataStudents("expEmail");
            string expUserID = getDataParser().extractDataStudents("expUserID");
            string fName = getDataParser().extractDataStudents("fName");
            string lName = getDataParser().extractDataStudents("lName");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            StudentsPage studentsPage = new StudentsPage(driver);
            studentsPage.navigateToStudentspage(reportTab, LoginpageUrl);
            studentsPage.selectClientGroupDropdown(expClientGroup);
            int x = Int32.Parse(expClient);
            studentsPage.selectClientDropdown(x);
            studentsPage.typeEmailAddress(expEmail);
            studentsPage.typeUserID(expUserID);
            studentsPage.typeFirstName(fName);
            studentsPage.typeLastName(lName);
            studentsPage.selectSearch(expError, email, reportTab);
        }
    }
}
