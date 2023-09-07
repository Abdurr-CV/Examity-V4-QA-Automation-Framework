using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using AventStack.ExtentReports.Model;

namespace PortalApplicationFramework
{
    [SetUpFixture]
    public class Base
    {
        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void SetUp()
        {
            string WorkDirectory = Environment.CurrentDirectory;
            string ProjectDirectory = Directory.GetParent(WorkDirectory).FullName;
            string reportPath = ProjectDirectory + "/index.html";
            var htmlReporter = new ExtentHtmlReporter(@"C:\selenium_automation_framework\selenium_automation_framework\selenium_automation_framework\Utilities\HTML Extension\");
            htmlReporter.LoadConfig(@"C:\selenium_automation_framework\selenium_automation_framework\selenium_automation_framework\Utilities\extent-config.xml");
            var extent = new ExtentReports();
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Environment", "Test-environment");
            Extent.AddSystemInfo("Host name", "Local host");
            Extent.AddSystemInfo("QA", "Abdurrahman Raleem");
            Extent.AddSystemInfo("Username", "RAbdur@examity.com");
        }   

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
            builder.Attachments.Add("C:/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/HTML Extension/index.html");
            email.Subject = MailSubject;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
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
