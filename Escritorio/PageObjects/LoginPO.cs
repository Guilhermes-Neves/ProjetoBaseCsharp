﻿using OpenQA.Selenium;


namespace escritorio.PageObjects
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
            byInputLogin = By.Id("input-email");
            byInputPassword = By.Id("input-password");
            byBotaoLogin = By.ClassName("btn-primary");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

   
        public void Visitar()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online/#/");
        }

        public void PreencherFormulario(string codStyllus, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(codStyllus);
            driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBotaoLogin).Click();
        }

        public void EfetuarLoginComDados(string codStyllus, string password)
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online");
            driver.FindElement(byInputLogin).SendKeys(codStyllus);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byBotaoLogin).Click();
        }


    }
}
