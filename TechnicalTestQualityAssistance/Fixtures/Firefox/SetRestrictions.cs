using OpenQA.Selenium.Firefox;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    internal class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions()
            : base(DriverProvider.New<FirefoxDriver>())
        {
        }
    }
}