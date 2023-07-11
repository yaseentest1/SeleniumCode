using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleninumWithBDDSpecFlow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleninumWithBDDSpecFlow.Steps
{
    [Binding]
    public class LoginSteps
    {

        private IWebDriver _driver;     

        public LoginSteps(IWebDriver driver) => _driver = driver;


        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Navigate().GoToUrl("https://demoportmanager.emodal.com/");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            //_driver.FindElement(By.Name("UserName")).SendKeys((String)data.UserName);
            //_driver.FindElement(By.Name("Password")).SendKeys((String)data.Password);

            LoginPage page = new LoginPage(_driver);
            page.EnterUserNameAndPassword("Admin54536", "advent12");
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("submit")).Submit();
            Thread.Sleep(1000);
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
            wait2.Until(a => a.FindElement(By.XPath("/html/body/section/header/div/div[1]/div[2]/div[1]/button")));

            var element = _driver.FindElement(By.XPath("/html/body/section/header/div/div[1]/div[2]/div[1]/button"));

            Assert.That(element.Text, Is.Null, "Header text not found !!!");

            //An way to assert multiple properties of single test
            /*  Assert.Multiple(() =>
             *  
              {
                  //Assert.That(element.Text, Is.Null, "Header text not found !!!");
                  Assert.That(element.Text, Is.Null, "Header text not found !!!");
              });*/
        }

        [Then(@"I logout from application")]
        public void ThenILogoutFromApplication()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
