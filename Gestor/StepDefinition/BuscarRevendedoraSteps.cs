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
        string url;

        public BuscarRevendedoraSteps()
        {
            url = "http://localhost:8081/#/";
            driver = new ChromeDriver();
            revendedoraPO = new RevendedoraPO(driver);
            loginPO = new LoginGestorPO(driver);
            loginPO.EfetuarLoginComDados(url, "pedro.albani@portalstyllus.com.br", "Styllus2020!@#");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
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
