using System;
using System.Linq;
using OpenQA.Selenium;
using SearchTest.Fraemworks;

namespace SearchTest.PageObjects 
{
    public class SearchPage : POBase
    {
        public static readonly By IsNewSearchElementDiv = By.XPath
            ("//div[@class='content_sortPagiBar']//div[@class='product-count']");

        public SearchPage(IWebDriver driver) : base(driver){}
        
        public bool IsNewSearchElementOk()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isOk = Wait.WaitFor(() => Driver.FindElements(IsNewSearchElementDiv).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            return isOk;
        }
    }
}