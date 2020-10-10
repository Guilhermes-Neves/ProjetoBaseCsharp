using escritorio.PageObjects;
using Escritorio.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace Escritorio.Steps
{
    [Binding]
    public class LoginSteps
    {
        private static IWebDriver driver;
        private static LoginPO loginPO;
        private static HomePO homePO;
        
        public LoginSteps()
        {
            driver = new ChromeDriver();
            loginPO = new LoginPO(driver);
            homePO = new HomePO(driver);
        }

        [Given(@"que visito a página inicial ""(.*)""")]
        public void DadoQueVisitoAPaginaInicial(string url)
        {   
            loginPO.Visitar(url);
        }
        
        [When(@"preencho meus dados de acesso ""(.*)"" e ""(.*)""")]
        public void QuandoPreenchoMeusDadosDeAcessoE(string codStyllus, string password)
        {

            loginPO.EfetuarLoginComDados(codStyllus, password);
            
        }
        
        [Then(@"eu vejo a mensagem (.*)")]
        public void EntaoEuVejoAMensagem(string message)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            bool iguais = wait.Until(drv => homePO.MensagemLogin == message);
            Assert.True(iguais);

            driver.Quit();
        }
    }
}
