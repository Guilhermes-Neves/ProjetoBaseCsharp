﻿using escritorio.PageObjects;
using Escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Escritorio.Steps
{
    [Binding]
    public class CheckoutDePedidosSteps : IDisposable
    {
        IWebDriver driver;
        LoginPO loginPO;
        PedidoRapidoPO produtosPO;
        CarrinhoPO carrinhoPO;
        ChekoutPO chekoutPO;
        string numero = "5259483778432661";
        string mes = "04";
        string ano = "21";
        string codigo = "483";
        string url;

        public void Dispose()
        {
            driver.Quit();
        }


        public CheckoutDePedidosSteps()
        {
            url = "https://hlg-escritorio.styllus.online/#/";
            driver = Helpers.Helpers.IniciarDriver(new ChromeDriver());
            loginPO = new LoginPO(driver);
            produtosPO = new PedidoRapidoPO(driver);
            carrinhoPO = new CarrinhoPO(driver);
            chekoutPO = new ChekoutPO(driver);
            loginPO.EfetuarLoginComDados(url, "83578", "130662");
        }

        [Given(@"que estou na página de pedido rápido")]
        public void DadoQueEstouNaPaginaDePedidoRapido()
        {
            produtosPO.Visitar(url + "pedido-rapido");
        }

        [When(@"eu adicionar todos os itens")]
        public void QuandoEuAdicionarTodosOsItens(Table produtos)
        {
            var listaProdutos = produtos.CreateDynamicSet();

            foreach (var prod in listaProdutos)
            {
                produtosPO.Produtos.PesquisarPorRef(prod.referencia.ToString());
                produtosPO.Produtos.AdicionarProdutos(prod.quantidade.ToString());
            }
        }

        [When(@"acessar meu carrinho")]
        public void QuandoAcessarMeuCarrinho()
        {
            carrinhoPO.Visitar(url + "pedidos/carrinho");
        }


        [When(@"seleciono a forma de pagamento ""(.*)""")]
        public void QuandoSelecionoAFormaDePagamento(string formaPagamento)
        {
            carrinhoPO.SelecionarPagamento(formaPagamento);
        }

        [When(@"seleciono o tipo de frete como ""(.*)""")]
        public void QuandoSelecionoOTipoDeFreteComo(string frete)
        {
            carrinhoPO.SelecionarFrete(frete);
        }

        [When(@"finalizo o checkout pagando com cartão")]
        public void QuandoFinalizoOCheckoutPagandoComCartao()
        {
            carrinhoPO.FinalizarPedido();
            chekoutPO.FinalizarCheckoutCartao(numero, mes, ano, codigo);

        }

        [Then(@"vejo a confirmação do checkout com a mensagem ""(.*)""")]
        public void EntaoVejoAConfirmacaoDoCheckoutComAMensagem(string mensagem)
        {
            Assert.AreEqual(mensagem, chekoutPO.PedidoFinalizado);
        }

    }
}
