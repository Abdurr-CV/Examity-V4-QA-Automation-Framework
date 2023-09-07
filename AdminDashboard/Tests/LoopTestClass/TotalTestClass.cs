using NUnit.Framework;
using AdminDashboard.Utilities;

namespace AdminDashboard
{
    public class ClassLoopTest : TestBase

    {
       /* [Test, Order(1)]
        public void AdminDashboard()
        {
            BrowserInitiation();
            AdminDashboardTest adminDashboardTest = new AdminDashboardTest();
            adminDashboardTest.AdminDashboardTestPage(getDriver());
        }

        [Test, Order(2)]
        public void InstructorDashboard()
        {
            BrowserInitiationSub();
            InstructorDashboardTest instructorDashboardTest = new InstructorDashboardTest();
            instructorDashboardTest.InstructorDashboardTestPage(getDriver());
        }

        [Test, Order(3)]
        public void StudentDashboard()
        {
            BrowserInitiationSub();
            StudentDashboardTest studentDashboardTest = new StudentDashboardTest();
            studentDashboardTest.StudentDashboardTestPage(getDriver());
        }

        [Test, Order(4)]
        public void AuditorDashboard()
        {
            BrowserInitiationSub();
            AuditorDashboardTest auditorDashboardTest = new AuditorDashboardTest();
            auditorDashboardTest.AuditorDashboardTestPage(getDriver());
        }*/

        [Test, Order(5)]
        public void OperationsDashboard()
        {
            BrowserInitiationOperations();
            OperationsDashboardTest operationsDashboardTest = new OperationsDashboardTest();
            operationsDashboardTest.OperationsDashboardTestPage(getDriver());
        }

        [Test, Order(6)]
        public void ProctorFlow()
        {
            BrowserInitiationProctorFlow();
            ProctorAvailabilityFlowTest proctorAvailabilityFlowTest = new ProctorAvailabilityFlowTest();
            proctorAvailabilityFlowTest.ProctorAvailabilityFlowTestPage(getDriver());
        }
    }
}