using System;
using System.Data.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using SearchTest.PageObjects;
using SearchTest.Fraemworks;

namespace SearchTest
{
   
    public abstract class BaseTest
    {
        protected readonly IWebDriver driver;
        
        protected BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            driver.Navigate().GoToUrl(Settings.url);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();
        
    }
}
