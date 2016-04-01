using BDD_Specs.Winium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BDD_Specs.PageObjects
{
    class MainPageObject : BasePageObject
    {
        public const string BOTAO_ID = "btnClickme";
        public const string NAME_ID = "txbName";

        [FindsBy(How = How.Id, Using = BOTAO_ID)]
        public IWebElement BotaoId { get; set; }

        [FindsBy(How = How.Id, Using = NAME_ID)]
        public IWebElement TxtName { get; set; }

        public MainPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
            PreencheDicionarioControles();
        }

        private void PreencheDicionarioControles()
        {
            AddControlToDictionary(BOTAO_ID, "btnClickme");
            AddControlToDictionary(NAME_ID, "txbName");
        }
    }
}
