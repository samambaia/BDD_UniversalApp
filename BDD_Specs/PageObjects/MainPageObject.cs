using BDD_Specs.Winium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BDD_Specs.PageObjects
{
    class MainPageObject : BasePageObject
    {
        public const string botaoId = "btnClickme";

        [FindsBy(How = How.Id, Using = botaoId)]
        public IWebElement BotaoId { get; set; }

        public MainPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
            PreencheDicionarioControles();
        }

        private void PreencheDicionarioControles()
        {
            AddControlToDictionary(botaoId, "btnClickme");
        }
    }
}
