using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Configuration;
using System.Linq;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AdminDashboard.Utilities
{
    [TestFixture]
    public class TestBase : Base
    {
        public ExtentTest test;
        public static IWebDriver driver;
        public static IWebDriver driver1;

        [SetUp]
        public void StartBrowser()
        {
            test = Base.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public void BrowserInitiation()
        {
            String browser = ConfigurationManager.AppSettings["browser"];
            String url = ConfigurationManager.AppSettings["appUrl1"];
            InitBrowser(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void BrowserInitiationSub()
        {
            String url = ConfigurationManager.AppSettings["appUrl1"];
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void BrowserInitiationWFM()
        {
            /*String browser = ConfigurationManager.AppSettings["browser"];
            String url = ConfigurationManager.AppSettings["appUrl1"];*/
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //InitBrowser(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test.examity.com/wfm/");
        }

        public void BrowserInitiationOperations()
        {
            String browser = ConfigurationManager.AppSettings["browser"];
            String url = ConfigurationManager.AppSettings["appUrl1"];
            /*((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());*/
            InitBrowser(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test.examity.com/operations/");
        }

        public void BrowserInitiationProctorFlow()
        {
            String url = ConfigurationManager.AppSettings["appUrl1"];
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test.examity.com/proctordashboard/");
        }

        public void BrowserInitiationProctor()
        {
            InitBrowser("Edge");
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver1.Manage().Window.Maximize();
            driver1.Navigate().GoToUrl("https://test.examity.com/WFMportal/");
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
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver1 = new EdgeDriver();
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
            driver1.Quit();
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

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
        }

        public MediaEntityModelProvider CaptureScreenShot1(IWebDriver driver, String screenshotName)
        {
            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            var screenshot =  driver.TakeScreenshot(vcd).ToMagickImage().ToBase64();
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

        public IWebDriver getDriver1()
        {
            return driver1;
        }
    }
}
