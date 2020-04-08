using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1.Framework
{
    public static class Selenium
    {
        public static IWebDriver GetDriver(Drivers drivers)
        {
            switch (drivers)
            {
                case Drivers.Chrome:
                default:
                    return GetChromeDriver();
            }
        }

        private static IWebDriver GetChromeDriver()
            {
                IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
                driver.Navigate().GoToUrl(Settings.url);
                return driver;
            }
        
    }

  
}