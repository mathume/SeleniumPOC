using OpenQA.Selenium.Chrome;
using TecTest.Utilities.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    internal class Login : Fixtures.Login
    {
        public Login()
            : base(DriverProvider.New<ChromeDriver>())
        {
        }
    }
}