using Common;
using gestor.PageObjects;
using Gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class BuscarRevendedoraSteps : IDisposable
    {

        IWebDriver driver;
        LoginGestorPO loginPO;
        RevendedoraPO revendedoraPO;
        Utilitarios util;
        string url;

        public BuscarRevendedoraSteps()
        {
            driver = new ChromeDriver();
            util = new Utilitarios(driver);
            revendedoraPO = new RevendedoraPO(driver);
            loginPO = new LoginGestorPO(driver);
            url = util.GetUrl("gestor");
            loginPO.EfetuarLoginComDados(url, util.UsuarioLogin("gestor"), util.SenhaLogin("gestor"));
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"que estou na página de revendedoras")]
        public void DadoQueEstouNaPaginaDeRevendedoras()
        {
            revendedoraPO.Visitar();
        }
        
        [When(@"busco uma revendedora pelo ""(.*)"" no campo ""(.*)""")]
        public void QuandoBuscoUmaRevendedoraPeloNoCampo(string valor, string campo)
        {
            revendedoraPO.BuscarRevendedora(valor, campo);
        }

        [Then(@"visualizo apenas a revendedora correspondente pelo ""(.*)"" no campo ""(.*)""")]
        public void EntaoVisualizoApenasARevendedoraCorrespondentePeloNoCampo(string valor, string campo)
        {
            string revendedoraEncontrada = revendedoraPO.EncontrarRevendedora(campo);
            Assert.AreEqual(valor, revendedoraEncontrada);
        }


        [Then(@"não visualizo nenhuma revendedora com o codigo ""(.*)""")]
        public void EntaoNaoVisualizoNenhumaRevendedoraComOCodigo(string codigoStyllus)
        {
            Assert.False(driver.PageSource.Contains(codigoStyllus));
        }


    }
}
