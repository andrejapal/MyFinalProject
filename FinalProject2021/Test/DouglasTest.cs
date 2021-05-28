using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2021.Test
{
   public class DouglasTest : BaseTest
    {
        [Test]
        public static void TestProductswithGiftNYX()
        {
            _douglasHome.NavigateToPage();
            _douglasHome.CloseCookie();
            _douglasHome.SearchByText("NYX");
            _douglasHome.PressOnSearchIcon();
            _searchResult.SortByDouglas();
            _searchResult.OrderByDropdown();
            _searchResult.ClickToDovanaDropDown();
            _searchResult.VerifyPrice("7,39 €");
        }

        [Test]
        public static void TestOnlineConsultation()
        {
            _consultation.NavigateToPage();
            _consultation.CloseCookie();
            _consultation.RegisterBeautyConsultation();
            _consultation.CheckResult("10:00");
        }

        [Test]
        public static void TestAllNyxProducts()
        {
            _douglasHome.NavigateToPage();
            _douglasHome.CloseCookie();
            _douglasHome.SearchByText("NYX");
            _searchResult.CheckResult("168");

        }

        [Test]
        public static void TestDpuglasInternetShopPhoneNumber()
        {
            _workingTime.NavigateToPage();
            _workingTime.CloseCookie();
            _workingTime.FindTheInternetShop();
            _workingTime.CheckResult("(8 700) 50058");
        }

        [Test]
        public static void TestSubscribeNewsletter()
        {
            _douglasHome.NavigateToPage();
            _douglasHome.CloseCookie();
            _douglasHome.SearchDouglasNewsletterField("andreja.palubeckyte@gmail.com");
            _douglasHome.PressOnSubscribeIcon();
            _douglasHome.CheckResult("Ačiū, kad užsisakėte mūsų naujienlaiškį.");

        }
   }
}
