using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driverEdge;

        [TestInitialize]
        public void SetupTest()
        {
           

            var options = new EdgeOptions()
             { 
                PageLoadStrategy = PageLoadStrategy.Eager
           
            };



            string serverPath = @"C:\work\Devops\driver\edgeLastest";
          
            
            _driverEdge = new EdgeDriver(serverPath,options);
            _driverEdge.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            _driverEdge.Quit();
        }


        [TestMethod]
        public void RegisterAndSignOff()
        {
            string path = @"C:\work\Devops\driver\ie";
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            IWebDriver driver = new InternetExplorerDriver(path, options, TimeSpan.FromDays(1));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromDays(1);
            driver.Navigate().GoToUrl("http://localhost:64640/Account/Register");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("ctl00$MainContent$UserNameCtrl")).SendKeys("Chevron" + DateTime.Now.ToString("ddmmyyyhhmmss"));
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ConfirmPassword")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl08")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(wt => wt.FindElement(By.CssSelector(".navbar-right a")));
            Assert.IsTrue(driver.FindElement(By.CssSelector(".navbar-right a")).Displayed);
            driver.FindElements(By.CssSelector(".navbar-right a"))[1].Click();
            driver.Close();
            driver.Dispose();

        }

        [TestMethod]
        public void LoginAndLogoff()
        {
            string path = @"C:\work\Devops\driver\ie";
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            IWebDriver driver = new InternetExplorerDriver(path, options, TimeSpan.FromDays(1));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromDays(1);
            driver.Navigate().GoToUrl("http://localhost:64640/Account/Login");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("ctl00$MainContent$UserName")).SendKeys("Chevron");
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(wt => wt.FindElement(By.CssSelector(".navbar-right a")));
            Assert.IsTrue(driver.FindElement(By.CssSelector(".navbar-right a")).Displayed);
            driver.FindElements(By.CssSelector(".navbar-right a"))[1].Click();
            driver.Close();
            driver.Dispose();
        }


        [TestMethod]
        public void TestMethod2()
        {
            string path = @"C:\work\Devops\driver\edgeLastest";
            IWebDriver driver = new EdgeDriver(path);
            driver.Navigate().GoToUrl("http://localhost:64640/Account/Register");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("ctl00$MainContent$UserNameCtrl")).SendKeys("Chevron");
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ConfirmPassword")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl08")).Click();

        }



        [TestMethod]
        public void Bring()
        {

            //EdgeOptions capabilities = new EdgeOptions() { BrowserName = "" };
            //EdgeDriverService service = new EdgeDriverService.Builder().usingDriverExecutable(edgeDriverPath)
            //    .usingAnyFreePort().build();

            //   string serverPath = @"C:\work\Devops\driver\edgeLastest";


            EdgeOptions options = new EdgeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;



            //  IWebDriver driver = new EdgeDriver(serverPath);
            _driverEdge.Url = "https://www.bing.com/";
            var element = _driverEdge.FindElement(By.Id("sb_form_q"));
            element.SendKeys("webdriver");
            element.SendKeys(Keys.Enter);
            _driverEdge.Quit();
        }

        [TestMethod]
        public void TEST()
        {

            string serverPath = @"C:\work\Devops\driver\edge";
            EdgeOptions options = new EdgeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;

            options.PageLoadStrategy = PageLoadStrategy.Eager;
            IWebDriver driver = new EdgeDriver(serverPath, options);
            driver.Url = "www.bing.com";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromDays(1);
            driver.Navigate();
        }

    }
}
