using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BDD_Specs.PageObjects;

namespace BDD_Specs.Winium
{
    public static class DriverMethods
    {

        private const string instanceNameSpace = "BDD_Specs.PageObjects";
        private const string sufixClassName = "PageObject";

        public static BasePageObject SetCurrentPage(string page)
        {
            var assemblyName = instanceNameSpace + "." + page + sufixClassName;
            object instance = Activator.CreateInstance(Type.GetType(assemblyName));

            return (BasePageObject)instance;
        }

        public static bool IsInPage(string page)
        {
            IWebElement element;

            element = PropertiesCollection.DriverWait.Until(ExpectedConditions.ElementExists(By.Id(page)));


            return element != null ? true : false;
        }

        public static bool IsControlEnabled(string componentName)
        {
            string controlId = PropertiesCollection.CurrentPage.FindControlId(componentName);
            var component = PropertiesCollection.Driver.FindElementById(controlId);

            if (component != null)
            {
                return component.Enabled;
            }
            else
            {
                throw new MissingMemberException();
            }
        }

        public static void WaitFor(int milliseconds)
        {
            using (EventWaitHandle tmpEvent = new ManualResetEvent(false))
            {
                tmpEvent.WaitOne(TimeSpan.FromMilliseconds(milliseconds));
            }
        }

        public static bool IsToggleSwitchOn(string componentName)
        {
            string controlId = PropertiesCollection.CurrentPage.FindControlId(componentName);
            var component = PropertiesCollection.Driver.FindElementById(controlId);

            return PropertiesCollection.IsToggleSwitchOn(component);
        }
    }
}
