using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SimpleLoginTest.pages;
using System.Security.Policy;

namespace SimpleLoginTest
{
    public class Tests
    {
        private IWebDriver driver;// = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {

            //IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demo.testfire.net/login.jsp");

            driver.FindElement(By.Id("uid")).SendKeys("admin");

            driver.FindElement(By.Id("passw")).SendKeys("admin");

            //driver.FindElement(By.Name("btnSubmit")).Submit();


            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var loginBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnSubmit")));

            loginBtn.Submit();
            Assert.That(driver.Url, Is.EqualTo("https://demo.testfire.net/bank/main.jsp"), "Login unsuccessful, navigated to different url / page!");

            Console.WriteLine(driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[2]/div/h1")).Text);
            var loginSuccess = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/table[2]/tbody/tr/td[2]/div/h1")));

            //Assert.Multiple(() =>
            //{
            // Just in case if we want to add more assertions.
                Assert.That(loginSuccess.Displayed,"Missing successful login message!");
                Assert.That("Hello Admin User", Is.EqualTo(loginSuccess.Text), "Successful login message different that expected!");
           //});

        }

        //[Test]
        //public void Test2() 
        //{
        //    //IWebDriver driver = new ChromeDriver();

        //    //driver.Navigate().GoToUrl("https://demo.testfire.net/login.jsp");

        //    //LoginPage loginPage = new LoginPage(driver);

        //    //loginPage.Login("admin", "admin");
        //}

        [OneTimeTearDown]
        public void oneTimeTearDown() 
        {
            //Sign off
            driver.Navigate().GoToUrl("https://demo.testfire.net/logout.jsp");
            Console.WriteLine("Tear Down script executed");
            //Close browser
            driver.Close();
            driver.Quit();
        }
    }
}