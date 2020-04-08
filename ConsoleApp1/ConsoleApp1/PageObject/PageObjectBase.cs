using OpenQA.Selenium;

namespace ConsoleApp1.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        public PageObjectBase(IWebDriver driver) => Driver = driver;
    }
}