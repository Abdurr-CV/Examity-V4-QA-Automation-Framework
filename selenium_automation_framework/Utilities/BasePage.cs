using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using Microsoft.CSharp;


namespace PortalApplicationFramework.Utilities
{
    public class BasePage
    {
        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void EnterValues(IWebElement element, String value)
        {
            element.SendKeys(value);
        }

        public void WaitTillElementVisibleID(IWebDriver driver, String element, Double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Id(element))));
        }

        public void WaitTillElementClickableID(IWebDriver driver, String element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.Id(element))));
        }

        public void WaitTillElementClickableX(IWebDriver driver, String element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(element)));
        }

        public void WaitTillAllLocatedElementsVisibleX(IWebDriver driver, String element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(element)));
        }

        public void WaitTillElementToBeSelectedX(IWebDriver driver, String element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath(element)));
        }

        public void WaitTillElementVisibleX(IWebDriver driver, String element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(element)));
        }

        public void Sleep(dynamic Value)
        {
            Thread.Sleep(Value);
        }

        public void ScreenCapture(IWebDriver driver)
        {
            var MethodName = TestContext.CurrentContext.Test.MethodName.ToString();
            DateTime time = DateTime.Now;
            String fileName = (MethodName) + time.ToString("_h_mm_ss") + ".png";
            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(@"C:\selenium_automation_framework\selenium_automation_framework\selenium_automation_framework\Utilities\Screenshots\" + fileName);
        }
    }
}