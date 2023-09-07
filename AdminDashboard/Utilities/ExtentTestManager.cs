using AventStack.ExtentReports;
using System;
using System.Runtime.CompilerServices;

namespace AdminDashboard.Utilities
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest parentTest;

        [ThreadStatic]
        private static ExtentTest childTest;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string Testname,string descirption=null)
        {
            parentTest=ExtentService.GetExtent().CreateTest(Testname, descirption);
            return parentTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string Testname, string descirption = null)
        {
            childTest = parentTest.CreateNode(Testname, descirption);
            return childTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return childTest;
        }
    }
}
