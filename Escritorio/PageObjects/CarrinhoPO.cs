﻿using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace escritorio.PageObjects
{
    public class CarrinhoPO
    {
        private IWebDriver driver;
        private By byTable;
        private By byAlertaTotalPedido;
        private By byInputQuantidade;
        private By bySubtotal;
        private By byDesconto;
        private By byTotal;
        private By byOptionPagamentoPrazo;
        private By bySelectPagamento;
        private By byCheckEntregaNormal;
        private By byCheckEntregaRapida;
        private By byBotaoFinalizarPedido;
        private By byAlertaLimite;

        public string AlertaTotalPedido => driver.FindElement(byAlertaTotalPedido).Text;

        public string TabelaDeProdutos => driver.FindElement(byTable).Text;
        public string Subtotal => driver.FindElement(bySubtotal).Text;
        public string Desconto => driver.FindElement(byDesconto).Text;
        public string Total => driver.FindElement(byTotal).Text;

        public bool BotaoDesativado => driver.FindElement(byBotaoFinalizarPedido).Enabled;
        public bool VerificarPagamentoFormaPrazo => Esperar().Until(ExpectedConditions.InvisibilityOfElementWithText(byOptionPagamentoPrazo, "À Prazo - Até 30 dias no boleto"));
        public string AlertaLimiteCredito => driver.FindElement(byAlertaLimite).Text;

        public CarrinhoPO(IWebDriver driver)
        {
            this.driver = driver;
            byTable = By.CssSelector("table tbody tr");
            byAlertaTotalPedido = By.CssSelector(".alert.alert-modern.alert-danger");
            bySubtotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[1]/strong");
            byDesconto = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[2]/strong");
            byTotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]/strong");
            bySelectPagamento = By.Id("fr_pgto");
            byCheckEntregaNormal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[2]/div/p");
            byCheckEntregaRapida = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[3]/div/p");
            byBotaoFinalizarPedido = By.Id("place_order");
            byInputQuantidade = By.CssSelector("input.form-control.form-control-sm.text-center");
            byOptionPagamentoPrazo = By.XPath("//*[@id='fr_pgto']/option[2]");
            byAlertaLimite = By.CssSelector(".alert.alert-info");
        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void EsperarCarregamento()
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 15))
                .Until(ExpectedConditions.ElementIsVisible(byTable));
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        public void AlterarQuantidade(string quantidade)
        {
            driver.FindElement(byInputQuantidade).Clear();
            driver.FindElement(byInputQuantidade).SendKeys(quantidade);
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
                driver.FindElement(byCheckEntregaRapida).Click();
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
