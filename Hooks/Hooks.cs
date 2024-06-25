using MarsLanguageSkillsSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace MarsLanguageSkillsSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly CommonDriver _commonDriver;

        public Hooks(CommonDriver commonDriver)
        {
            _commonDriver = commonDriver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _commonDriver.Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _commonDriver.Cleanup();
        }
    }
}