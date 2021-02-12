using gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Common;

namespace Gestor.StepDefinition
{
    [Binding]
    public class LoginSteps : IDisposable
    {
        IWebDriver driver;
        LoginGestorPO loginPO;
        HomeGestorPO homePO;
        Utilitarios util;
        string url;

        public LoginSteps()
        {
            driver = new ChromeDriver();
            loginPO = new LoginGestorPO(driver);
            homePO = new HomeGestorPO(driver);
            util = new Utilitarios(driver);
            url = util.GetUrl("gestor");
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
