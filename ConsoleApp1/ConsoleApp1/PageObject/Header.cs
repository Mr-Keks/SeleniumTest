using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ConsoleApp1.PageObject
{
    public class Header : PageObjectBase
    {

        private static readonly By loginButton = By.ClassName("login");

        public Header(IWebDriver driver) : base(driver)
        {
        }

        public EnterToAccount ClickOnSingIn()
        {

            Driver.FindElement(loginButton).Click();
            return new EnterToAccount(Driver);   
        }
    }
}