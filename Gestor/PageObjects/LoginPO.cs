﻿using OpenQA.Selenium;

namespace gestor.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputPassword;
        private By byBotaoLogin;


        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.CssSelector("input[name='email']");
            byInputPassword = By.XPath("//*[@id='app']/div/main/div/div[2]/div/div/form/div[2]/input");
            byBotaoLogin = By.ClassName("login100-form-btn");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }


        public void Visitar()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://hlg-painel.styllus.online/#/pages/login");
        }

        public void PreencherFormulario(string email, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBotaoLogin).Click();
        }

        public void EfetuarLoginComDados(string email, string password)
        {
            driver.Navigate().GoToUrl("http://hlg-painel.styllus.online/#/pages/login");
            driver.FindElement(byInputLogin).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byBotaoLogin).Click();
        }


    }
}
