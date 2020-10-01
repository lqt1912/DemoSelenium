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
        public void Register()
        {
            _page.UsernameInput("addddddd");
            _page.PasswordInput("aaaaaa");
            _page.PhoneInput("013242343");
            _page.DobInput(DateTime.Now);
            _page.Submit();

            Assert.Contains("", _page.Validator);

        }
    }
}
