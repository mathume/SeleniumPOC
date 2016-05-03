using OpenQA.Selenium.Firefox;
using TechnicalTestQualityAssistance.Drivers;

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