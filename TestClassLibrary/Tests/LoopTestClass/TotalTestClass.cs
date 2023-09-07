using NUnit.Framework;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    public class ClassLoopTest : TestBase

    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AAutomationContinuity(string userName,
                                          string password,
                                          string adminUserName,
                                          string adminPassword,
                                          string LoginAs)
        {
            string LoginUserName;
            string LoginPassword;
            BrowserInitiation();
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.AssertLogin();
            
            if (LoginAs == "Admin") 
            {
                LoginUserName = adminUserName;
                LoginPassword = adminPassword;
                loginPage.signIn(LoginUserName, LoginPassword);
                loginPage.signInAdmin();
            }
            else
            {
                LoginUserName = userName;
                LoginPassword = password;
                loginPage.signIn(LoginUserName, LoginPassword);
                string loginUrl = driver.Url;
                if (driver.Url.Contains("switchrole.aspx"))
                {
                    loginPage.signInUserProd();
                }
            }
        }

        [Test]
        public void AccountManagerReport()
        {
            AccountManagerReportTest accountMnager = new AccountManagerReportTest();
            accountMnager.AccountmanagerReportTestPage(getDriver());
        }

        [Test]
        public void Administration()
        {
            AdministrationTest administration = new AdministrationTest();
            administration.AdministrationTestPage(getDriver());
        }

        [Test]
        public void ExamStatusCount()
        {
            ExamStatusCountTest examStatusCount = new ExamStatusCountTest();
            examStatusCount.ExamStatusCountTestPage(getDriver());
        }

        [Test]
        public void ExamCountMonthly()
        {
            ExamCountMonthlyTest examCountMonthly = new ExamCountMonthlyTest();
            examCountMonthly.ExamCountMonthlyTestPage(getDriver());
        }

        [Test]
        public void DormantClient()
        {
            DormantClientReportTest dormantClient = new DormantClientReportTest();
            dormantClient.DormantClientTestPage(getDriver());
        }

        [Test]
        public void Enrollments()
        {
            EnrollmentsTest enrollments = new EnrollmentsTest();
            enrollments.EnrollmentsTestPage(getDriver());
        }

        [Test]
        public void BillingCustom()
        {
            BillingCustomTest billingCustom = new BillingCustomTest();
            billingCustom.BillingCustomTestPage(getDriver());
        }

        [Test]
        public void AuditDetails()
        {
            AuditDetailsTest auditDetails = new AuditDetailsTest();
            auditDetails.AuditTestPage(getDriver());
        }

        [Test]
        public void ExamSummaryCustom()
        {
            ExamSummaryCustomTest examSummaryCustom = new ExamSummaryCustomTest();
            examSummaryCustom.ExamSummaryCustomTestPage(getDriver());
        }

       /* [Test]
        public void ExamSummaryMonthly()
        {
            ExamSummaryMonthlyTest examSummaryMonthly = new ExamSummaryMonthlyTest();
            examSummaryMonthly.ExamSummaryMonthlyTestPage(getDriver());
        }*/

        [Test]
        public void HourlyExamVolume()
        {
            HourlyExamVolumeTest hourlyExamVolume = new HourlyExamVolumeTest();
            hourlyExamVolume.HourlyExamVolumeTestPage(getDriver());
        }

        [Test]
        public void Instructors()
        {
            InstructorsTest instructors = new InstructorsTest();
            instructors.InstructorsTestPage(getDriver());
        }

        [Test]
        public void KPI()
        {
            KPITest kPI = new KPITest();
            kPI.KPITestPage(getDriver());
        }

        [Test]
        public void ExamCountViewDetails()
        {
            ExamCountViewDetailsTest examCountViewDetails = new ExamCountViewDetailsTest();
            examCountViewDetails.ExamCountViewDetailsTestPage(getDriver());
        }

        [Test]
        public void Students()
        {
            StudentsTest students = new StudentsTest();
            students.StudentsTestPage(getDriver());
        }

        [Test]
        public void RevenueReport()
        {
            RevenueReportTest revenueReport = new RevenueReportTest();
            revenueReport.RevenueReportTestPage(getDriver());
        }

        [Test]
        public void ScheduledExamsMonthly()
        {
            ScheduledExamsMonthlyTest scheduledExamsMonthly = new ScheduledExamsMonthlyTest();
            scheduledExamsMonthly.SceduledExamsMonthlyTestPage(getDriver());
        }

        [Test]
        public void ScheduledExamsViewDetails()
        {
            ScheduledExamsViewDetailsTest scheduledExamsViewDetails = new ScheduledExamsViewDetailsTest();
            scheduledExamsViewDetails.ScheduledExamsViewDetailsTestPage(getDriver());
        }

        [Test]
        public void ScheduledExamsCustom()
        {
            ScheduledExamsCustomTest scheduledExamsMonthly = new ScheduledExamsCustomTest();
            scheduledExamsMonthly.ScheduledExamsCustomTestPage(getDriver());
        }

        [Test]
        public void ProctorSummary()
        {
            ProctorSummaryTest proctorSummaryTest = new ProctorSummaryTest();
            proctorSummaryTest.ProctorSummaryTestPage(getDriver());
        }

        [Test]
        public void ProctorUtilizationReport()
        {
            ProctorUtilizationReportTest proctorUtilizationReportTest = new ProctorUtilizationReportTest();
            proctorUtilizationReportTest.ProctorUtilizationReportTestPage(getDriver());
        }

        [Test]
        public void ProctorUtilizationReportMonthly()
        {
            ProctorUtilizationReportMonthlyTest proctorUtilizationReportMonthlyTest = new ProctorUtilizationReportMonthlyTest();
            proctorUtilizationReportMonthlyTest.ProctorUtilizationReportMonthlyTestPage(getDriver());
        }

        [Test]
        public void RevenueCustomReport()
        {
            RevenueCustomReportTest revenueCustomReportTest = new RevenueCustomReportTest();
            revenueCustomReportTest.RevenueCustomReportTestPage(getDriver());
        }

        [Test]
        public void MonthlyExamCountDeatils()
        {
            MonthlyExamCountDetailsTest monthlyExamCountDetailsTest = new MonthlyExamCountDetailsTest();
            monthlyExamCountDetailsTest.MonthlyExamCountDetailsTestPage(getDriver());
        }

        [Test]
        public void MonthlyExamCountGraph()
        {
            MonthlyExamCountGraphTest monthlyExamCountGraphTest = new MonthlyExamCountGraphTest();
            monthlyExamCountGraphTest.MonthlyExamCountGraphTestPage(getDriver());
        }

        [Test]
        public void ProctorShiftsCustomShiftSummary()
        {
            ProctorShiftsCustomShiftSummaryTest proctorShiftsCustomShiftSummaryTest = new ProctorShiftsCustomShiftSummaryTest();
            proctorShiftsCustomShiftSummaryTest.ProctorShiftsCustomShiftSummaryTestPage(getDriver());
        }

        [Test]
        public void ProctorShiftsDailyShiftAnalytics()
        {
            ProctorShiftsDailyShiftAnalyticsTest proctorShiftsDailyShiftAnalyticsTest = new ProctorShiftsDailyShiftAnalyticsTest();
            proctorShiftsDailyShiftAnalyticsTest.ProctorShiftsDailyShiftAnalyticsTestPage(getDriver());
        }

        [Test]
        public void EvaluationsSurveyDetails()
        {
            EvaluationsSurveyDetailsTest evaluationsSurveyDetailsTest = new EvaluationsSurveyDetailsTest();
            evaluationsSurveyDetailsTest.EvaluationsSurveyDetailsTestPage(getDriver());
        }

        [Test]
        public void EvaluationsSurveyGraph()
        {
            EvaluationsSurveyGraphTest evaluationsSurveyGraphTest = new EvaluationsSurveyGraphTest();
            evaluationsSurveyGraphTest.EvaluationsSurveyGraphTestPage(getDriver());
        }

        [Test]
        public void EvaluationsIndividualResponses()
        {
            EvaluationsIndividualResponsesTest evaluationsIndividualResponsesTest = new EvaluationsIndividualResponsesTest();
            evaluationsIndividualResponsesTest.EvaluationsIndividualResponsesTestPage(getDriver());
        }

        [Test]
        public void RevenueYTDGraph()
        {
            RevenueYTDGraphTest revenueYTDGraphTest = new RevenueYTDGraphTest();
            revenueYTDGraphTest.RevenueYTDGraphTestPage(getDriver());
        }

        [Test]
        public void RevenueYTDReport()
        {
            RevenueYTDReportTest revenueYTDReportTest = new RevenueYTDReportTest();
            revenueYTDReportTest.RevenueYTDReportTestPage(getDriver());
        }

        [Test]
        public void ExamSnapshot()
        {
            ExamSnapshotTest examSnapshot = new ExamSnapshotTest();
            examSnapshot.ExamSnapshotTestPage(getDriver());
        }

        [Test]
        public void ExamHistory()
        {
            ExamHistoryTest examHistory = new ExamHistoryTest();
            examHistory.ExamHistoryTestPage(getDriver());
        }

        /*[Test]
       public void ExamiGoTimestamp()
       {
           ExamiGoTimestampTest examiGoTimestamp = new ExamiGoTimestampTest();
           examiGoTimestamp.ExamiGoTimestampTestPage(getDriver());
       }*/

        /* [Test]
         public void ExamTimestamp()
         {
             ExamTimestampTest examTimestamp = new ExamTimestampTest();
             examTimestamp.ExamTimestampTestPage(getDriver());
         }*/

        /* [Test]
        public void ClientDetails()
        {
            ClientDetailsTest clientDetails = new ClientDetailsTest();
            clientDetails.ClientDetailsTestPage(getDriver());
        }*/

        /*[Test]
        public void BillingSummary()
        {
            BillingSummaryTest billingSummary = new BillingSummaryTest();
            billingSummary.BillingSummaryTestPage(getDriver());
        }*/

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractDataLoginCredentials("userName"),
                                          getDataParser().extractDataLoginCredentials("password"),
                                          getDataParser().extractDataLoginCredentials("adminUserName"),
                                          getDataParser().extractDataLoginCredentials("adminPassword"),
                                          getDataParser().extractDataLoginCredentials("LoginAs"));
        }
    }
}
