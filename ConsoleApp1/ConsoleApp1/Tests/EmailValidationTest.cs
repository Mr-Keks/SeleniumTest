using ConsoleApp1.PageObject;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture]
    public class EmailValidationTest: FirstTest
    { 
        private Header header;

        [OneTimeSetUp]
        public void OneTimeSetUp() => header = new Header(Driver);
        

        [TestCase(true, "test@domain.set", "123321123321")]
        [TestCase(false, "testdomain.s12et", "")]
        
        public void ValidateEmail(bool isPositive, string email, string password)
        {
            EnterToAccount authenrififacionPage = header.ClickOnSingIn();
            bool isEmailOk = authenrififacionPage.EnterAccountEmail(email, password).IsEmailOk();
            

            Assert.That(isEmailOk, Is.EqualTo(isPositive),
                $"Email was validated {(isEmailOk ? "succesfully" : "unseccessfully")}" +
                "but we expected opposite");

        }
        
 
    }

   
}