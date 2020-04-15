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
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver driver;
        private static readonly string url = TestContext.Parameters["Url"] ?? "http://automationpractice.com/index.php";
        private static readonly TimeSpan implicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32(TestContext.Parameters["Wait"] ?? "3000"));
        private WebDriverWait wait;
        private MainPage mainPage;

        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            driver.Navigate().GoToUrl(Settings.url);
            mainPage = new MainPage(driver);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();
        [TestCase(true, "Faded")]
        [TestCase(false, "F")]
        public void SearchTest(bool isPositive, string value)
        {
            mainPage.SearchValue(value);
            SearchPage sp = mainPage.SearchSmth();
            bool isSearchOk = sp.IsNewSearchElementOk();
            Assert.That(isSearchOk, Is.EqualTo(isPositive), $"Search was validated{(isSearchOk ? "successfully": "unsuccessfully")}"
                                                            + "but we expetcted opposite");

        }
    }
}
