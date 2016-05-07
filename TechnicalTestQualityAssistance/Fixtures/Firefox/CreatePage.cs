using OpenQA.Selenium.Firefox;
using TecTest.Utilities.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    internal class CreatePage : Fixtures.CreatePage
    {
        public CreatePage()
            : base(DriverProvider.New<FirefoxDriver>())
        {
        }
    }
}