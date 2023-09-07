using NUnit.Framework;
using OpenQA.Selenium;
using AdminDashboard.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace AdminDashboard.PageObjects
{
    class StudentDashboardPage : BasePage
    {
        public StudentDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;
        public IWebDriver driver1;
        public static string AppoinmentID = "";
        public static string CourseIDRandom;
        public string KeyFullName;
        public string KeyLNameRandom;
        public string parentWindowHandle;

        // LOGIN IN AS ADMIN
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement StudentUserName;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement StudentPassword;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "lblConfirmNewPassword")]
        private IWebElement AssertPasswordSet;
        [FindsBy(How = How.Id, Using = "txtCurrentPassword")]
        private IWebElement CurrentPW;
        [FindsBy(How = How.Id, Using = "txtNewPassword")]
        private IWebElement NewPW;
        [FindsBy(How = How.Id, Using = "txtConfirmNewPassword")]
        private IWebElement ConfirmNewPW;
        [FindsBy(How = How.Id, Using = "btnSave_input")]
        private IWebElement SavePWSet;
        [FindsBy(How = How.XPath, Using = "//font[text()='New password has been updated successfully.']")]
        private IWebElement AssertPWSet;
        [FindsBy(How = How.Id, Using = "imgOK_input")]
        private IWebElement PWSetOkayButton;

        // UPDATE MY PROFILE
        [FindsBy(How = How.Id, Using = "ctl00_lnkProfile")]
        private IWebElement MyProfileTab;
        [FindsBy(How = How.Id, Using = "hlkSystemReadyness")]
        private IWebElement AssertMyProfile;
        [FindsBy(How = How.Id, Using = "hlkSystemReadyness")]
        private IWebElement SystemRequirementsCheck;
        [FindsBy(How = How.Id, Using = "imgHead")]
        private IWebElement SysytemCheckPageAssert;
        [FindsBy(How = How.Id, Using = "WCStatusIcon")]
        private IWebElement WebcamReadiness;
        [FindsBy(How = How.Id, Using = "MStatusIcon")]
        private IWebElement MicrophoneReadiness;
        [FindsBy(How = How.Id, Using = "OSStatusIcon")]
        private IWebElement OSSystemReadiness;
        [FindsBy(How = How.Id, Using = "BStatusIcon")]
        private IWebElement BrowserReadiness;
        [FindsBy(How = How.Id, Using = "SpeedTestStatus_down")]
        private IWebElement InternetSpeedReadiness;

        // ACCOUNT INFORMATION
        [FindsBy(How = How.Id, Using = "RadButton1_input")]
        private IWebElement EditAccountInformation;
        [FindsBy(How = How.Id, Using = "txtFirstName")]
        private IWebElement FirstName;
        [FindsBy(How = How.Id, Using = "txtLastName")]
        private IWebElement LastName;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement EmailAddress;
        [FindsBy(How = How.Id, Using = "txtCountryCode")]
        private IWebElement PhoneCountryCode;
        [FindsBy(How = How.Id, Using = "txtPhoneNumber")]
        private IWebElement PhoneNumber;
        [FindsBy(How = How.Id, Using = "ddlTimeZone_Arrow")]
        private IWebElement TimeZoneDropdown1;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlTimeZone_DropDown']/div/ul/li")]
        private IList<IWebElement> TimeZoneSelectionStudent;
        [FindsBy(How = How.Id, Using = "RadButton2_input")]
        private IWebElement SaveAccountInformation;

        // EXAMISHOW
        [FindsBy(How = How.Id, Using = "IdentificationFileUpload")]
        private IWebElement ChoosePictureFile;
        [FindsBy(How = How.Id, Using = "btnSaveImage_input")]
        private IWebElement UploadButton;
        [FindsBy(How = How.XPath, Using = "//font[text()='Photo ID uploaded successfully.']")]
        private IWebElement ExamiShowAssert;

        // EXAMIKNOW
        [FindsBy(How = How.Id, Using = "btnEdit_input")]
        private IWebElement ExamiknowEditButton;
        [FindsBy(How = How.Id, Using = "ddlSecurityQuestion1_Arrow")]
        private IWebElement DropdownQuestion1;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlSecurityQuestion1_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectQuestion1;
        [FindsBy(How = How.Id, Using = "txtAnswer1")]
        private IWebElement SecurityAnswer1;
        [FindsBy(How = How.Id, Using = "ddlSecurityQuestion2_Arrow")]
        private IWebElement DropdownQuestion2;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlSecurityQuestion2_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectQuestion2;
        [FindsBy(How = How.Id, Using = "txtAnswer2")]
        private IWebElement SecurityAnswer2;
        [FindsBy(How = How.Id, Using = "ddlSecurityQuestion3_Arrow")]
        private IWebElement DropdownQuestion3;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlSecurityQuestion3_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectQuestion3;
        [FindsBy(How = How.Id, Using = "txtAnswer3")]
        private IWebElement SecurityAnswer3;
        [FindsBy(How = How.Id, Using = "btnSave_input")]
        private IWebElement SaveSecurityQuestionForm;
        [FindsBy(How = How.XPath, Using = "//font[text()='Security questions updated successfully.']")]
        private IWebElement ExamiknowAssert;

        // EXAMIKEY
        [FindsBy(How = How.Id, Using = "rbtnKeyEdit_input")]
        private IWebElement ExamikeyEditButton;
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement ExamikeyFirstName;
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement ExamikeyLastName;
        [FindsBy(How = How.Id, Using = "firstNameLastName")]
        private IWebElement ExamikeyFandLName;
        [FindsBy(How = How.Id, Using = "refirstNameLastName")]
        private IWebElement ReExamikeyFandLName;
        [FindsBy(How = How.Id, Using = "btniputSave")]
        private IWebElement SaveExamikey;

        // EXAM SCHEDULING
        [FindsBy(How = How.Id, Using = "ctl00_lnkSchedule")]
        private IWebElement ExamSchedulingTab;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_imgHead")]
        private IWebElement ExamSchedulePageAssert;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_drpInstructor_Input")]
        private IWebElement InstructorDropdownVisibility;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_drpInstructor_Arrow")]
        private IWebElement InstructorDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_StudentContent_drpInstructor_DropDown']/div/ul/li[2]")]
        private IWebElement InstructorSelection;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_drpCourse_Arrow")]
        private IWebElement CourseDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_StudentContent_drpCourse_DropDown']/div/ul/li[2]")]
        private IWebElement CourseSelection;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_drpExam_Arrow")]
        private IWebElement ExamDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_StudentContent_drpExam_DropDown']/div/ul/li[2]")]
        private IWebElement ExamSelection;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_lblExamDuration")]
        private IWebElement ExamDurationAssert;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnOnDemand")]
        private IWebElement OnDemandSchedulingButton;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnSchedule")]
        private IWebElement ScheduleButton;
        [FindsBy(How = How.ClassName, Using = "rwInnerSpan")]
        private IWebElement ScheduleConfirmation;

        // STEP 2 SNAPSHOT
        [FindsBy(How = How.ClassName, Using = "container_inner")]
        private IWebElement Step1PageAssert;
        [FindsBy(How = How.XPath, Using = "//span[@id='btnNext']")]
        private IWebElement Step1NextButton;

        // STEP 3 BILLING SUBMISSION
        [FindsBy(How = How.Id, Using = "js_form_column_address")]
        private IWebElement BillingPageAssert;
        [FindsBy(How = How.Id, Using = "s2id_dr_currency_select")]
        private IWebElement CurrencySelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='select2-drop']/ul/li")]
        private IList<IWebElement> CurrencySelection;
        [FindsBy(How = How.Id, Using = "bill_address_email")]
        private IWebElement BillingEmail;
        [FindsBy(How = How.Id, Using = "bill_address_first_name")]
        private IWebElement BillingFirstName;
        [FindsBy(How = How.Id, Using = "bill_address_last_name")]
        private IWebElement BillingLastName;
        [FindsBy(How = How.Id, Using = "bill_address_company")]
        private IWebElement BillingCompany;
        [FindsBy(How = How.Id, Using = "bill_address_address_1")]
        private IWebElement BillingStreetAddress;
        [FindsBy(How = How.Id, Using = "bill_address_city")]
        private IWebElement BillingCity;
        [FindsBy(How = How.Id, Using = "bill_address_postal_code")]
        private IWebElement BillingPostalCode;
        [FindsBy(How = How.Id, Using = "cc_number")]
        private IWebElement CreditCardNumber;
        [FindsBy(How = How.Id, Using = "csc")]
        private IWebElement CreditCardCSV;
        [FindsBy(How = How.Id, Using = "s2id_js_cc_exp_month")]
        private IWebElement CCMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='select2-drop']/ul/li")]
        private IList<IWebElement> CCMonthSelection;
        [FindsBy(How = How.Id, Using = "s2id_js_cc_exp_year")]
        private IWebElement CCYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='select2-drop']/ul/li")]
        private IList<IWebElement> CCYearSelection;
        [FindsBy(How = How.Id, Using = "js_button_submit_review")]
        private IWebElement BillingDetailsSubmit;

        // BUY NOW PAGE
        [FindsBy(How = How.Id, Using = "js_cart_review")]
        private IWebElement FinalReviewPageAssert;
        [FindsBy(How = How.Id, Using = "js_button_submit_confirm")]
        private IWebElement FinalSubmitButton;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement ScheduleConfirmationOKButton;

        // RESCHEDULE EXAM
        [FindsBy(How = How.Id, Using = "ctl00_lnkMyExams")]
        private IWebElement ExamRescheduleTab;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_gvStudentHome_ctl00_ctl04_lnkReschdule")]
        private IWebElement ExamRescheduleLink;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnReschedule")]
        private IWebElement RescheduleButton;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnSchedule")]
        private IWebElement RescheduleButtonAfter;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnLogin_input")]
        private IWebElement RescheduleOKButton;

        // CANCEL EXAM
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnCancel")]
        private IWebElement CancelExamBUtton;
        [FindsBy(How = How.ClassName, Using = "rwInnerSpan")]
        private IWebElement ConfirmCancellation;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_lblInfo")]
        private IWebElement ExamCancellationAssert;
        [FindsBy(How = How.XPath, Using = "//span[@id='btnLogin']")]
        private IWebElement OKbuttonFinal;

        // STUDENT PROCTOR FLOW
        [FindsBy(How = How.Id, Using = "ctl00_lnkStart")]
        private IWebElement StartExamTab;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_gvStartExam_ctl00_ctl04_lnkAction")]
        private IWebElement ConnectToProctorButton;
        [FindsBy(How = How.XPath, Using = "//tr[@id='ctl00_StudentContent_gvStartExam_ctl00__0']/td[1]")]
        private IWebElement appoinmentID;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnProceed")]
        private IWebElement ProceedButton;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnNext")]
        private IWebElement NextButtonPostProceed;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_txtAnswer1")]
        private IWebElement ExamiKNOWQuestion;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnSubmit")]
        private IWebElement ExamiKNOWSubmitButton;
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement ExamiKEYFirstname;
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement ExamiKEYLastname;
        [FindsBy(How = How.Id, Using = "firstNameLastName")]
        private IWebElement ExamiKEYFullname;
        [FindsBy(How = How.Id, Using = "submitenter")]
        private IWebElement ExamiKEYSubmitButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='0']")]
        private IList<IWebElement> RadioButtonsUserAgreement;
        [FindsBy(How = How.XPath, Using = "//input[@value='rbt_SpecialInstructions']")]
        private IList<IWebElement> SpecialInstructionRadioButton;
        [FindsBy(How = How.Id, Using = "ctl00_StudentContent_btnSubmit")]
        private IWebElement UserAgreementSubmitButton;
        [FindsBy(How = How.Id, Using = "BeginExamWithAutoPassword")]
        private IWebElement BeginExamButton;

        // SURVEY
        [FindsBy(How = How.XPath, Using = "//a[text()='Survey']")]
        private IWebElement SurveyLink;
        [FindsBy(How = How.ClassName, Using = "mainmenu")]
        private IWebElement SurveyPageAssert;
        [FindsBy(How = How.Id, Using = "ctrl_1780_8")]
        private IWebElement ProctorRating;
        [FindsBy(How = How.Id, Using = "ctrl_1781_1")]
        private IWebElement Improvement1;
        [FindsBy(How = How.Id, Using = "ctrl_1781_3")]
        private IWebElement Improvement3;
        [FindsBy(How = How.Id, Using = "ctrl_1781_2")]
        private IWebElement Improvement2;
        [FindsBy(How = How.Id, Using = "ctrl_1782_9")]
        private IWebElement ExamityRecommendation;
        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement SurveySubmitButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='Survey details submitted successfully.']")]
        private IWebElement SurveySubmissionAssert;

        public void LoginAsStudent(string instructorPassword)
        {
            try
            {
                EnterValues(StudentUserName, InstructorDashboardPage.studentUserID);
                ReportLog("Passed", "Entered student username as " + InstructorDashboardPage.studentUserID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter student username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(StudentPassword, instructorPassword);
                ReportLog("Passed", "Entered student password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter student password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LoginButton);
                ReportLog("Passed", "Clicked on login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on login button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertPasswordSet.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CurrentPW, instructorPassword);
                ReportLog("Passed", "Entered current password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter current password");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(NewPW, instructorPassword);
                ReportLog("Passed", "Entered new password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter new password");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ConfirmNewPW, instructorPassword);
                ReportLog("Passed", "Re-entered the new password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't re-enter the new password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SavePWSet);
                ReportLog("Passed", "Clicked on PW save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on PW save button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertPWSet.Displayed);
                ReportLog("Passed", "Asserted password reset confirmation text");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert password reset confirmation text");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PWSetOkayButton);
                ReportLog("Passed", "Clicked on password reset confirmation okay button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on password reset confirmation okay button");
                throw ex;
            }
            QuickSleep();
        }

        public void ProfileUpdation()
        {
            try
            {
                ClickElement(MyProfileTab);
                ReportLog("Passed", "Clicked on profile tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on profile tab");
                throw ex;
            }
            HardSleep();
            try
            {
                Assert.True(AssertMyProfile.Displayed);
                ReportLog("Passed", "Asserted profile set-up page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert profile set-up page");
                throw ex;
            }
            QuickSleep();
            try
            {
                parentWindowHandle = driver.CurrentWindowHandle;
                ClickElement(SystemRequirementsCheck);
                ReportLog("Passed", "Clicked on system requirement check link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on system requirement check link");
                throw ex;
            }
            MediumSleep();
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[3]);
                ReportLog("Passed", "Opened new window");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't open new window");
                throw ex;
            }
            FasterSleep();
            try
            {
                Assert.True(SysytemCheckPageAssert.Displayed);
                ReportLog("Passed", "Asserted system check page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert system check page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(WebcamReadiness.Displayed);
                ReportLog("Passed", "Asserted Web-cam readiness");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Web-cam readiness");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(MicrophoneReadiness.Displayed);
                ReportLog("Passed", "Asserted microphone readiness");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert microphone readiness");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(OSSystemReadiness.Displayed);
                ReportLog("Passed", "Asserted operating system");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert operating system");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(BrowserReadiness.Displayed);
                ReportLog("Passed", "Asserted browser version compatibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert browser version compatibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(InternetSpeedReadiness.Displayed);
                ReportLog("Passed", "Asserted internet speed requirement");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert internet speed requirement");
                throw ex;
            }
            ScreenCapture(driver, "System readyness check");
            QuickSleep();
            driver.SwitchTo().Window(driver.WindowHandles[3]).Close();
            driver.SwitchTo().Window(parentWindowHandle);
        }

        public void AccountInformation(string timeZone)
        {
            try
            {
                ClickElement(EditAccountInformation);
                ReportLog("Passed", "Clicked on edit button for account information");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on edit button for account information");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(TimeZoneDropdown1);
                ReportLog("Passed", "Clicked on time-zone dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on time-zone dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement TimeZone in TimeZoneSelectionStudent)
                {
                    if (TimeZone.Text.Contains(timeZone))
                    {
                        ClickElement(TimeZone);
                        break;
                    }
                }
                ReportLog("Passed", "Selected a time zone as " + timeZone);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a time zone");
                throw ex;
            }
            QuickSleep();
            try
            {
                string CountryCode = GenerateRandomNumber(2);
                EnterValues(PhoneCountryCode, CountryCode);
                ReportLog("Passed", "Entered the student country code as " + CountryCode);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student country code");
                throw ex;
            }
            QuickSleep();
            try
            {
                string phoneNumber = GenerateRandomNumber(12);
                QuickSleep();
                Actions TwoClick = new Actions(driver);
                TwoClick.SendKeys(PhoneNumber, phoneNumber).Perform();
                ReportLog("Passed", "Entered the student phone number as " + phoneNumber);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student phone number");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SaveAccountInformation);
                ReportLog("Passed", "Clicked on account information save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on account information save button");
                throw ex;
            }
            QuickSleep();
        }

        public void examiSHOW()
        {
            try
            {
                string imagePath = @"C:\Users\AbdurRahman\Pictures\Saved Pictures\ExamiSHOWimg.JPG";
                EnterValues(ChoosePictureFile, imagePath);
                ReportLog("Passed", "Uploaded picture using the path " + imagePath);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't upload picture");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(UploadButton);
                ReportLog("Passed", "Clicked on picture upload button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on picture upload button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamiShowAssert.Displayed);
                ReportLog("Passed", "Asserted picture upload");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert picture upload");
                throw ex;
            }
            MediumSleep();
        }

        public void examiKNOW(string question1,
                              string question2,
                              string question3,
                              string securityAnswer)
        {
            try
            {
                ClickElement(ExamiknowEditButton);
                ReportLog("Passed", "Clicked on edit button for examiKNOW");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on edit button for examiKNOW");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DropdownQuestion1);
                ReportLog("Passed", "Clicked on question dropdown 1");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on question dropdown 1");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement Question1 in SelectQuestion1)
                {
                    if (Question1.Text.Contains(question1))
                    {
                        ClickElement(Question1);
                        break;
                    }
                }
                ReportLog("Passed", "Selected security question 1, " + question1);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select security question 1");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SecurityAnswer1, securityAnswer);
                ReportLog("Passed", "Entered the security answer-1 as " + securityAnswer);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the security answer-1");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DropdownQuestion2);
                ReportLog("Passed", "Clicked on question dropdown 2");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on question dropdown 2");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement Question2 in SelectQuestion2)
                {
                    if (Question2.Text.Contains(question2))
                    {
                        ClickElement(Question2);
                        break;
                    }
                }
                ReportLog("Passed", "Selected security question 2, " + question2);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select security question 2");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SecurityAnswer2, securityAnswer);
                ReportLog("Passed", "Entered the security answer-2 as " + securityAnswer);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the security answer-2");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DropdownQuestion3);
                ReportLog("Passed", "Clicked on question dropdown 3");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on question dropdown 3");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement Question3 in SelectQuestion3)
                {
                    if (Question3.Text.Contains(question3))
                    {
                        ClickElement(Question3);
                        break;
                    }
                }
                ReportLog("Passed", "Selected security question 3, " + question3);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select security question 3");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SecurityAnswer3, securityAnswer);
                ReportLog("Passed", "Entered the security answer-3 as " + securityAnswer);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the security answer-3");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SaveSecurityQuestionForm);
                ReportLog("Passed", "Clicked on examiKNOW save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on examiKNOW save button");
                throw ex;
            }
            MediumSleep();
            try
            {
                Assert.True(ExamiknowAssert.Displayed);
                ReportLog("Passed", "Asserted examiKNOW");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert examiKNOW");
                throw ex;
            }
            MediumSleep();
        }

        public void examiKEY(string examiKEYname)
        {
            try
            {
                ClickElement(ExamikeyEditButton);
                ReportLog("Passed", "Clicked on edit button for examiKEY");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on edit button for examiKEY");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamikeyFirstName, examiKEYname);
                ReportLog("Passed", "Entered the first name in examiKEY as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the first name in examiKEY");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamikeyLastName, examiKEYname);
                ReportLog("Passed", "Entered the last name in examiKEY as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the last name in examiKEY");
                throw ex;
            }
            QuickSleep();
            try
            {;
                EnterValues(ExamikeyFandLName, examiKEYname);
                ReportLog("Passed", "Entered the full name in examiKEY as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the full name in examiKEY");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ReExamikeyFandLName, examiKEYname);
                ReportLog("Passed", "Re-entered the full name in examiKEY as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't re-enter the full name in examiKEY");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SaveExamikey);
                ReportLog("Passed", "Clicked on examiKEY save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on examiKEY save button");
                throw ex;
            }
            ScreenCapture(driver, "Student profile information");
            HardSleep();
        }

        public void ScheduleExam(string Currency,
                                 string studentEmail,
                                 string Company,
                                 string Address,
                                 string City,
                                 string PostalCode,
                                 string CCNumber,
                                 string CSV,
                                 string ExpiryMonth,
                                 string ExpiryYear)
        {
            try
            {
                ClickElement(ExamSchedulingTab);
                ReportLog("Passed", "Clicked on exam scheduling tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam scheduling tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamSchedulePageAssert.Displayed);
                ReportLog("Passed", "Asserted exam scheduling page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert exam scheduling page");
                throw ex;
            }
            MediumSleep();
            if (InstructorDropdownVisibility.Displayed)
            {
                try
                {
                    ClickElement(InstructorDropdown);
                    ReportLog("Passed", "Clicked on instructor dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on instructor dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    ClickElement(InstructorSelection);
                    ReportLog("Passed", "Clicked on instructor");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on instructor");
                    throw ex;
                }
                MediumSleep();
            }
            try
            {
                ClickElement(CourseDropdown);
                ReportLog("Passed", "Clicked on course dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on course dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(CourseSelection);
                ReportLog("Passed", "Clicked on course");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on course");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ExamDropdown);
                ReportLog("Passed", "Clicked on exam dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ExamSelection);
                ReportLog("Passed", "Clicked on exam");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam");
                throw ex;
            }
            MediumSleep();
            try
            {
                Assert.True(ExamDurationAssert.Displayed);
                ReportLog("Passed", "Asserted exam scheduling availability");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert exam scheduling availability");
                throw ex;
            }
            MediumSleep();
            try
            {
                IReadOnlyCollection<IWebElement> availableTimes = driver.FindElements(By.XPath("//div[@class='cal-SlotAvailable']"));
                foreach (IWebElement Time in availableTimes)
                {
                    Time.Click();
                    break;
                    ReportLog("Passed", "Selected exam time as " + Time);
                }
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exam time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleButton);
                ReportLog("Passed", "Clicked on exam schedule button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam schedule button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleConfirmation);
                ReportLog("Passed", "Clicked on yes for schedule confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on yes for schedule confirmation");
                throw ex;
            }
            MediumSleep();
            if (Step1PageAssert.Displayed)
            {
                try
                {
                    driver.SwitchTo().Frame(0);
                    Assert.True(Step1PageAssert.Displayed);
                    ReportLog("Passed", "Asserted step 1 completion");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert step 1 completion");
                    throw ex;
                }
                QuickSleep();
                ScreenCapture(driver, "Exam scheduling details");
                try
                {
                    ClickElement(Step1NextButton);
                    ReportLog("Passed", "Clicked on next button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on next button");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    Assert.True(BillingPageAssert.Displayed);
                    ReportLog("Passed", "Asserted the billing page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert the billing page");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CurrencySelectionDropdown);
                    ReportLog("Passed", "Clicked on currency selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on currency selection dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement currency in CurrencySelection)
                    {
                        if (currency.Text.Contains(Currency))
                        {
                            ClickElement(currency);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected currency as " + Currency);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select currency");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingEmail, studentEmail);
                    ReportLog("Passed", "Entered student email as " + studentEmail);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter student email");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingFirstName, InstructorDashboardPage.studentFName);
                    ReportLog("Passed", "Entered first name as " + InstructorDashboardPage.studentFName);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter first name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingLastName, InstructorDashboardPage.StudentLastName);
                    ReportLog("Passed", "Entered last name as " + InstructorDashboardPage.StudentLastName);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter last name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingCompany, Company);
                    ReportLog("Passed", "Entered company name as " + Company);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter company name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingStreetAddress, Address);
                    ReportLog("Passed", "Entered street address as " + Address);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter street address");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingCity, City);
                    ReportLog("Passed", "Entered city as " + City);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter city");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingPostalCode, PostalCode);
                    ReportLog("Passed", "Entered postal code as " + PostalCode);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter postal code");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(CreditCardNumber, CCNumber);
                    ReportLog("Passed", "Entered creditcard number as " + CCNumber);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter creditcard number");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(CreditCardCSV, CSV);
                    ReportLog("Passed", "Entered creditcard CSV as " + CSV);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter creditcard CSV");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CCMonth);
                    ReportLog("Passed", "Clicked on CC expiry month dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on on CC expiry month dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement expiryMonth in CCMonthSelection)
                    {
                        if (expiryMonth.Text.Contains(ExpiryMonth))
                        {
                            ClickElement(expiryMonth);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected creditcard expiry month as " + ExpiryMonth);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select creditcard expiry month");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CCYear);
                    ReportLog("Passed", "Clicked on CC expiry year dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on CC expiry year dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement expiryYear in CCYearSelection)
                    {
                        if (expiryYear.Text.Contains(ExpiryYear))
                        {
                            ClickElement(expiryYear);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected creditcard expiry year as " + ExpiryYear);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select creditcard expiry year");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(BillingDetailsSubmit);
                    ReportLog("Passed", "Clicked on submit button for billing page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on submit button for billing page");
                    throw ex;
                }
                HardSleep();
                try
                {
                    Assert.True(FinalReviewPageAssert.Displayed);
                    ReportLog("Passed", "Asserted the final review page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert the final review page");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(FinalSubmitButton);
                    ReportLog("Passed", "Clicked on final submit button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on final submit button");
                    throw ex;
                }
                FasterSleep();
                try
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    string script = "arguments[0].click();";
                    jsExecutor.ExecuteScript(script, ScheduleConfirmationOKButton);
                    ReportLog("Passed", "Clicked on paymant confirmation okay button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on paymant confirmation okay button");
                    throw ex;
                }
                ScreenCapture(driver, "Exam scheduling transaction");
                MediumSleep();
            }
        }

        public void RescheduleExam(string Currency,
                                 string studentEmail,
                                 string Company,
                                 string Address,
                                 string City,
                                 string PostalCode,
                                 string CCNumber,
                                 string CSV,
                                 string ExpiryMonth,
                                 string ExpiryYear)
        {
            try
            {
                ClickElement(ExamRescheduleTab);
                ReportLog("Passed", "Clicked on exam reschedule tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamRescheduleLink);
                ReportLog("Passed", "Clicked on exam reschedule link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RescheduleButton);
                ReportLog("Passed", "Clicked on exam reschedule button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(OnDemandSchedulingButton);
                ReportLog("Passed", "Clicked on on-demand scheduling");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on on-demand scheduling");
                throw ex;
            }
            MediumSleep();
            try
            {
                IReadOnlyCollection<IWebElement> availableTimes = driver.FindElements(By.XPath("//div[@class='cal-SlotAvailable']"));
                foreach (IWebElement Time in availableTimes)
                {
                    Time.Click();
                    break;
                    ReportLog("Passed", "Selected exam reschedule time as " + Time);
                }
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exam reschedule time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RescheduleButtonAfter);
                ReportLog("Passed", "Clicked on exam reschedule button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleConfirmation);
                ReportLog("Passed", "Clicked on yes for schedule confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on yes for schedule confirmation");
                throw ex;
            }
            MediumSleep();
            if (Step1PageAssert.Displayed)
            {
                try
                {
                    driver.SwitchTo().Frame(0);
                    Assert.True(Step1PageAssert.Displayed);
                    ReportLog("Passed", "Asserted step 1 completion");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert step 1 completion");
                    throw ex;
                }
                ScreenCapture(driver, "Exam rescheduling details");
                QuickSleep();
                try
                {
                    ClickElement(Step1NextButton);
                    ReportLog("Passed", "Clicked on next button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on next button");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    Assert.True(BillingPageAssert.Displayed);
                    ReportLog("Passed", "Asserted the billing page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert the billing page");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CurrencySelectionDropdown);
                    ReportLog("Passed", "Clicked on currency selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on currency selection dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement currency in CurrencySelection)
                    {
                        if (currency.Text.Contains(Currency))
                        {
                            ClickElement(currency);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected currency as " + Currency);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select currency");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingEmail, studentEmail);
                    ReportLog("Passed", "Entered student email as " + studentEmail);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter student email");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingFirstName, InstructorDashboardPage.studentFName);
                    ReportLog("Passed", "Entered first name as " + InstructorDashboardPage.studentFName);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter first name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingLastName, InstructorDashboardPage.StudentLastName);
                    ReportLog("Passed", "Entered last name as " + InstructorDashboardPage.StudentLastName);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter last name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingCompany, Company);
                    ReportLog("Passed", "Entered company name as " + Company);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter company name");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingStreetAddress, Address);
                    ReportLog("Passed", "Entered street address as " + Address);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter street address");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingCity, City);
                    ReportLog("Passed", "Entered city as " + City);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter city");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(BillingPostalCode, PostalCode);
                    ReportLog("Passed", "Entered postal code as " + PostalCode);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter postal code");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(CreditCardNumber, CCNumber);
                    ReportLog("Passed", "Entered creditcard number as " + CCNumber);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter creditcard number");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    EnterValues(CreditCardCSV, CSV);
                    ReportLog("Passed", "Entered creditcard CSV as " + CSV);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't enter creditcard CSV");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CCMonth);
                    ReportLog("Passed", "Clicked on CC expiry month dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on on CC expiry month dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement expiryMonth in CCMonthSelection)
                    {
                        if (expiryMonth.Text.Contains(ExpiryMonth))
                        {
                            ClickElement(expiryMonth);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected creditcard expiry month as " + ExpiryMonth);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select creditcard expiry month");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(CCYear);
                    ReportLog("Passed", "Clicked on CC expiry year dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on CC expiry year dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    foreach (IWebElement expiryYear in CCYearSelection)
                    {
                        if (expiryYear.Text.Contains(ExpiryYear))
                        {
                            ClickElement(expiryYear);
                            break;
                        }
                    }
                    ReportLog("Passed", "Selected creditcard expiry year as " + ExpiryYear);
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select creditcard expiry year");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(BillingDetailsSubmit);
                    ReportLog("Passed", "Clicked on submit button for billing page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on submit button for billing page");
                    throw ex;
                }
                HardSleep();
                try
                {
                    Assert.True(FinalReviewPageAssert.Displayed);
                    ReportLog("Passed", "Asserted the final review page");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't assert the final review page");
                    throw ex;
                }
                FasterSleep();
                try
                {
                    ClickElement(FinalSubmitButton);
                    
                    ReportLog("Passed", "Clicked on final submit button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on final submit button");
                    throw ex;
                }
                FasterSleep();
                ScreenCapture(driver, "Exam rescheduling transaction");
                try
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver; 
                    string script = "arguments[0].click();"; 
                    jsExecutor.ExecuteScript(script, ScheduleConfirmationOKButton);
                    ReportLog("Passed", "Clicked on paymant confirmation okay button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on paymant confirmation okay button");
                    throw ex;
                }
                MediumSleep();
            }
            else
            {
                try
                {
                    ClickElement(RescheduleOKButton);
                    ReportLog("Passed", "Clicked on yes for schedule confirmation");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on yes for schedule confirmation");
                    throw ex;
                }
                ScreenCapture(driver, "Exam resceduling details (University pay)");
                QuickSleep();
            }
        }

        public void CancelExam()
        {
            try
            {
                ClickElement(ExamRescheduleTab);
                ReportLog("Passed", "Clicked on exam reschedule tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamRescheduleLink);
                ReportLog("Passed", "Clicked on exam reschedule link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam reschedule link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CancelExamBUtton);
                ReportLog("Passed", "Clicked on exam cancellation button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam cancellation button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmCancellation);
                ReportLog("Passed", "Clicked on cancellation confirmation Okay button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on cancellation confirmation Okay button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamCancellationAssert.Displayed);
                ReportLog("Passed", "Asserted the exam cancellation page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert the exam cancellation page");
                throw ex;
            }
            ScreenCapture(driver, "Exam cancellation");
            QuickSleep();
        }

        public void ScheduleExamAgain(string Currency,
                                    string studentEmail,
                                    string Company,
                                    string Address,
                                    string City,
                                    string PostalCode,
                                    string CCNumber,
                                    string CSV,
                                    string ExpiryMonth,
                                    string ExpiryYear)
        {
            try
            {
                ClickElement(ExamSchedulingTab);
                ReportLog("Passed", "Clicked on exam scheduling tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam scheduling tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamSchedulePageAssert.Displayed);
                ReportLog("Passed", "Asserted exam scheduling page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert exam scheduling page");
                throw ex;
            }
            MediumSleep();
            if (InstructorDropdownVisibility.Displayed)
            {
                try
                {
                    ClickElement(InstructorDropdown);
                    ReportLog("Passed", "Clicked on instructor dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on instructor dropdown");
                    throw ex;
                }
                MediumSleep();
                try
                {
                    ClickElement(InstructorSelection);
                    ReportLog("Passed", "Clicked on instructor");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on instructor");
                    throw ex;
                }
                MediumSleep();
            }
            try
            {
                ClickElement(CourseDropdown);
                ReportLog("Passed", "Clicked on course dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on course dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(CourseSelection);
                ReportLog("Passed", "Clicked on course");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on course");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ExamDropdown);
                ReportLog("Passed", "Clicked on exam dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ExamSelection);
                ReportLog("Passed", "Clicked on exam");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(OnDemandSchedulingButton);
                ReportLog("Passed", "Clicked on on-demand button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on on-demand button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamDurationAssert.Displayed);
                ReportLog("Passed", "Asserted exam scheduling availability");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert exam scheduling availability");
                throw ex;
            }
            MediumSleep();
            try
            {
                IReadOnlyCollection<IWebElement> availableTimes = driver.FindElements(By.XPath("//div[@class='cal-SlotAvailable']"));
                foreach (IWebElement Time in availableTimes)
                {
                    Time.Click();
                    break;
                    ReportLog("Passed", "Selected exam time as " + Time);
                }
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exam time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleButton);
                ReportLog("Passed", "Clicked on exam schedule button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam schedule button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleConfirmation);
                ReportLog("Passed", "Clicked on yes for schedule confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on yes for schedule confirmation");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver.SwitchTo().Frame(0);
                Assert.True(Step1PageAssert.Displayed);
                ReportLog("Passed", "Asserted step 1 completion");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert step 1 completion");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Exam scheduling details for final scheduling");
            try
            {
                ClickElement(Step1NextButton);
                ReportLog("Passed", "Clicked on next button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on next button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(BillingPageAssert.Displayed);
                ReportLog("Passed", "Asserted the billing page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert the billing page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CurrencySelectionDropdown);
                ReportLog("Passed", "Clicked on currency selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on currency selection dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement currency in CurrencySelection)
                {
                    if (currency.Text.Contains(Currency))
                    {
                        ClickElement(currency);
                        break;
                    }
                }
                ReportLog("Passed", "Selected currency as " + Currency);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select currency");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingEmail, studentEmail);
                ReportLog("Passed", "Entered student email as " + studentEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter student email");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingFirstName, InstructorDashboardPage.studentFName);
                ReportLog("Passed", "Entered first name as " + InstructorDashboardPage.studentFName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter first name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingLastName, InstructorDashboardPage.StudentLastName);
                ReportLog("Passed", "Entered last name as " + InstructorDashboardPage.StudentLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter last name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingCompany, Company);
                ReportLog("Passed", "Entered company name as " + Company);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter company name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingStreetAddress, Address);
                ReportLog("Passed", "Entered street address as " + Address);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter street address");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingCity, City);
                ReportLog("Passed", "Entered city as " + City);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter city");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BillingPostalCode, PostalCode);
                ReportLog("Passed", "Entered postal code as " + PostalCode);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter postal code");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CreditCardNumber, CCNumber);
                ReportLog("Passed", "Entered creditcard number as " + CCNumber);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter creditcard number");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CreditCardCSV, CSV);
                ReportLog("Passed", "Entered creditcard CSV as " + CSV);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter creditcard CSV");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CCMonth);
                ReportLog("Passed", "Clicked on CC expiry month dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on on CC expiry month dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement expiryMonth in CCMonthSelection)
                {
                    if (expiryMonth.Text.Contains(ExpiryMonth))
                    {
                        ClickElement(expiryMonth);
                        break;
                    }
                }
                ReportLog("Passed", "Selected creditcard expiry month as " + ExpiryMonth);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select creditcard expiry month");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CCYear);
                ReportLog("Passed", "Clicked on CC expiry year dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on CC expiry year dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement expiryYear in CCYearSelection)
                {
                    if (expiryYear.Text.Contains(ExpiryYear))
                    {
                        ClickElement(expiryYear);
                        break;
                    }
                }
                ReportLog("Passed", "Selected creditcard expiry year as " + ExpiryYear);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select creditcard expiry year");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(BillingDetailsSubmit);
                ReportLog("Passed", "Clicked on submit button for billing page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on submit button for billing page");
                throw ex;
            }
            HardSleep();
            try
            {
                Assert.True(FinalReviewPageAssert.Displayed);
                ReportLog("Passed", "Asserted the final review page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert the final review page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(FinalSubmitButton);
                ReportLog("Passed", "Clicked on final submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on final submit button");
                throw ex;
            }
            FasterSleep();
            ScreenCapture(driver, "Exam transaction details for final scheduling of exam");
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//span[@id='btnLogin']"));
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                string script = "arguments[0].click();";
                jsExecutor.ExecuteScript(script, element);
                
                ReportLog("Passed", "Clicked on paymant confirmation okay button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on paymant confirmation okay button");
                throw ex;
            }
            HardSleep();
            try
            {
                ClickElement(StartExamTab);
                ReportLog("Passed", "Clicked on start exam tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on start exam tab");
                throw ex;
            }
            HardSleep();
            try
            {
                AppoinmentID = appoinmentID.Text;
                ReportLog("Passed", "Grabbed the appoinment ID number");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't grab the appoinment ID number");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConnectToProctorButton);
                ReportLog("Passed", "Clicked on connect to proctor button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on connect to proctor button");
                throw ex;
            }
            MediumSleep();
        }

        public void WFMRole()
        {
            try
            {
                string WFMUsername = getDataParser().extractDataLoginCredentials(("WFMUsername"));
                string WFMPassword = getDataParser().extractDataLoginCredentials("WFMPassword");

                TestBase testBase = new TestBase();
                testBase.BrowserInitiationWFM();
                driver = testBase.getDriver();
                WFMPortalPage wFMPortalPage = new WFMPortalPage(driver);
                driver.SwitchTo().Window(driver.WindowHandles[3]);
                wFMPortalPage.LoginAsWFM(WFMUsername,
                                         WFMPassword);
                wFMPortalPage.AssignProctor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            MediumSleep();
            driver.SwitchTo().Window(driver.WindowHandles[3]).Close();
        }

        public void ProctorStudentFlow()
        {
            try
            {
                string ProctorUsername = getDataParser().extractDataLoginCredentials("ProctorUsername");
                string ProctorPassword = getDataParser().extractDataLoginCredentials("ProctorPassword");
                string Location = getDataParser().extractDataLoginCredentials("Location");
                string WorkStation = getDataParser().extractDataLoginCredentials("WorkStation");
                string ExamIcon = getDataParser().extractDataLoginCredentials("ExamIcon");

                TestBase testBase = new TestBase();
                testBase.BrowserInitiationProctor();
                driver1 = testBase.getDriver1();
                ProctorDashboardPage proctorDashboardPage = new ProctorDashboardPage(driver1);
                proctorDashboardPage.ProctorLogin(ProctorUsername,
                                                  ProctorPassword,
                                                  Location,
                                                  WorkStation);
                proctorDashboardPage.NavigationToStartExam(ExamIcon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProceedButtonStudent()
        {
            MediumSleep();
            try
            {
                ClickElement(ProceedButton);
                ReportLog("Passed", "Clicked on proceed buttom");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proceed button");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver.SwitchTo().Alert().Accept();
                ReportLog("Passed", "Clicked on okay (JAva pop-up)");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on okay (JAva pop-up)");
                throw ex;
            }
            QuickSleep();
            string tabToCloseTitle = "Launch Meeting - Zoom";
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (driver.Title.Equals(tabToCloseTitle))
                {
                    driver.Close();
                    break;
                }
            }
            try
            {
                string Flag = getDataParser().extractDataLoginCredentials("Flag");
                string AuthHours = getDataParser().extractDataLoginCredentials("AuthHours");
                string AuthMinutes = getDataParser().extractDataLoginCredentials("AuthMinutes");
                string AuthSeconds = getDataParser().extractDataLoginCredentials("AuthSeconds");
                string ProctorComment1 = getDataParser().extractDataLoginCredentials("ProctorComment1");

                TestBase testBase = new TestBase();
                driver1 = testBase.getDriver1();
                ProctorDashboardPage proctorDashboardPage = new ProctorDashboardPage(driver1);
                driver1.SwitchTo().Window(driver1.WindowHandles[1]);
                proctorDashboardPage.Authentication();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            QuickSleep();
        }

        public void ProvidingExamiDetails(string securityAnswer,
                                          string examiKEYname)
        {
            try
            {
                ClickElement(NextButtonPostProceed);
                ReportLog("Passed", "Clicked on next button after proceed button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on next button after proceed button");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamiKNOWQuestion, securityAnswer);
                ReportLog("Passed", "Entered the answer for ExamiKNOW question as " + securityAnswer);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the answer for ExamiKNOW question");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamiKNOWSubmitButton);
                ReportLog("Passed", "Clicked on examiKNOW submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on examiKNOW submit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamiKEYFirstname, examiKEYname);
                ReportLog("Passed", "Entered the examiKEY first name as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the examiKEY first name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamiKEYLastname, examiKEYname);
                ReportLog("Passed", "Entered the examiKEY last name as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the examiKEY last name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamiKEYFullname, examiKEYname);
                ReportLog("Passed", "Entered the examiKEY full name as " + examiKEYname);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the examiKEY full name");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamiKEYSubmitButton);
                ReportLog("Passed", "Clicked on examiKEY submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on examiKEY submit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                for (int i = 0; i < RadioButtonsUserAgreement.Count; i++)
                {
                    RadioButtonsUserAgreement[i].Click();
                }
                ReportLog("Passed", "Selected agree for user agreements");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select agree for user agreement");
                throw ex;
            }
            QuickSleep();
            try
            {
                for (int i = 0; i < SpecialInstructionRadioButton.Count; i++)
                {
                    SpecialInstructionRadioButton[i].Click();
                }
                ReportLog("Passed", "Agreed on special instructions");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't agree on special instructions");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(UserAgreementSubmitButton);
                ReportLog("Passed", "Clicked on user agreement submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on user agreement submit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(BeginExamButton);
                ReportLog("Passed", "Clicked on begin exam button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on begin exam button");
                throw ex;
            }
            HardSleep();
            driver.SwitchTo().Window(driver.WindowHandles[0]).Close();
            MediumSleep();
            driver.SwitchTo().Window(driver.WindowHandles[0]).Close();
            MediumSleep();
            string tabToCloseUrl = "https://test.examity.com/onlineexam/"; 
            foreach (string handle in driver.WindowHandles) 
            { driver.SwitchTo().Window(handle);
                if (driver.Url.Equals(tabToCloseUrl)) 
                { 
                    driver.Close(); 
                    break; 
                } 
            }
            MediumSleep();
            try
            {
                string Flag = getDataParser().extractDataLoginCredentials("Flag");
                string AuthHours = getDataParser().extractDataLoginCredentials("AuthHours");
                string AuthMinutes = getDataParser().extractDataLoginCredentials("AuthMinutes");
                string AuthSeconds = getDataParser().extractDataLoginCredentials("AuthSeconds");
                string ProctorComment1 = getDataParser().extractDataLoginCredentials("ProctorComment1");
                string ExamHours = getDataParser().extractDataLoginCredentials("ExamHours");
                string ExamMinutes = getDataParser().extractDataLoginCredentials("ExamMinutes");
                string ExamSeconds = getDataParser().extractDataLoginCredentials("ExamSeconds");
                string ProctorComment2 = getDataParser().extractDataLoginCredentials("ProctorComment2");
                string AdditionalComments = getDataParser().extractDataLoginCredentials("AdditionalComments");

                TestBase testBase = new TestBase();
                driver1 = testBase.getDriver1();
                ProctorDashboardPage proctorDashboardPage = new ProctorDashboardPage(driver1);
                driver1.SwitchTo().Window(driver1.WindowHandles[1]);
                proctorDashboardPage.AuthenticationComments(Flag,
                                                            AuthHours,
                                                            AuthMinutes,
                                                            AuthSeconds,
                                                            ProctorComment1,
                                                            ExamHours,
                                                            ExamMinutes,
                                                            ExamSeconds,
                                                            ProctorComment2,
                                                            AdditionalComments);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            FasterSleep();                    
        }

        public void Survey()
        {
            MediumSleep();
            try
            {
                parentWindowHandle = driver.CurrentWindowHandle;
                ClickElement(SurveyLink);
                ReportLog("Passed", "Clicked on survey link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on survey link");
                throw ex;
            }
            MediumSleep();
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                ReportLog("Passed", "Opened new window");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't open new window");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(SurveyPageAssert.Displayed);
                ReportLog("Passed", "Asserted survey page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert survey page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ProctorRating);
                ReportLog("Passed", "Clicked on proctor rating");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor rating");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(Improvement1);
                ReportLog("Passed", "Clicked on improvement point 1");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on improvement point 1");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(Improvement2);
                ReportLog("Passed", "Clicked on improvement point 2");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on improvement point 2");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(Improvement3);
                ReportLog("Passed", "Clicked on improvement point 3");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on improvement point 3");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamityRecommendation);
                ReportLog("Passed", "Clicked on Examity recommendation rate");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Examity recommendation rate");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SurveySubmitButton);
                ReportLog("Passed", "Clicked on survey submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on survey submit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(SurveySubmissionAssert.Displayed);
                ReportLog("Passed", "Asserted survey submit page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert survey submit page");
                throw ex;
            }
        }
    }
}
