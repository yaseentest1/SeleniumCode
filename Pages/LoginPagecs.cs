using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleninumWithBDDSpecFlow.Pages
{
    public class LoginPage
    {

        //Classical way of initializing Pages via POM concept - Until Selenium 3.10.0

        //public LoginPage(IWebDriver driver)
        //{
        //    PageFactory.InitElements(driver, this);
        //}

        //[FindsBy(How = How.Name, Using = "UserName")]
        //public IWebElement txtUserName { get; set; }

        //[FindsBy(How = How.Name, Using = "Password")]
        //public IWebElement txtPassword { get; set; }

        //[FindsBy(How = How.Name, Using = "Login")]
        //public IWebElement btnLogin { get; set; }



        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) => _driver = driver;


        IWebElement txtUserName => _driver.FindElement(By.Id("Username"));
        IWebElement txtPassword => _driver.FindElement(By.Id("Password"));
        IWebElement btnLogin => _driver.FindElement(By.Name("submit"));




        public void EnterUserNameAndPassword(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }


    }
}
