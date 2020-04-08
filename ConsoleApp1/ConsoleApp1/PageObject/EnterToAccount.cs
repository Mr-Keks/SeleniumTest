using System;
using System.Linq;
using ConsoleApp1.Framework;
using OpenQA.Selenium;

namespace ConsoleApp1.PageObject
{
    public class EnterToAccount:PageObjectBase
    {
        private static readonly By EmailInput = By.Id("email");
        private static readonly By PasswordInput = By.Id("passwd");


        private static readonly By IsEmailOkDiv =
            By.XPath("//form[@id='login_form']//div[@class='form-group form-ok']");
        public EnterToAccount(IWebDriver driver) : base(driver)
        {
        }

        public EnterToAccount EnterAccountEmail(string email, string pasword)
        {
            Driver.FindElement(EmailInput).Click();
            Driver.FindElement(EmailInput).Clear();
            Driver.FindElement(EmailInput).SendKeys(email);
            Driver.FindElement(EmailInput).SendKeys(Keys.Tab);
            
            Driver.FindElement(PasswordInput).Click();
            Driver.FindElement(PasswordInput).Clear();
            Driver.FindElement(PasswordInput).SendKeys(pasword);
            Driver.FindElement(PasswordInput).SendKeys(Keys.Tab);
            return this;
        }
   

        public bool IsEmailOk()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isOk = Wait.WaitFor(() => Driver.FindElements(IsEmailOkDiv).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            return isOk;
        }
        
    }
}