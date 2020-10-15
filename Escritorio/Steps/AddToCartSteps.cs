using escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace Escritorio.Steps
{
    [Binding]
    public class AddToCartSteps
    {
        IWebDriver driver;
        PedidoRapidoPO produtosPO;
        CarrinhoPO carrinhoPO;
        LoginPO loginPO;
        HomePO homePO;
        string limiteCredito;
        string totalPedido;
        IEnumerable<dynamic> tabelaProdutos;

        public AddToCartSteps()
        {
            driver = Helpers.Helpers.IniciarDriver(new ChromeDriver());
            loginPO = new LoginPO(driver);
            produtosPO = new PedidoRapidoPO(driver);
            carrinhoPO = new CarrinhoPO(driver);
            homePO = new HomePO(driver);
            loginPO.Visitar("https://hlg-escritorio.styllus.online/#/");
            loginPO.EfetuarLoginComDados("1390398", "167581");
        }

        [Given(@"estou na página de pedido rápido")]
        public void DadoEstouNaPaginaDePedidoRapido()
        {
            produtosPO.Visitar("https://hlg-escritorio.styllus.online/#/pedido-rapido");
        }

        [Given(@"estou na página de produtos com fotos")]
        public void DadoEstouNaPaginaDeProdutosComFotos()
        {
            produtosPO.Visitar("https://hlg-escritorio.styllus.online/#/produtos");
        }


        [When(@"eu adiciono todos os itens")]
        public void QuandoEuAdicionoTodosOsItens(Table produtos)
        {
            tabelaProdutos = produtos.CreateDynamicSet();

            foreach (var prod in tabelaProdutos)
            {
                produtosPO.Produtos.PesquisarPorRef(prod.referencia.ToString());
                produtosPO.Produtos.AdicionarProdutos(prod.quantidade.ToString());
            }
            
        }
        
        [When(@"acesso meu carrinho")]
        public void QuandoAcessoMeuCarrinho()
        {
            carrinhoPO.Visitar("https://hlg-escritorio.styllus.online/#/pedidos/carrinho");
            carrinhoPO.EsperarCarregamento();
        }

        [Then(@"não consigo finalizar o pedido")]
        public void EntaoNaoConsigoFinalizarOPedido()
        {
            carrinhoPO.SelecionarFrete("Entrega Rápida");
            Assert.IsFalse(carrinhoPO.BotaoDesativado);
        }

        [Then(@"vejo a mensagem ""(.*)""")]
        public void EntaoVejoAMensagem(string mensagem)
        {
            Assert.AreEqual(mensagem, carrinhoPO.AlertaTotalPedido);
        }
 
        [Then(@"a forma de pagamento a prazo não deverá está presente")]
        public void EntaoAFormaDePagamentoNaoDeveraEstaPresente()
        {
            Assert.IsTrue(carrinhoPO.VerificarPagamentoFormaPrazo);
        }

        [Then(@"vejo o alerta ""(.*)""")]
        public void EntaoVejoOAlerta(string alerta)
        {
            Assert.AreEqual(carrinhoPO.AlertaLimiteCredito, alerta);
        }

        [Then(@"vejo todos os itens")]
        public void EntaoVejoTodosOsItens()
        {
            foreach (var prod in tabelaProdutos)
            {
                bool nomeProdutoNoCarrinho = driver.PageSource.Contains(prod.nome);
                bool descontoNoCarrinho = driver.PageSource.Contains(prod.desconto);

                Assert.IsTrue(nomeProdutoNoCarrinho);
                Assert.IsTrue(descontoNoCarrinho);
            }
            driver.Quit();
        }


    }
}

