using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace escritorio.PageObjects
{
    public class PedidoRapidoPO
    {
        private const int V = 10;
        private IWebDriver driver;
        private By byInputReferencia;
        private By byInputQuantidade;
        private By byBotaoBuscar;
        private By byBotaoAdicionar;

        public object TimeUnit { get; }

        public PedidoRapidoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputReferencia = By.XPath("//*[@id='app']/div/div[2]/div/div/div[1]/div/form/div/div[1]/div/input");
            byInputQuantidade = By.CssSelector("input[type='number']");
            byBotaoBuscar = By.ClassName("btn-buscar");
            byBotaoAdicionar = By.ClassName("btn-add");


        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online/#/pedido-rapido");
        }

        public void FiltrarProduto(string referencia)
        {
            driver.FindElement(byInputReferencia).SendKeys(referencia);
            driver.FindElement(byBotaoBuscar).Click();
        }

        public void AdicionarProduto(string quantidade)
        {
            driver.FindElement(byInputQuantidade).SendKeys(quantidade);
            driver.FindElement(byBotaoAdicionar).Click();

        }
    }
}
