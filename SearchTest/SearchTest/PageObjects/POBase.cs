using OpenQA.Selenium;

namespace SearchTest.PageObjects
{
    public abstract class POBase
    {
        protected readonly IWebDriver Driver;
        public POBase(IWebDriver driver) => Driver = driver;
    }
}