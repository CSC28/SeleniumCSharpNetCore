using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumCSharpNetCore
{
    public class Tests
    {

        public IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");
            Driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {

            var acceptCookieButton = Driver.FindElement(By.Id("cookiescript_accept"));
            var firstNameField = Driver.FindElement(By.Id("first-name"));
            var lastNameField = Driver.FindElement(By.Id("last-name"));
            var emailField = Driver.FindElement(By.Id("email"));
            var passwordField = Driver.FindElement(By.Id("sign-up-password-input"));
            var passwordConfirmField = Driver.FindElement(By.Id("sign-up-confirm-password-input"));
            var ddown = Driver.FindElement(By.Id("sign-up-heard-input"));
            var select = new SelectElement(ddown);
            var loaderButton = Driver.FindElement(By.Id(" qa_loader-button"));
            var actions = new Actions(Driver);

            acceptCookieButton.Click();
            firstNameField.SendKeys("Samuel");
            lastNameField.SendKeys("Ciobanu");
            emailField.SendKeys("valid.email4@gmail.com");
            passwordField.SendKeys("Validpassword1");
            passwordConfirmField.SendKeys("Validpassword1");
            select.SelectByText("Social networks");
            loaderButton.Click();          
            var signupButton = Driver.FindElement(By.CssSelector(".participant-container"));
            actions.MoveToElement(signupButton);
            signupButton.Click();
            var politripTitle = Driver.FindElement(By.CssSelector(".centered-title"));
            Assert.IsTrue(politripTitle.Displayed);

            Driver.Quit();
        }


        [Test]
        public void Test2()
        {
            Driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");

            Driver.FindElement(By.Id("first-name")).SendKeys("Samuel");
            Driver.FindElement(By.Id("last-name")).SendKeys("Ciobanu");
            Driver.FindElement(By.Id("email")).SendKeys("invalid.emailinvalid.com");
            Driver.FindElement(By.Id("sign-up-password-input")).SendKeys("Validpassword1");
            Driver.FindElement(By.Id("sign-up-confirm-password-input")).SendKeys("Validpassword1");

            var ddown = Driver.FindElement(By.Id("sign-up-heard-input"));
            var select = new SelectElement(ddown);

            select.SelectByText("From a friend");

            Driver.FindElement(By.Id(" qa_loader-button")).Click();
            Driver.Quit();
            Console.WriteLine("Test2");
            Assert.Pass();



          
            }

        [Test]
        public void Test3()
        {
            Driver.Navigate().GoToUrl("https://politrip.com/account/sign-up");

            Driver.FindElement(By.Id("first-name")).SendKeys("Samuel");
            Driver.FindElement(By.Id("last-name")).SendKeys("Ciobanu");
            Driver.FindElement(By.Id("email")).SendKeys("valid.email@gmail.com");
            Driver.FindElement(By.Id("sign-up-password-input")).SendKeys("invalidpassword");
            Driver.FindElement(By.Id("sign-up-confirm-password-input")).SendKeys("invalidpassword");

            var ddown = Driver.FindElement(By.Id("sign-up-heard-input"));
            var select = new SelectElement(ddown);

            select.SelectByText("Web-Search");

            Driver.FindElement(By.Id(" qa_loader-button")).Click();

            Driver.Quit();
            Console.WriteLine("Test3");
            Assert.Pass();
        }









    }

}