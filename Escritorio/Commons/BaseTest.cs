using Commons;
using Commons.Core;
using Commons.PageObject.Common;
using NUnit.Framework;
using System.Linq;

namespace Escritorio.Commons
{
    public class BaseTest : Dictionary
    {
        //Declaração do WebDriver
        internal WebDriver driver = null;

        //Paginas dos Projetos
        public CarrinhoPO carrinhoPO = null;
        public CheckoutPO checkoutPO = null;
        public ProdutosPO produtosPO = null;
        public LoginPO loginPO = null;
        public HomePO homePO = null;
        public Produtos produtos = null;

        //Massa Global de testes
        internal string usuarioEscritorio = "1396036";
        internal string senhaEscritorio = "130662";
        internal string numero = "5259483778432661";
        internal string mes = "04";
        internal string ano = "21";
        internal string codigo = "483";
        internal string limiteCreditoTexto = "";
        internal string limiteCreditoTextoCompleto = "";
        internal decimal limiteCredito = 0;
        internal decimal subTotal = 0;
        internal string pathJsonProdutos = @"c:\Temp\Produtos.json";

        [SetUp()]
        public void PrepararTeste()
        {
            //Iniciar webdriver
            driver = new WebDriver(Browser.CHROME);

            //Instanciar classes
            carrinhoPO = new CarrinhoPO(driver);
            checkoutPO = new CheckoutPO(driver);
            loginPO = new LoginPO(driver);
            produtosPO = new ProdutosPO(driver);
            carrinhoPO = new CarrinhoPO(driver);
            homePO = new HomePO(driver);
            produtos = new Produtos();

            //Iniciar report
            driver.InitiateReport(Report.PDF, TestContext.CurrentContext.Test.ClassName.Split('.').Last());
        }

        [TearDown()]
        public void FinalizarTeste()
        {
            driver.FinishReport();
            driver.Quit();
        }
    }
}
