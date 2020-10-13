using escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        public AddToCartSteps()
        {
            driver = Helpers.Helpers.IniciarDriver(new ChromeDriver());
            loginPO = new LoginPO(driver);
            produtosPO = new PedidoRapidoPO(driver);
            carrinhoPO = new CarrinhoPO(driver);
            loginPO.Visitar("https://hlg-escritorio.styllus.online/#/");
            loginPO.EfetuarLoginComDados("1390398", "167581");
        }

        [Given(@"estou na página de pedido rápido")]
        public void DadoEstouNaPaginaDePedidoRapido()
        {
            produtosPO.Visitar("https://hlg-escritorio.styllus.online/#/pedido-rapido");
        }
        
        [When(@"eu adiciono todos os itens")]
        public void QuandoEuAdicionoTodosOsItens(Table produtos)
        {
            var tabelaProdutos = produtos.CreateDynamicSet();

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
        }
                
        [Then(@"vejo todos os itens")]
        public void EntaoVejoTodosOsItens(Table produtos)
        {
            var tabelaProdutos = produtos.CreateDynamicSet();

            foreach (var prod in tabelaProdutos)
            {
                bool nomeProdutoNoCarrinho = driver.PageSource.Contains(prod.nome);
                bool descontoNoCarrinho = driver.PageSource.Contains(prod.desconto);

                Assert.IsTrue(nomeProdutoNoCarrinho);
                Assert.IsTrue(descontoNoCarrinho);
            }


            
        }
        
        [Then(@"os valores totais são:")]
        public void EntaoOsValoresTotaisSao(Table totais)
        {
            var subTotal = totais.Rows[0][1];
            var desconto = totais.Rows[1][1];
            var total = totais.Rows[2][1];


            Assert.IsTrue(carrinhoPO.Subtotal.Contains(subTotal));
            Assert.IsTrue(carrinhoPO.Desconto.Contains(desconto));
            Assert.IsTrue(carrinhoPO.Total.Contains(total));
            driver.Quit();
        }
    }
}

