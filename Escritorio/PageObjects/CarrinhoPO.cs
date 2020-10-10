using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace escritorio.PageObjects
{
    public class CarrinhoPO
    {
        private IWebDriver driver;
        private By byTable;
        private By byAlertaTotalPedido;
        private By bySubtotal;
        private By byDesconto;
        private By byTotal;
        private By bySelectPagamento;
        private By byCheckEntregaNormal;
        private By byBotaoFinalizarPedido;

        public string AlertaTotalPedido => driver.FindElement(byAlertaTotalPedido).Text;

        public string TabelaDeProdutos => driver.FindElement(byTable).Text;
        public string Subtotal => driver.FindElement(bySubtotal).Text;
        public string Desconto => driver.FindElement(byDesconto).Text;
        public string Total => driver.FindElement(byTotal).Text;

        

        public CarrinhoPO(IWebDriver driver)
        {
            this.driver = driver;
            byTable = By.CssSelector("table tbody tr");
            byAlertaTotalPedido = By.CssSelector(".alert-danger .alert-content");
            bySubtotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[1]/strong");
            byDesconto = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[2]/strong");
            byTotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]/strong");
            bySelectPagamento = By.Id("fr_pgto");
            byCheckEntregaNormal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[2]/div/p");
            byBotaoFinalizarPedido = By.Id("place_order");
        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SelecionarPagamento(string formaPagamento)
        {
            var elementoFormaPagamento = new SelectElement(driver.FindElement(bySelectPagamento));
            elementoFormaPagamento.SelectByText(formaPagamento);
        }

        public void SelecionarFrete(string frete)
        {
            if (frete == "Entrega Normal")
            {
                driver.FindElement(byCheckEntregaNormal).Click();
            }
            if (frete == "Entrega Rápida")
            {

            }
            if (frete == "Frete Gratis")
            {

            }
        }
        
        public void FinalizarPedido()
        {
            driver.FindElement(byBotaoFinalizarPedido).Click();
        }


    }
}
