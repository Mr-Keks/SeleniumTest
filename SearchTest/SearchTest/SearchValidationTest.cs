using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SearchTest.Fraemworks;
using SearchTest.PageObjects;

namespace SearchTest
{
    public class SearchValidationTest: BaseTest
    {
        private MainPage mainPage;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { 
            mainPage = new MainPage(driver);
        }
    
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