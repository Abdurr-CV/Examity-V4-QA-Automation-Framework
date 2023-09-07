using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using AventStack.ExtentReports;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace AdminDashboard.Utilities
{
    public class BasePage : TestBase
    {
        public IWebDriver driver;
        public IWebDriver driver1;

        ExtentTest test = Base.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void ReportLog(string status, string ReportLog)
        {
            var StackTrace = TestContext.CurrentContext.Result.StackTrace;
            if (status == "Failed")
            {
                test.Log(Status.Fail, ReportLog + StackTrace);
            }
            else
            {
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Log(Status.Pass, ReportLog);
            }
        }

        public void EnterValues(IWebElement element, String value)
        {
            element.SendKeys(value);
        }

        public void FasterSleep()
        {
            Thread.Sleep(10000);
        }

        public void HardSleep()
        {
            Thread.Sleep(5000);
        }

        public void MediumSleep()
        {
            Thread.Sleep(3000);
        }

        public void QuickSleep()
        {
            Thread.Sleep(500);
        }

        public void ScreenCapture(IWebDriver driver, string Name)
        {
            var MethodName = TestContext.CurrentContext.Test.MethodName.ToString();
            DateTime time = DateTime.Now;
            String fileName = (MethodName) + time.ToString("_h_mm_ss") + ".png";
            test.Pass(Name, CaptureScreenShot1(driver, fileName));
            //VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            //driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(@"C:\selenium_automation_framework\selenium_automation_framework\AdminDashboard\Utilities\Screenshots\" + fileName);
        }

        public static string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            StringBuilder stringBuilder = new StringBuilder(length);
                for (int i = 0; i<length; i++)
                {
                    int randomIndex = random.Next(chars.Length);
                    stringBuilder.Append(chars[randomIndex]);
                }
                return stringBuilder.ToString();
        }

        public static string GenerateRandomDoubleNumber(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(chars.Length);
                stringBuilder.Append(chars[randomIndex]);
            }
            return stringBuilder.ToString();
        }

        public static string GenerateRandomLetter(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(chars.Length);
                stringBuilder.Append(chars[randomIndex]);
            }
            return stringBuilder.ToString();
        }

        public void WaitToBeClickable(IWebDriver driver, string element, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath(element)));
        }
    }
}