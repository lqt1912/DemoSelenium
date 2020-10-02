using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace DemoSelenium.Tests
{
    public class AutomatedTest:IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly CustomerRegisterPage _page;

        public AutomatedTest()
        {
            _driver = new ChromeDriver();
            _page = new CustomerRegisterPage(_driver);
            _page.Navigate();

        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Register0()
        {
            _page.UsernameInput("admin");
            _page.PasswordInput("adminnnnnnnnnnnnnnn");
            _page.PhoneInput("0123456780009");
            _page.Submit();
            Assert.Contains("CustomerList", _page.Title);
        }

        [Fact]
        public void Register1()
        {
            _page.UsernameInput("");
            _page.PasswordInput("adminnnnnnnnnnnnnnn");
            _page.PhoneInput("0123456780009");
            _page.Submit();

            Assert.Contains("Please enter the name", _page.UsernameValidator);
        }

        [Fact]
        public void Register2()
        {
            _page.UsernameInput("adminnnnnnnnnn");
            _page.PasswordInput("");
            _page.PhoneInput("0123456780009");
            _page.Submit();

            Assert.Contains("Please enter the Password", _page.PasswordValidator);
        }

        [Fact]
        public void Register3()
        {
            _page.UsernameInput("adminnnnnnnnnn");
            _page.PasswordInput("");
            _page.PhoneInput("01234567800aaa");
            _page.Submit();

            Assert.Contains("UPRN must be numeric", _page.PhoneValidator);
        }


    }
}
