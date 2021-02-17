using Common;
using Common.PageObject;
using Common.PageObject.Gestor;
using gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class PedidosEscritorioSteps : IDisposable
    {

        IWebDriver driver;
        LoginGestorPO loginPO;
        Utilitarios util;
        PedidosEcritorioPO pedidosEscritorioPO;
        string url;

        public PedidosEscritorioSteps()
        {
            driver = new ChromeDriver();
            util = new Utilitarios(driver);
            pedidosEscritorioPO = new PedidosEcritorioPO(driver);
            loginPO = new LoginGestorPO(driver);
            url = util.GetUrl("gestor");
            loginPO.EfetuarLoginComDados(url, util.UsuarioLogin("gestor"), util.SenhaLogin("gestor"));
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"que estou na página de pedidos do escritório")]
        public void DadoQueEstouNaPaginaDePedidosDoEscritorio()
        {
            pedidosEscritorioPO.Visitar();
        }
        
        [When(@"aplico o filtro ""(.*)"" no ""(.*)""")]
        public void QuandoAplicoOFiltroNo(string valor, string campo)
        {
            pedidosEscritorioPO.pedidos.AplicarFiltro(valor, campo);
        }
        
        [Then(@"visualizo pedidos com o ""(.*)"" no ""(.*)""")]
        public void EntaoVisualizoPedidosComONo(string valor, string campo)
        {
            string pedidoEncontrado = pedidosEscritorioPO.pedidos.EncontrarPedido(campo);
            valor = valor.Replace("NS", "...");
            Assert.AreEqual(valor, pedidoEncontrado);
        }


    }
}
