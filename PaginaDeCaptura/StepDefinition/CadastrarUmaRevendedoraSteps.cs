using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PaginaDeCaptura.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PaginaDeCaptura.StepDefinition
{
    [Binding]
    public class CadastrarUmaRevendedoraSteps
    {

        IWebDriver driver;
        CapturaPO capturaPO;
        string codigoStyllus = string.Empty;
        string cpf = string.Empty;
        string numero = "5259483778432661";
        string mes = "04";
        string ano = "21";
        string codigo = "483";
        string url;

        public CadastrarUmaRevendedoraSteps()
        {
            url = "https://hlg-revenda.styllus.online/#/";
            driver = Helpers.InitHelpers.IniciarDriver(new ChromeDriver());
            capturaPO = new CapturaPO(driver);
            cpf = Helpers.CpfHelper.GetCpf(false);
        }

        [Given(@"que acesso a página de captura")]
        public void DadoQueAcessoAPaginaDeCaptura()
        {
            capturaPO.Visitar(url);
        }
        
        [When(@"faço o cadastro da revendedora")]
        public void QuandoFacoOCadastroDaRevendedora()
        {
            capturaPO.PreencherDadosPessoais(cpf, "");
            capturaPO.PreencherEndereco("28630535", "4", "Apartamento");
        }

        [When(@"seleciono o kit de ""(.*)""")]
        public void QuandoSelecionoOKitDe(string kit)
        {
            capturaPO.SelecionarKit(kit);
        }


        [When(@"seleciono para o frete como ""(.*)""")]
        public void QuandoSelecionoParaOFreteComo(string frete)
        {
            capturaPO.SelecionarRecebimento(frete);
        }


        [When(@"efetuo pagamento com cartão")]
        public void QuandoEfetuoPagamentoComCartao()
        {
            capturaPO.FinalizarCheckoutCartao(numero, mes, ano, codigo);
        }

        [Then(@"vejo a mensagem")]
        public void EntaoVejoAMensagem(Table mensagem)
        {
            Assert.AreEqual(mensagem.Rows[0][0].ToString(), capturaPO.TituloMensagem);
            Assert.AreEqual(mensagem.Rows[1][0].ToString(), capturaPO.ConteudoMensagem);

            driver.Quit();
        }


    }
}
