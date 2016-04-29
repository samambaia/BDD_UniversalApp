using BDD_Specs.PageObjects;
using BDD_Specs.Winium;
using System;
using TechTalk.SpecFlow;

namespace BDD_Specs
{
    [Binding]
    public class ClickmeSteps
    {
        [Given(@"Que estou na tela de ""(.*)""")]
        public void DadoQueEstouNaTelaDe(string p0)
        {
            PropertiesCollection.CurrentPage = new MainPageObject();

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

        [Then(@"Preencho o campo ""(.*)"" com o valor ""(.*)""")]
        public void EntaoPreenchoOCampoComOValor(string p0, string p1)
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
            
            if (element.Text != p1)
            {
                throw new FormatException();
            }
        }
    }
}

