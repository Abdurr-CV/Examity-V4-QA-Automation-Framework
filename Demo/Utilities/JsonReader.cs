using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PortalApplicationFramework.Utilities
{
    public class JsonReader
    {

        public string extractDataAccountManagerReport(String tokenName)
        {
            String myJsonString = File.ReadAllText(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\Utilities\TestDataFiles\AccountManagerReport-testData.json");
            var jsonobject = JToken.Parse(myJsonString);
            return jsonobject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataLoginCredentials(String tokenName)
        {
            String myJsonString = File.ReadAllText(@"C:\selenium_automation_framework\selenium_automation_framework\TestClassLibrary\Utilities\TestDataFiles\LoginCredentials-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataMonthlyReportsDateSelection(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/MonthlyReportsDateSelection.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataCustomReportsDateSelection(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/CustomReportsDateSelection.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataAdministration(String tokenName)
         {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/Administration-testData.json");
             var jsonObject = JToken.Parse(myJsonString);
             return jsonObject.SelectToken(tokenName).Value<string>();
         }
        
        public string extractDataAuditDetails(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestdataFiles/AuditDetails-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataBillingCustom(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/BillingCustom-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataBillingMonthly(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/BillingMonthly-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataEnrollments(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/Enrollments-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamCountMonthly(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamCountMonthly-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamCountViewDetails(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamCountViewDetails-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamHistory(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamHistory-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamiGoTimestamp(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamiGoTimestamp-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamSnapshot(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamSnapshot-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamStatusCount(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamStatusCount-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamSummaryCustom(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamSummaryCustom-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamSummaryMonthly(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamSummaryMonthly-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataExamTimestamp(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ExamTimestamp-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataInstructors(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/Instructors-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataKPI(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/KPI-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataStudents(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/Students-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataHourlyExamVolume(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/HourlyExamVolume-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataRevenueReport(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/RevenueReport-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataBillingSummary(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/BillingSummary-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataDormantClientReport(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/DormantClientReport-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataClientDetails(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:/Users/AbdurRahman/Downloads/selenium_automation_framework/selenium_automation_framework/selenium_automation_framework/Utilities/TestDataFiles/ClientDetails-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string extractDataEvaluations(String tokenName)
        {
            String myJsonString = File.ReadAllText(@"C:\selenium_automation_framework\selenium_automation_framework\selenium_automation_framework\Utilities\TestDataFiles\Evaluations-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
