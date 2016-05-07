using OpenQA.Selenium.Firefox;
using TecTest.Utilities.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    internal class Login : Fixtures.Login
    {
        public Login()
            : base(DriverProvider.New<FirefoxDriver>())
        {
        }
    }
}