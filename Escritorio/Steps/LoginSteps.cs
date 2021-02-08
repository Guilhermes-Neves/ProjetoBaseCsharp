using escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace Escritorio.Steps
{
    [Binding]
    public class LoginSteps : IDisposable
    {
        IWebDriver driver;
        private static LoginPO loginPO;
        private static HomePO homePO;
        string url;

        public LoginSteps()
        {
            driver = new ChromeDriver();
            loginPO = new LoginPO(driver);
            homePO = new HomePO(driver);
            url = "http://localhost:8080/#/";

        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"que visito a página inicial")]
        public void DadoQueVisitoAPaginaInicial()
        {   
            loginPO.Visitar(url);
        }
        
        [When(@"preencho meus dados de acesso ""(.*)"" e ""(.*)""")]
        public void QuandoPreenchoMeusDadosDeAcessoE(string codStyllus, string password)
        {
            loginPO.PreencherFormulario(codStyllus, password);
            loginPO.SubmeterFormulario();            
        }
        
        [Then(@"eu vejo a mensagem (.*)")]
        public void EntaoEuVejoAMensagem(string message)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            bool iguais = wait.Until(drv => homePO.MensagemLogin == message);
            Assert.True(iguais);
        }


    }
}
