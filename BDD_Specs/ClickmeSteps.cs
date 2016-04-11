using BDD_Specs.PageObjects;
using BDD_Specs.Winium;
using System;
using TechTalk.SpecFlow;

namespace BDD_Specs
{
    [Binding]
    public class ClickmeSteps
    {
        [Given(@"Que eu abro a aplicação")]
        public void DadoQueEuAbroAAplicacao()
        {
            PropertiesCollection.CurrentPage = new MainPageObject();
        }
        
        [Given(@"Estou na tela de ""(.*)""")]
        public void DadoEstouNaTelaDe(string p0)
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

        [When(@"Preencho o campo ""(.*)"" com o valor ""(.*)""")]
        public void QuandoPreenchoOCampoComOValor(string p0, string p1)
        {
            DriverMethods.WaitFor(400);
            var elementId = PropertiesCollection.CurrentPage.FindControlId(p0);
            var element = PropertiesCollection.Driver.FindElementById(elementId);

            element.SendKeys(p1);
        }

        [Then(@"o campo ""(.*)"" deve ter o valor """"(.*)""")]
        public void EntaoOCampoDeveTerOValor(string p0, string p1)
        {
            DriverMethods.WaitFor(400);
            var elementId = PropertiesCollection.CurrentPage.FindControlId(p0);
            var element = PropertiesCollection.Driver.FindElementById(elementId);
            
            if (element.Text == p1)
            {
                throw new FormatException();
            }
        }
    }
}