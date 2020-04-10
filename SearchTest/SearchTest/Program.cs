using System;
using System.Data.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SearchTest
{
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver driver;
        private static readonly string url = "http://automationpractice.com/index.php";
        private static readonly TimeSpan implicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32(TestContext.Parameters["Wait"] ?? "3000"));
        private WebDriverWait _wait;

        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            driver.Navigate().GoToUrl(url);
        } 
        [Test]
        public void Test()
        {
            driver.FindElement(By.Id("search_query_top")).Click();
            driver.FindElement(By.Id("search_query_top")).Clear();
            driver.FindElement(By.Id("search_query_top")).SendKeys("Fade");
            driver.FindElement(By.Id("search_query_top")).SendKeys(Keys.Tab);
            driver.FindElement(By.Name("submit_search")).Click();
        }
    }
}
