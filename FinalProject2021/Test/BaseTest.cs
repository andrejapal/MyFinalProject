using FinalProject2021.Drivers;
using FinalProject2021.Page;
using FinalProject2021.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2021.Test
{
    public class BaseTest
    {
        public static IWebDriver Driver;
        public static DouglasHomePage _douglasHome;
        public static SearchResultPage _searchResult;
        public static ConsultationPage _consultation;
        public static DouglasPhoneNumberPage _workingTime;
   
        


        [OneTimeSetUp]
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
            _douglasHome = new DouglasHomePage(Driver);
            _searchResult = new SearchResultPage(Driver);
            _consultation = new ConsultationPage(Driver);
            _workingTime = new DouglasPhoneNumberPage(Driver);

        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(Driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Driver.Quit();
        }
    }
}
