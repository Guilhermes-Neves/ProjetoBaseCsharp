using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace PaginaDeCaptura.PageObjects
{
    public class CapturaPO
    {
        private IWebDriver driver;
        Utilitarios util;
        private By byInputCpf;
        private By byInputNome;
        private By byInputData;
        private By byInputTelefone;
        private By byInputEmail;
        private By byInputIndicador;
        private By byCheckTermos;
        private By byBotaoAceitoTermos;
        private By byBotaoContinuarNovaCaptura;
        private By byInputCep;
        private By byInputNumero;
        private By byInputComplemento;
        private By byBotaoContinuarEndereco;
        private By byBotaoKitEntrada;
        private By byBotaoKitPassaporte;
        private By byCheckReceberDepois;
        private By byBotaoComprar;
        private By byBotaoPagar;
        private By byBotaoCartao;
        private By byInputNumeroCartao;
        private By byInputNomeCartao;
        private By bySelectMes;
        private By bySelectAno;
        private By byInputCodigo;
        private By byBotaoContinuarPagamento;
        private By byBotaoConfirmarCheckout;
        private By byTituloMensagem;
        private By byConteudoMensagem;
        private By byLoadContainer;

        public string TituloMensagem => driver.FindElement(byTituloMensagem).Text;
        public string ConteudoMensagem => driver.FindElement(byConteudoMensagem).Text;

        public CapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver); 
            byInputCpf = By.Id("novacaptura__field--cpf");
            byInputNome = By.Id("novacaptura__field--nome");
            byInputData = By.Id("novacaptura__field--data-nascimento");
            byInputTelefone = By.Id("novacaptura__field--telefone");
            byInputEmail = By.Id("novacaptura__field--email");
            byInputIndicador = By.Id("novacaptura__field--codigo-indicador");
            byCheckTermos = By.CssSelector("i.primary--text");
            byBotaoAceitoTermos = By.Id("terms__button--aceitar");
            byBotaoContinuarNovaCaptura = By.Id("novacaptura__button--continuar");
            byInputCep = By.Id("endereco__field--cep");
            byInputNumero = By.Id("endereco__field--numero");
            byInputComplemento = By.Id("endereco__field--complemento");
            byBotaoContinuarEndereco = By.Id("endereco__button--continuar");
            byBotaoKitEntrada = By.Id("carrinho__kitentrada--choose");
            byBotaoKitPassaporte = By.Id("carrinho__kitpassaporte--choose");
            byCheckReceberDepois = By.Id("carrinho__receber-depois--choose");
            byBotaoComprar = By.Id("carrinho__button--comprar");
            byBotaoPagar = By.Id("pagamento__button--pagar");
            byBotaoCartao = By.Id("checkout__pagamento-credito--choose");
            byInputNumeroCartao = By.Id("cardNumber");
            byInputNomeCartao = By.Id("cardName");
            bySelectMes = By.Id("cardMonth");
            bySelectAno = By.Id("cardYear");
            byInputCodigo = By.Id("cardCvv");
            byBotaoContinuarPagamento = By.XPath("//*[@id='app']/div/div[2]/div[5]/div/button");
            byBotaoConfirmarCheckout = By.Id("checkout__button--confirmar");
            byTituloMensagem = By.Id("swal2-title");
            byConteudoMensagem = By.Id("swal2-content");
            byLoadContainer = By.ClassName("loading-container");
        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url + "novo-cadastro");
        }

        public void PreencherDadosPessoais(string nome, string telefone ,string codIndicador)
        {
            util.SendKey(byInputNome, nome, 10);
            util.SendKey(byInputTelefone, telefone, 10);
            util.SendKey(byInputEmail, "teste@teste.com", 10);
            util.SendKey(byInputIndicador, codIndicador, 10);
            util.OnClick(byCheckTermos, 10);
            util.OnClick(byBotaoAceitoTermos, 10);
            util.OnClick(byBotaoContinuarNovaCaptura, 10);

        }

        public void PreencherEndereco(string cep, string numero, string complemento)
        {
            util.SendKey(byInputCep, cep, 10);
            util.SendKey(byInputNumero, numero, 10);
            util.SendKey(byInputComplemento, complemento, 10);
            util.OnClick(byBotaoContinuarEndereco, 10);
        }

        public void PreencherCpfNascimento(string cpf, string data)
        {
            util.SendKey(byInputCpf, cpf, 30);
            util.SendKey(byInputData, data, 30);
        }

        public void FinalizarCadastro()
        {
            util.OnClick(byBotaoContinuarNovaCaptura, 30);
        }

        public void FinalizarCompra()
        {
            util.OnClick(byBotaoComprar, 30);
        }

        public void SelecionarKit(string kit)
        {
            if (kit == "entrada")
            {
                util.OnClick(byBotaoKitEntrada, 10);
            }
            else
            {
                util.OnClick(byBotaoKitPassaporte, 10);
            }
        }

        public void SelecionarRecebimento(string frete)
        {
            if (frete == "receber depois")
            {
                util.OnClick(byCheckReceberDepois, 10);
            }
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            util.OnClick(byBotaoPagar, 10);
            util.OnClick(byBotaoCartao, 10);
            util.SendKey(byInputNumeroCartao, numero, 10);
            util.SendKey(byInputNomeCartao, "Teste", 10);

            util.SelectValue(bySelectMes, mes, 10);
            util.SelectText(bySelectAno, ano, 10);

            util.SendKey(byInputCodigo, codigo, 10);

            util.OnClick(byBotaoContinuarPagamento, 10);
            util.OnClick(byBotaoConfirmarCheckout, 10);
        }
    }
}
