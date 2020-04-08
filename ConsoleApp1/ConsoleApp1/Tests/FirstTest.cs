using System;
using ConsoleApp1.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
/*
 Сорян це трохи перероблений твій тест, типу авторизація, я на минулій трансляції мало питань задавав
 а коли вже почав сам шось робити зрозумів шо їх дофіга, тому потараюсь на тій трансляції більше 
 питатися, щоб вшарити
 */

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public abstract class FirstTest
    {
        private static readonly TimeSpan implicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32(TestContext.Parameters["Wait"] ?? "3000"));

        protected readonly IWebDriver Driver;
       
        protected FirstTest()
        {
            Driver = Selenium.GetDriver(Settings.Driver);
            Driver.Navigate().GoToUrl(Settings.url);
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => Driver.Quit();
    }
}
