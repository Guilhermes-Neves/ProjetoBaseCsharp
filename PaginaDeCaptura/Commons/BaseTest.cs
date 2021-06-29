using Commons;
using Commons.Core;
using Commons.PageObject.Common;
using NUnit.Framework;

namespace PaginaCaptura.Commons
{
    public class BaseTest : Dictionary
    {
        //Declaração do WebDriver
        internal WebDriver driver = null;

        //Paginas dos Projetos
        public CapturaPO capturaPO = null;

        //Massa Global de testes
        internal string numero = "5259483778432661";
        internal string mes = "04";
        internal string ano = "21";
        internal string codigo = "483";
        internal string nome = null;
        internal string telefone = null;
        internal string cpf = null;
        internal string cep = null;
        internal string nascimento = null;
        internal string numeroCasa = null;



        [SetUp()]
        public void PrepararTeste()
        {
            //Iniciar webdriver
            driver = new WebDriver(Browser.CHROME);

            //Instanciar classes
            capturaPO = new CapturaPO(driver);

            //gerar massa
            nome = RevendedoraHelper.GetNome();
            telefone = RevendedoraHelper.GetTelefone();
            cpf = RevendedoraHelper.GetCPF();
            cep = "28630535";
            nascimento = RevendedoraHelper.GetNascimento();
            numeroCasa = RevendedoraHelper.GetNumero();
        }

        [TearDown()]
        public void FinalizarTeste()
        {
            driver.Quit();
        }
    }
}
