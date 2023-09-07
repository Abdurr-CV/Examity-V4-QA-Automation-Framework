using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PortalApplicationFramework.Utilities;
using System;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace PortalApplicationFramework
{
    [TestFixture]
    public class TestBase
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
            String url = ConfigurationManager.AppSettings["url"];

            InitBrowser(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = "https://test.examity.com/portalqa14/";
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
                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + StackTrace);
            }
            else
            {
                test.Pass("Test is passed");
            }
            Base.Extent.Flush();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenshotName)
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
