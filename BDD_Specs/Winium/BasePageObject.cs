using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDD_Specs.Winium
{
    public class BasePageObject
    {
        private const string DictionaryKeyNotFoundMessageError = "Nenhum controle encontrado com esse nome no mapeamento de componentes";

        private List<ElementMap> controlDictionary;

        public List<ElementMap> ControlDictionary
        {
            get
            {
                if (controlDictionary == null)
                {
                    controlDictionary = new List<ElementMap>();
                }
                return controlDictionary;
            }
            set { controlDictionary = value; }
        }


        public T As<T>() where T : BasePageObject
        {
            return (T)this;
        }

        public string FindControlId(string controlName)
        {
            var control = ControlDictionary.FirstOrDefault(c => c.ComponentName == controlName);

            if (control != null)
            {
                return control.ComponentId;
            }
            else
            {
                throw new MissingMemberException(DictionaryKeyNotFoundMessageError + ": " + controlName);
            }
        }

        public void AddControlToDictionary(string controlId, string controlName)
        {
            ControlDictionary.Add(new ElementMap(controlId, controlName));
        }

        public void Clicar(string nomeBotao)
        {
            string controlId = FindControlId(nomeBotao);
            var element = GetElement(controlId);

            element.Click();
        }

        public bool ExistElement(string elementId)
        {
            var element = PropertiesCollection.Driver.FindElementById(elementId);

            return element != null ? true : false;
        }

        public IWebElement GetElement(string elementId)
        {
            if (ExistElement(elementId))
            {
                return PropertiesCollection.Driver.FindElementById(elementId);
            }
            else
            {
                throw new MissingMemberException();
            }
        }

        public bool IsEnable(string elementId)
        {
            var element = GetElement(elementId);

            return element.Enabled;
        }

        internal void Tap(string nomeComponente)
        {
            string controlId = FindControlId(nomeComponente);
            var element = GetElement(controlId);

            var action = PropertiesCollection.TouchAction.SingleTap(element).Build();
            action.Perform();
        }
    }
}
