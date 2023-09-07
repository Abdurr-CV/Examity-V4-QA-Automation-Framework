using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class HourlyExamVolumeTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void HourlyExamVolumeTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expStatus = getDataParser().extractDataHourlyExamVolume("expStatus");
            string expExamLevel = getDataParser().extractDataHourlyExamVolume("expExamLevel");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            HourlyExamVolumePage hourlyExamVolumePage = new HourlyExamVolumePage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            hourlyExamVolumePage.navigateToHourlyExamVolumepage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            hourlyExamVolumePage.selectClientDropdown(x);
            hourlyExamVolumePage.selectDateDetails();
            hourlyExamVolumePage.selectStatusdetails(expStatus);
            hourlyExamVolumePage.selectExamLevel(expExamLevel);
            hourlyExamVolumePage.SelectSearch();
        }
    }
}
