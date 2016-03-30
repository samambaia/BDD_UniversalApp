using BDD_Specs.Winium;
using System;
using TechTalk.SpecFlow;

namespace BDD_Specs
{
    [Binding]
    public class ClickmeSteps
    {
        [Given(@"Que eu estou na tela de ""(.*)""")]
        public void DadoQueEuEstouNaTelaDe(string p0)
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
            var elementId = PropertiesCollection.CurrentPage.FindControlId(p0);
            var element = PropertiesCollection.Driver.FindElementById(elementId);

            element.SendKeys(p1);
        }

    }
}
