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
    public class SearchResultPage : BasePage
    {
        private const string BuyByGiftsOptionText = "Dovana";

        IReadOnlyCollection<IWebElement> resultList => Driver.FindElements(By.CssSelector(".product_element"));

        private IWebElement orderbyDropdown => Driver.FindElement(By.XPath("//span[text()='Spec. pasiūlymas']"));

        private IWebElement clickonGifts => Driver.FindElement(By.XPath("//span[contains(text(), 'Dovana')]"));

        private IWebElement resultElement => Driver.FindElement(By.CssSelector(".page_title"));



        public SearchResultPage(IWebDriver webdriver) : base(webdriver) { }

        public void SortByDouglas()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.XPath("//span[text()='Spec. pasiūlymas']")).Displayed);
        }

        public void OrderByDropdown()
        {
            orderbyDropdown.Click();

        }
        public void ClickToDovanaDropDown()
        {
            clickonGifts.Click();
        } 

        public void VerifyPrice(string price)
        {
            IWebElement firstItem = resultList.ElementAt(0);
            IWebElement newPriceElemet = firstItem.FindElement(By.CssSelector(".old_price"));
            Assert.IsTrue(price.Equals(newPriceElemet.Text), "Price is wrong");
        }
        public void CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(resultElement.Text.Contains(result), $"Result is not correct, expected {result}, but was {resultElement.Text}");
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.CssSelector(".page_title")).Displayed);
        }
    }  
}
