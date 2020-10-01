using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSelenium.Tests
{
    public class CustomerRegisterPage
    {
        private readonly IWebDriver _driver;

        public CustomerRegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        private const string URI = "https://localhost:44331/Home/Register";
        public string Validator => _driver.FindElement(By.Id("validator")).Text;
        private IWebElement UsernameElement => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("password"));
        private IWebElement DobElement => _driver.FindElement(By.Id("dob"));
        private IWebElement PhoneElement => _driver.FindElement(By.Id("phone"));
        private IWebElement Create => _driver.FindElement(By.Id("create"));
        public void Navigate() => _driver.Navigate().GoToUrl(URI);


        public void UsernameInput(string username) => UsernameElement.SendKeys(username);
        public void PasswordInput(string password) => PasswordElement.SendKeys(password);
        public void DobInput(DateTime dateTime) => DobElement.SendKeys(dateTime.ToString());
        public void PhoneInput(string phone) => PhoneElement.SendKeys(phone);
        public void Submit() => Create.Click();

    }
}
