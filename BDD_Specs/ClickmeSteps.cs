using System;
using TechTalk.SpecFlow;
using BDD_Specs.Winium;
using BDD_Specs.PageObjects;

namespace BDD_Specs
{
    [Binding]
    public class ClickmeSteps : BaseSteps
    {
        [Given(@"Que eu abro a aplicação")]
        public void DadoQueEuAbroAAplicacao()
        {
            PropertiesCollection.CurrentPage = new MainPageObject();
        }

        [Given(@"Eu estou na tela de ""(.*)""")]
        public void DadoEuEstouNaTelaDe(string p0)
        {
            if (!DriverMethods.IsInPage(p0))
            {
                throw new MissingMemberException();
            }
        }

        [When(@"Eu pressiono o botão ""(.*)""")]
        public void QuandoEuPressionoOBotao(string p0)
        {
            DriverMethods.WaitFor(400);
            PropertiesCollection.CurrentPage.Clicar(p0);
        }

        [Then(@"Devo preencher o campo ""(.*)"" com o valor ""(.*)""")]
        public void EntaoDevoPreencherOCampoComOValor(string p0, string p1)
        {
            DriverMethods.WaitFor(400);
            var elementId = PropertiesCollection.CurrentPage.FindControlId(p0);
            var element = PropertiesCollection.Driver.FindElementById(elementId);

            element.SendKeys(p1);
        }

        [BeforeScenario]
        [Then(@"Devo sair da aplicação")]
        public void EntaoDevoSairDaAplicacao()
        {
            PropertiesCollection.QuitApp();
        }
    }
}
