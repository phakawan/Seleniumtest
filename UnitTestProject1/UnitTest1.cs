using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            BrowserTest browser = BrowserTest.Edge;
            string serverPath = @"C:\Users\Lee\Source\Repos\Seleniumtest\driver";
          
            switch (browser)
            {
                case BrowserTest.InternetExploer :
                    InternetExplorerOptions IEoptions = new InternetExplorerOptions()
                    {
                        IgnoreZoomLevel = true,
                        PageLoadStrategy = PageLoadStrategy.Eager
                    };
                  
                    driver = new InternetExplorerDriver(serverPath, IEoptions, TimeSpan.FromDays(1));
                    break;
                case BrowserTest.Edge:
                    EdgeOptions  Edgeoptions = new EdgeOptions()
                    {
                        PageLoadStrategy = PageLoadStrategy.Eager
                    };
                    driver = new EdgeDriver(serverPath, Edgeoptions);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromDays(5);
                    break;
                default:
                    break;
            }

            driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void TeardownTest()
        {
            Thread.Sleep(10000);
            driver.Quit();
            driver.Dispose();
        }


        [TestMethod]
        public void RegisterAndSignOff()
        {
           
            driver.Navigate().GoToUrl("http://localhost:64640/Account/Register");
         
            driver.FindElement(By.Name("ctl00$MainContent$UserNameCtrl")).SendKeys("Chevron" + DateTime.Now.ToString("ddmmyyyhhmmss"));
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ConfirmPassword")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl08")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(wt => wt.FindElement(By.CssSelector(".navbar-right a")));
            Assert.AreEqual(driver.FindElements(By.CssSelector(".navbar-right a"))[1].Text,"Sign Out");
            driver.FindElements(By.CssSelector(".navbar-right a"))[1].Click();
          

        }

        [TestMethod]
        public void LoginAndLogoff()
        {
          
           
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromDays(1);
            driver.Navigate().GoToUrl("http://localhost:64640/Account/Login");
          
            driver.FindElement(By.Name("ctl00$MainContent$UserName")).SendKeys("Chevron");
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl05")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            wait.Until(wt => wt.FindElement(By.CssSelector(".navbar-right a")));
            Assert.AreEqual(driver.FindElements(By.CssSelector(".navbar-right a"))[1].Text, "Sign Out");
            driver.FindElements(By.CssSelector(".navbar-right a"))[1].Click();
          
        }


        [TestMethod]
        public void TestMethod2()
        {
         
           
            driver.FindElement(By.Name("ctl00$MainContent$UserNameCtrl")).SendKeys("Chevron");
            driver.FindElement(By.Name("ctl00$MainContent$Password")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ConfirmPassword")).SendKeys("ChevronPassword");
            driver.FindElement(By.Name("ctl00$MainContent$ctl08")).Click();

        }



        [TestMethod]
        public void Bring()
        {
            
            driver.Url = "https://www.bing.com/";
            var element = driver.FindElement(By.Id("sb_form_q"));
            element.SendKeys("webdriver");
            element.SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 10));
            wait.Until(x => x.FindElements(By.CssSelector("#b_results li")));
           
        }


    }
}
