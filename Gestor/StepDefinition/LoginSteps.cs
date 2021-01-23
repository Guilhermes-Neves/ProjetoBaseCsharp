using gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class LoginSteps
    {
        private static IWebDriver driver;
        private static LoginPO loginPO;
        private static HomePO homePO;
        string url;

        public LoginSteps()
        {
            url = "http://localhost:8081/#/";
            driver = new ChromeDriver();
            loginPO = new LoginPO(driver);
            homePO = new HomePO(driver);
        }

        [Given(@"que visito a página inicial")]
        public void DadoQueVisitoAPaginaInicial()
        {
            loginPO.Visitar(url);
        }
        
        [When(@"preencho meus dados de acesso ""(.*)"" e ""(.*)""")]
        public void QuandoPreenchoMeusDadosDeAcessoE(string email, string password)
        {
            loginPO.PreencherFormulario(email, password);
            loginPO.SubmeterFormulario();
        }
        
        [Then(@"eu vejo a mensagem (.*)")]
        public void EntaoEuVejoAMensagem(string mensagem)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            bool iguais = wait.Until(drv => homePO.MensagemLogin == mensagem);
            Assert.True(iguais);

            driver.Quit();
        }
    }
}
