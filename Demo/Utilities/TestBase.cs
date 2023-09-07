using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Linq;
using WebDriverManager.DriverConfigs.Impl;

namespace PortalApplicationFramework.Utilities
{
    [TestFixture]
    public class TestBase : Base
    {
        public ExtentTest test;
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            test = Base.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void BrowserInitiation()
        {
            String browser = ConfigurationManager.AppSettings["browser"];
            String url = ConfigurationManager.AppSettings["appurl"];

            InitBrowser(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        private void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
        }

        [OneTimeTearDown]
        public void ReportTeardown()
        {
            ExtentService.GetExtent().Flush();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [TearDown]
        public void Report1()
        {
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var StackTrace = TestContext.CurrentContext.Result.StackTrace;
            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed", CaptureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + StackTrace);
            }
            else
            {
                test.Pass("Test is passed");
                Base.Extent.RemoveTest(test);
            }
        }
        /* [TearDown]
         public void ReporttearDown()
         {
             try
             {
                 var status = TestContext.CurrentContext.Result.Outcome.Status;
                 var errormessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? ""
                     : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                 var stracktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                 switch (status)
                 {
                     case TestStatus.Failed:
                         ReportsLog.Fail("Test Fail");
                         ReportsLog.Fail(errormessage);
                         ReportsLog.Fail(stracktrace);
                         ReportsLog.Fail("failed", CapturesScreenShot(TestContext.CurrentContext.Test.Name));
                         break;
                     case TestStatus.Passed:
                         ReportsLog.Pass("Test Passed");
                         break;
                     case TestStatus.Skipped:
                         ReportsLog.Skip("Test Skipped");
                         break;
                 }
             }
             catch(Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 TestContext.Progress.WriteLine("closed");
             }
         }

         public MediaEntityModelProvider CapturesScreenShot(String testname)
         {
             var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
             return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot+testname).Build();
         }*/

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
    }
}
