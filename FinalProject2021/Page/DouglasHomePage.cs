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
    public class DouglasHomePage : BasePage
    {

        private const string addressUrl = "https://www.douglas.lt/";
        private IWebElement allowAllCookiesButton => Driver.FindElement(By.CssSelector(".btn.btn-default"));
        private IWebElement searchInput => Driver.FindElement(By.CssSelector(".form-control.sn-suggest-input"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector(".ico.ico-search"));
        private IWebElement findDouglasNewsField => Driver.FindElement(By.CssSelector(".text.clear_on_focus"));
        private IWebElement subscribeIcon => Driver.FindElement(By.CssSelector(".submit.btn.btn-primary"));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".msg.alert.alert-success"));

        public DouglasHomePage(IWebDriver webDriver) : base(webDriver) { }

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


        public void SearchByText(string searchText)
        {
            searchInput.Clear();
            searchInput.SendKeys(searchText);
            searchIcon.Click();
        }

        public void PressOnSearchIcon()
        {
            searchIcon.Click();
        }

        public void SearchDouglasNewsletterField(string email)
        {
            findDouglasNewsField.Clear();
            findDouglasNewsField.SendKeys(email);
            subscribeIcon.Click();
        }
        public void PressOnSubscribeIcon()
        {
            subscribeIcon.Click();
        }
        public void CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(resultElement.Text.Contains(result), $"Result is not correct, expected {result}, but was {resultElement.Text}");
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.CssSelector(".msg.alert.alert-success")).Displayed);
        }
    }
}
