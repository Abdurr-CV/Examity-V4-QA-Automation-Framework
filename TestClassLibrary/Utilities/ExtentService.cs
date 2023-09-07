using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace PortalApplicationFramework.Utilities
{
    public class ExtentService
    {
        public static ExtentReports extent;
        public static ExtentReports GetExtent()
        {
            if(extent==null)
            {
                string WorkDirectory = Environment.CurrentDirectory;
                string ProjectDirectory = Directory.GetParent(WorkDirectory).FullName;
                string reportPath = ProjectDirectory + "/indexAAAAAAAAA.html";
                var htmlReporter = new ExtentHtmlReporter(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\Utilities\HTML Extension\index.html");
                htmlReporter.LoadConfig(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\extent-config.xml");
                var extent = new ExtentReports();
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Environment", "Test-environment");
                extent.AddSystemInfo("Host name", "Local host");
                extent.AddSystemInfo("QA", "Abdurrahman Raleem");
                extent.AddSystemInfo("Username", "RAbdur@examity.com");
            }
            return extent;
        }
    }
}
