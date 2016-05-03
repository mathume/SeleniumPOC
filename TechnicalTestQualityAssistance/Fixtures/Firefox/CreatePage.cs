using OpenQA.Selenium.Firefox;
using TechnicalTestQualityAssistance.Drivers;

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