using OpenQA.Selenium.Chrome;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    internal class CreatePage : Fixtures.CreatePage
    {
        public CreatePage()
            : base(DriverProvider.New<ChromeDriver>())
        {
        }
    }
}