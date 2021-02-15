using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PaginaDeCaptura.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System;
using Common;
using PaginaDeCaptura.Helpers;

namespace PaginaDeCaptura.StepDefinition
{
    [Binding]
    public class CadastrarUmaRevendedoraSteps : IDisposable
    {

        IWebDriver driver;
        CapturaPO capturaPO;
        Utilitarios util;
        string codigoStyllus = string.Empty;
        string nome = string.Empty;
        string telefone = string.Empty;
        string cpf = string.Empty;
        string cep = string.Empty;
        string nascimento = string.Empty;
        string numeroCasa = string.Empty;
        string numeroCard = "5259483778432661";
        string mes = "04";
        string ano = "2021";
        string codigo = "483";
        string url;

        public CadastrarUmaRevendedoraSteps()
        {
            driver = Helpers.InitHelpers.IniciarDriver(new ChromeDriver());
            util = new Utilitarios(driver);
            capturaPO = new CapturaPO(driver);
            url = util.GetUrl("paginaCaptura");
            nome = Helpers.RevendedoraHelper.GetNome();
            telefone = Helpers.RevendedoraHelper.GetTelefone();
            cpf = Helpers.RevendedoraHelper.GetCPF();
            cep = "28630535";
            nascimento = Helpers.RevendedoraHelper.GetNascimento();
            numeroCasa = Helpers.RevendedoraHelper.GetNumero();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"que acesso a página de captura")]
        public void DadoQueAcessoAPaginaDeCaptura()
        {
            capturaPO.Visitar(url);
        }
        
        [When(@"faço o cadastro da revendedora")]
        public void QuandoFacoOCadastroDaRevendedora()
        {
            capturaPO.PreencherDadosPessoais(nome, telefone ,"");
            capturaPO.PreencherEndereco(cep, numeroCasa, "Apartamento");
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
            capturaPO.FinalizarCompra();
        }

        [When(@"preencho o cpf e a data de nascimento")]
        public void QuandoPreenchoOCpfEADataDeNascimento()
        {
            capturaPO.PreencherCpfNascimento(cpf, nascimento);
            capturaPO.FinalizarCadastro();
        }



        [When(@"efetuo pagamento com cartão")]
        public void QuandoEfetuoPagamentoComCartao()
        {
            capturaPO.FinalizarCheckoutCartao(numeroCard, mes, ano, codigo);
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
