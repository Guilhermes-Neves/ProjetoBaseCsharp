using Commons;
using Commons.Core;
using Commons.PageObject.Common;
using NUnit.Framework;
using System.Linq;

namespace Gestor.Commons
{
    public class BaseTest : Dictionary
    {
        //Declaração do WebDriver
        internal WebDriver driver = null;

        //Paginas dos Projetos
        
        public HomeGestorPO homeGestorPO = null;
        public LoginGestorPO loginGestorPO = null;
        public PedidosCapturaPO pedidosCapturaPO = null;
        public PedidosEcritorioPO pedidosEscritorioPO = null;
        public RevendedoraPO revendedoraPO = null;

        //Massa Global de testes
        internal string usuarioGestor = "pedro.albani@portalstyllus.com.br";
        internal string senhaGestor = "000158";
        internal string numero = "5259483778432661";
        internal string mes = "04";
        internal string ano = "21";
        internal string codigo = "483";
        internal string cpfRevendedora = "";
        internal string nomeRevendedora = "";
        internal string codStyllusRevendedora = "";

        [SetUp()]
        public void PrepararTeste()
        {
            //Iniciar webdriver
            driver = new WebDriver(Browser.CHROME);

            //Instanciar classes
            homeGestorPO = new HomeGestorPO(driver);
            loginGestorPO = new LoginGestorPO(driver);
            pedidosCapturaPO = new PedidosCapturaPO(driver);
            pedidosEscritorioPO = new PedidosEcritorioPO(driver);
            revendedoraPO = new RevendedoraPO(driver);

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
