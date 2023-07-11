using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleninumWithBDDSpecFlow
{
    public class Common
    {
        private IWebDriver _driver;
        public Common(IWebDriver driver)
        {
            _driver = driver;
        }
        public MediaEntityModelProvider CaptureScreenShot(string sName)
        {
            var sScreenShot = ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(sScreenShot, sName).Build();
        }
    }
}
