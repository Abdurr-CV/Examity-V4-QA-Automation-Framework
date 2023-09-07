using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class HourlyExamVolumeTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void HourlyExamVolumeTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expStatus = getDataParser().extractDataHourlyExamVolume("expStatus");
            string expExamLevel = getDataParser().extractDataHourlyExamVolume("expExamLevel");

            HourlyExamVolumePage hourlyExamVolumePage = new HourlyExamVolumePage(driver);
            hourlyExamVolumePage.navigateToHourlyExamVolumepage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            hourlyExamVolumePage.selectClientDropdown(x);
            hourlyExamVolumePage.selectDateDetails();
            hourlyExamVolumePage.selectStatusdetails(expStatus);
            hourlyExamVolumePage.selectExamLevel(expExamLevel);
            hourlyExamVolumePage.SelectSearch();
        }
    }
}
