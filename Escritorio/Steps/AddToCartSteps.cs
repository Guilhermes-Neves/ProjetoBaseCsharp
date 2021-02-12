using escritorio.PageObjects;
using gestor.PageObjects;
using Gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using Common;
using TechTalk.SpecFlow.Assist;



namespace Escritorio.Steps
{
    [Binding]
    public class AddToCartSteps : IDisposable
    {
        IWebDriver driver;
        PedidoRapidoPO produtosPO;
        CarrinhoPO carrinhoPO;
        LoginPO loginPO;
        HomePO homePO;
        LoginGestorPO loginGestorPO;
        HomeGestorPO homeGestorPO;
        RevendedoraPO revendedoraPO;
        Utilitarios util;
        IEnumerable<dynamic> tabelaProdutos;
        string url;
        string urlGestor;

        public AddToCartSteps()
        {
            driver = Helpers.Helpers.IniciarDriver(new ChromeDriver());
            util = new Utilitarios(driver);
            loginPO = new LoginPO(driver);
            produtosPO = new PedidoRapidoPO(driver);
            carrinhoPO = new CarrinhoPO(driver);
            homePO = new HomePO(driver);
            loginGestorPO = new LoginGestorPO(driver);
            homeGestorPO = new HomeGestorPO(driver);
            revendedoraPO = new RevendedoraPO(driver);
            url = util.GetUrl("escritorio");
            urlGestor = util.GetUrl("gestor");
            loginPO.EfetuarLoginComDados(url, util.UsuarioLogin("escritorio"), util.SenhaLogin("escritorio"));
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"estou na página de pedido rápido")]
        public void DadoEstouNaPaginaDePedidoRapido()
        {
            produtosPO.Visitar(url + "pedido-rapido");
        }

        [Given(@"estou na página de produtos com fotos")]
        public void DadoEstouNaPaginaDeProdutosComFotos()
        {
            produtosPO.Visitar(url + "produtos");
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
            carrinhoPO.Visitar(url + "pedidos/carrinho");
            carrinhoPO.EsperarCarregamento();
        }

        [When(@"eu adiciono todos os itens com cor e tamanho")]
        public void QuandoEuAdicionoTodosOsItensComCorETamanho(Table produtos)
        {
            tabelaProdutos = produtos.CreateDynamicSet();

            foreach (var prod in tabelaProdutos)
            {
                produtosPO.Produtos.PesquisarPorRef(prod.referencia.ToString());
                produtosPO.Produtos.SelecionarTamanho(prod.tamanho.ToString());
                produtosPO.Produtos.SelecionarCor(prod.cor.ToString());
                produtosPO.Produtos.AdicionarProdutos(prod.quantidade.ToString());
            }
        }

        [When(@"eu seleciono cor e tamanho dos itens")]
        public void QuandoEuSelecionoCorETamanhoDosItens(Table produtos)
        {
            tabelaProdutos = produtos.CreateDynamicSet();

            foreach (var prod in tabelaProdutos)
            {
                produtosPO.Produtos.PesquisarPorRef(prod.referencia.ToString());
                produtosPO.Produtos.SelecionarTamanho(prod.tamanho.ToString());
                produtosPO.Produtos.SelecionarCor(prod.cor.ToString());
            }
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

        [Then(@"vejo a alerta numero (.*) com a mensagem ""(.*)""")]
        public void EntaoVejoAAlertaNumeroComAMensagem(int tipo, string mensagem)
        {
            string teste = carrinhoPO.Alerta(tipo);
            Assert.AreEqual(teste, mensagem);
        }

        [Then(@"vejo os descontos corretos")]
        public void EntaoVejoOsDescontosCorretos()
        {
            foreach (var prod in tabelaProdutos)
            {
                Thread.Sleep(500);
                Assert.AreEqual(carrinhoPO.DescontoItem, prod.desconto);
            }
        }

        [Then(@"vejo todos os itens")]
        public void EntaoVejoTodosOsItens()
        {
            try
            {
                foreach (var prod in tabelaProdutos)
                {
                    bool nomeProdutoNoCarrinho = driver.PageSource.Contains(prod.nome);
                    bool descontoNoCarrinho = driver.PageSource.Contains(prod.desconto);

                    Assert.IsTrue(nomeProdutoNoCarrinho);
                    Assert.IsTrue(descontoNoCarrinho);
                }
            }
            catch (NoSuchElementException)
            {

                Assert.Fail();
            }

            
        }

        [Then(@"vejo o texto indisponível ""(.*)""")]
        public void EntaoVejoOTextoIndisponivel(string mensagem)
        {
            Assert.AreEqual(mensagem, produtosPO.Produtos.MensagemEstoque);
        }



        //Parte do gestor
        [When(@"que edito uma revendedora")]
        public void DadoQueEditoUmaRevendedora()
        {
            loginGestorPO.EfetuarLoginComDados(urlGestor, util.UsuarioLogin("gestor"), util.SenhaLogin("gestor"));
            revendedoraPO.Visitar();
            revendedoraPO.BuscarRevendedora(util.UsuarioLogin("escritorio"), "codStyllus");
            revendedoraPO.EditarRevendedora();
        }

        [When(@"adiciono cashback para a mesma")]
        public void QuandoAdicionoCashbackParaAMesma()
        {
            revendedoraPO.AdicionarCashBack("500", "15122022");
        }

        [When(@"utilizo ""(.*)"" reais de cashback")]
        public void QuandoUtilizoReaisDeCashback(string valorCashback)
        {
            carrinhoPO.AplicarCashback(valorCashback);
        }

        [When(@"eu seleciono a forma de pagamento ""(.*)""")]
        public void QuandoSelecionoAFormaDePagamento(string formaPagamento)
        {
            carrinhoPO.SelecionarPagamento(formaPagamento);
        }

        [Then(@"a mensagem ""(.*)"" não é exibida")]
        public void EntaoAMensagemNaoEExibida(string mensagem)
        {
            Assert.AreEqual(mensagem, carrinhoPO.AlertaLimiteCredito);
        }


    }
}

