using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using MimeKit;
using System.Configuration;

namespace PortalApplicationFramework.Utilities
{
    [SetUpFixture]
    public class Base
    {
        public static ExtentReports Extent;
        public IWebDriver driver;
        String url = ConfigurationManager.AppSettings["appurl"];

        [OneTimeSetUp]
        public void SetUp()
        {
            string WorkDirectory = Environment.CurrentDirectory;
            string ProjectDirectory = Directory.GetParent(WorkDirectory).FullName;
            string reportPath = ProjectDirectory + "/index.html";
            var htmlReporter = new ExtentHtmlReporter(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\Utilities\HTML Extension\index.html");
            htmlReporter.LoadConfig(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\extent-config.xml");
            var extent = new ExtentReports();
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Environment", url);
            Extent.AddSystemInfo("Username", Environment.UserName);
            Extent.AddSystemInfo("Machine", Environment.MachineName.ToString());
        }
       /* [OneTimeSetUp]
        public void reportsetup()
        {
            ExtentTestManager.CreateParentTest(GetType().Name);
        }*/

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [OneTimeTearDown, TestCaseSource("AddTestDataConfig")]
        public void WriteToFile()
        {
            string fromEmail = getDataParser().extractDataLoginCredentials("fromEmail");
            string fromEmailName = getDataParser().extractDataLoginCredentials("fromEmailName");
            string toEmail = getDataParser().extractDataLoginCredentials("toEmail");
            string toReceiverName = getDataParser().extractDataLoginCredentials("toReceiverName");
            string toEmail1 = getDataParser().extractDataLoginCredentials("toEmail1");
            string toReceiverName1 = getDataParser().extractDataLoginCredentials("toReceiverName1");
            string toEmail2 = getDataParser().extractDataLoginCredentials("toEmail2");
            string toReceiverName2 = getDataParser().extractDataLoginCredentials("toReceiverName2");
            string fromEmailPassword = getDataParser().extractDataLoginCredentials("fromEmailPassword");
            string MailBody = getDataParser().extractDataLoginCredentials("MailBody");
            string MailSubject = getDataParser().extractDataLoginCredentials("MailSubject");
            string smtpServer = getDataParser().extractDataLoginCredentials("smtpServer");

            Extent.Flush();
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromEmailName, fromEmail));
            email.To.Add(new MailboxAddress(toReceiverName, toEmail));
            email.Cc.Add(new MailboxAddress(toReceiverName1, toEmail1));
            email.Bcc.Add(new MailboxAddress(toReceiverName2, toEmail2));
            var builder = new BodyBuilder();
            builder.TextBody = MailBody;
            builder.Attachments.Add(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\Utilities\HTML Extension\index.html");
            email.Subject = MailSubject;
            email.Body = builder.ToMessageBody();
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(smtpServer, 587, false);
                smtp.Authenticate(fromEmail, fromEmailPassword);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot + screenshotName).Build();
        }
    }
}
