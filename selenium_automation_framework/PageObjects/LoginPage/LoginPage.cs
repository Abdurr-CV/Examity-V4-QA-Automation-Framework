using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;

namespace PortalApplicationFramework.PageObjects
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "txtUserName")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "txtPassword")]
        private IWebElement password;

        [FindsBy(How = How.Name, Using = "btnSignIn")]
        private IWebElement signInButton;

        [FindsBy(How = How.XPath, Using = "//table[@id='rdRoles']/tbody/tr")]
        private IWebElement LoginAsOptions;

        [FindsBy(How = How.XPath, Using = "//input[@value='LOG IN']")]
        private IWebElement LoginButton;
        
        public IWebElement getUserName()
        {
            return username;
        }

        public IWebElement getPassword()
        {
            return password;
        }

        public IWebElement getSigninButton()
        {
            return signInButton;
        }

        public void signIn(String userName, String password)
        {
            EnterValues(getUserName(), userName);
            EnterValues(getPassword(), password);
            ClickElement(getSigninButton());
        }

        public void signInAdmin()
        {
            ClickElement(LoginButton);
        }

        public void AssertLogin()
        {
            Assert.IsTrue(signInButton.Displayed);
            Assert.IsTrue(username.Displayed);
            Assert.IsTrue(password.Displayed);
        }
    }
}

