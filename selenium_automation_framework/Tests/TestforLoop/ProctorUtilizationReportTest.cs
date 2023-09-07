using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    class ProctorUtilizationReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorUtilizationReportTestPage(IWebDriver driver)

        {
            string expProctor = getDataParser().extractDataLoginCredentials("expProctor");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ProctorUtilizationReportPage proctorUtilizationReportPage = new ProctorUtilizationReportPage(driver);
            proctorUtilizationReportPage.navigateToProctorUtilizationReportPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expProctor);
            proctorUtilizationReportPage.selectProctorDropdown(x);
            proctorUtilizationReportPage.selectMonthDropdown(expMonth);
            proctorUtilizationReportPage.selectYearDropdown(expYear);
            proctorUtilizationReportPage.selectSearch(expError, email);
        }
    }
}
