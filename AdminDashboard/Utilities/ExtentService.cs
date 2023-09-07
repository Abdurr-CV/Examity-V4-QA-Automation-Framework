using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Configuration;
using System.IO;

namespace AdminDashboard.Utilities
{
    public class ExtentService
    {
        public static ExtentReports extent;
        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                string WorkDirectory = Environment.CurrentDirectory;
                string ProjectDirectory = Directory.GetParent(WorkDirectory).FullName;
                string reportPath = ProjectDirectory + "index.html";
                var htmlReporter = new ExtentHtmlReporter(@"C:\selenium_automation_framework\selenium_automation_framework\AdminDashboard\extent-config.xml");
                htmlReporter.LoadConfig(@"C:\selenium_automation_framework\selenium_automation_framework\AdminDashboard\extent-config.xml");
                var extent = new ExtentReports();
                extent = new ExtentReports();
                extent.AddSystemInfo("Environment", ConfigurationManager.AppSettings["appUrl1"]);
                extent.AddSystemInfo("Username", Environment.UserName);
                extent.AddSystemInfo("Machine", Environment.MachineName.ToString());
                extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}
