using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDD_Specs.Winium
{
    public static class PropertiesCollection
    {
        private static string _emulator = "Mobile Emulator 10.0.10586.0 WVGA 4 inch 512MB";

        private static BasePageObject _currentPage;
        public static BasePageObject CurrentPage
        {
            get { return _currentPage; }
            set
            {
                ScenarioContext.Current["class"] = value;
                _currentPage = ScenarioContext.Current.Get<BasePageObject>("class");
            }
        }

        //private static string path = @"C:\Users\jpedretti\Source\Repos\wp-tokpag\Itau.WinRT.Mobile.Tokpag\Itau.WinRT.Mobile.Tokpag\Itau.WinRT.Mobile.Tokpag\AppPackages\Itau.WinRT.Mobile.Tokpag_1.0.0.0_AnyCPU_Debug_Test\Itau.WinRT.Mobile.Tokpag_1.0.0.0_AnyCPU_Debug.appx";

        private static string path = @"D:\Projects\BDD_UniversalApp\BDD_UniversalApp\AppPackages\BDD_UniversalApp_1.0.5.0_x64_Debug_Test\BDD_UniversalApp_1.0.5.0_x64_Debug.appx";

        private static DesiredCapabilities _desiredCapabilities;

        public static DesiredCapabilities DesiredCapabilitiesProp
        {
            get
            {
                if (_desiredCapabilities == null)
                {
                    _desiredCapabilities = new DesiredCapabilities();
                    _desiredCapabilities.SetCapability("app", path);
                    _desiredCapabilities.SetCapability("deviceName", _emulator);
                }
                return _desiredCapabilities;
            }
            set { _desiredCapabilities = value; }
        }

        private static WpDriver _driver;
        public static WpDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    //_driver = new WpDriver(new Uri("http://localhost:9999"), DesiredCapabilitiesProp);
                    _driver = DriverStart();
                }
                return _driver;
            }
            set { _driver = value; }
        }
        private static WebDriverWait _driverWait;

        public static WebDriverWait DriverWait
        {
            get
            {
                // if (_driverWait == null)
                //{
                _driverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                //}
                return _driverWait;
            }
            set { _driverWait = value; }
        }

        private static TouchActions touchAction;

        public static TouchActions TouchAction
        {
            get
            {
                //if (touchAction == null)
                //{
                touchAction = new TouchActions(Driver);
                //}
                return touchAction;
            }
            set { touchAction = value; }
        }


        public static void QuitApp()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        public static void InitializeApp()
        {
            _driver = DriverStart();
        }

        public static WpDriver DriverStart()
        {
            _desiredCapabilities = new DesiredCapabilities();
            _desiredCapabilities.SetCapability("app", path);
            _desiredCapabilities.SetCapability("deviceName", _emulator);

            return new WpDriver(new Uri("http://localhost:9999"), _desiredCapabilities);
        }

        public static void HideKeyBoard()
        {
            _driver.ExecuteScript("mobile: OnScreenKeyboard.Disable");
        }

        public static void ShowKeyBoard()
        {
            _driver.ExecuteScript("mobile: OnScreenKeyboard.Enable");
        }

        public static bool IsToggleSwitchOn(IWebElement component)
        {
            var state = (string)_driver.ExecuteScript("automation: TogglePattern.ToggleState", component);

            return state == "On";
        }

        public static void SetPropertyOnElement(IWebElement element, string propertyName, string value)
        {
            _driver.ExecuteScript("attribute: set", element, propertyName, value);
        }
    }
}
