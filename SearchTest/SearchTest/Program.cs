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
        private WebDriverWait wait;

        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            driver.Navigate().GoToUrl(url);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();
        [Test]
        public void Test()
        {
            driver.FindElement(By.Id("search_query_top")).Click();
            driver.FindElement(By.Id("search_query_top")).Clear();
            driver.FindElement(By.Id("search_query_top")).SendKeys("F");
            driver.FindElement(By.Id("search_query_top")).SendKeys(Keys.Tab);
            driver.FindElement(By.Name("submit_search")).Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isEmailOk = wait.Until(x =>
                x.FindElements(By.XPath
                    ("//div[@class='content_sortPagiBar']//div[@class='product-count']")).Any());
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            Assert.That(isEmailOk, "Email is not ok");
                
        }
    }
}
