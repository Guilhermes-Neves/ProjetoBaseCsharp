using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaginaDeCaptura.PageObjects
{
    public class CapturaPO
    {

        private IWebDriver driver;
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

        public CapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputCpf = By.Id("novacaptura__field--cpf");
            byInputNome = By.Id("novacaptura__field--nomes");
            byInputData = By.Id("novacaptura__field--data-nascimento");
            byInputTelefone = By.Id("novacaptura__field--telefone");
            byInputEmail = By.Id("novacaptura__field--email");
            byInputIndicador = By.Id("novacaptura__field--codigo-indicador");
            byCheckTermos = By.ClassName("primary--text");
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
        }

        public void PreencherDadosPessoais(string cpf, string codIndicador)
        {
            driver.FindElement(byInputCpf).SendKeys(cpf);
            driver.FindElement(byInputNome).SendKeys("Teste Automatizado");
            driver.FindElement(byInputData).SendKeys("01011999");
            driver.FindElement(byInputTelefone).SendKeys("22999999999");
            driver.FindElement(byInputEmail).SendKeys("teste@teste.com");
            driver.FindElement(byInputIndicador).SendKeys(codIndicador);
            driver.FindElement(byCheckTermos).Click();

 


        }
    }
}
