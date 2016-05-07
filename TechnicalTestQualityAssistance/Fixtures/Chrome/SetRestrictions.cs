using OpenQA.Selenium.Chrome;
using TecTest.Utilities.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    internal class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions()
            : base(DriverProvider.New<ChromeDriver>())
        {
        }
    }
}