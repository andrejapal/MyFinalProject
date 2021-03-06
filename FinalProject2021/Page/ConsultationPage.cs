using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2021.Page
{
    public class ConsultationPage : BasePage
    {

        private const string addressUrl = "https://www.douglas.lt/renginiai/";
        private IWebElement allowAllCookiesButton => Driver.FindElement(By.CssSelector(".btn.btn-default"));

        private IWebElement registrationForConsultation => Driver.FindElement(By.CssSelector(".register_btn.btn.btn-primary"));

        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".time_element.primary.active"));


        public ConsultationPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != addressUrl)
            {
                Driver.Url = addressUrl;
            }
        }

        public void CloseCookie()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.CssSelector(".btn.btn-default")).Displayed);
            allowAllCookiesButton.Click();
        }

        public void RegisterBeautyConsultation()
        {
            registrationForConsultation.Click();
        }
        public void CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(resultElement.Text.Contains(result), $"Result is not correct, expected {result}, but was {resultElement.Text}");
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.CssSelector(".time_element.primary.active")).Displayed);
        }


    }
}
