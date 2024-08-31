using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras;

namespace SimpleLoginTest.pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement userName => driver.FindElement(By.Id("uid"));
        IWebElement password => driver.FindElement(By.Id("passw"));

        IWebElement loginBtn 
        {
            get
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnSubmit")));
            }
        }        
        public void Login(string username, string pw)
        {
            userName.SendKeys(username);
            password.SendKeys(pw);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            //IWebElement clickBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnSubmit")));
            loginBtn.Submit();
        }

    }
}
