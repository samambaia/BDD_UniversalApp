using TechTalk.SpecFlow;

namespace BDD_Specs.Winium
{
    [Binding]
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        [BeforeScenario]
        private void Setup()
        {
            PropertiesCollection.InitializeApp();
        }

        [AfterScenario]
        private void CleanUp()
        {
            PropertiesCollection.QuitApp();
        }

    }
}
