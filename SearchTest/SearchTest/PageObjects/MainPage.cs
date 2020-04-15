using OpenQA.Selenium;

namespace SearchTest.PageObjects
{
    public class MainPage :POBase
    {
        private static readonly By SearchArea = By.Id("search_query_top");
        private static readonly By SearchButton = By.Name("submit_search");
        
        public  MainPage(IWebDriver driver):base(driver){}

        public MainPage SearchValue(string value)
        {
            Driver.FindElement(SearchArea).Click();
            Driver.FindElement(SearchArea).Clear();
            Driver.FindElement(SearchArea).SendKeys(value);
            Driver.FindElement(SearchArea).SendKeys(Keys.Tab);
            Driver.FindElement(SearchButton).Click();
            return this;
        }

        public SearchPage SearchSmth()
        {
            Driver.FindElement(SearchButton);
            return new SearchPage(Driver);
        }
    }
}