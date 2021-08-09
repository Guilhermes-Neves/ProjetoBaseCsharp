using Commons;
using Commons.Core;
using Commons.PageObject.Common;
using NUnit.Framework;
using System.Linq;

namespace ProjetoWeb.Commons
{
    public class BaseTest : Dictionary
    {
        //Declaração do WebDriver
        internal WebDriver driver = null;

        //Paginas dos Projetos
        public LoginPO loginPO = null;

        //Massa Global de testes

        [SetUp()]
        public void PrepararTeste()
        {
            //Iniciar webdriver
            driver = new WebDriver(Browser.CHROME);

            //Instanciar classes
            loginPO = new LoginPO(driver);

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
