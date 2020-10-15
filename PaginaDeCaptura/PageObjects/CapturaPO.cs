using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


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
        private By byLoadContainer;

        public string TituloMensagem => driver.FindElement(byTituloMensagem).Text;
        public string ConteudoMensagem => driver.FindElement(byConteudoMensagem).Text;

        public CapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputCpf = By.Id("novacaptura__field--cpf");
            byInputNome = By.Id("novacaptura__field--nome");
            byInputData = By.Id("novacaptura__field--data-nascimento");
            byInputTelefone = By.Id("novacaptura__field--telefone");
            byInputEmail = By.Id("novacaptura__field--email");
            byInputIndicador = By.Id("novacaptura__field--codigo-indicador");
            byCheckTermos = By.XPath("//*[@id='app']/div/main/div/div/div/div/div/div/div[2]/div[1]/div/form/div/div[8]/p/a/i");
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

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://hlg-revenda.styllus.online/#/novo-cadastro");
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
            Thread.Sleep(500);
            driver.FindElement(byBotaoAceitoTermos).Click();
            driver.FindElement(byBotaoContinuarNovaCaptura).Click();

        }

        public void PreencherEndereco(string cep, string numero, string complemento)
        {
            driver.FindElement(byInputCep).SendKeys(cep);
            Thread.Sleep(500);
            driver.FindElement(byInputNumero).SendKeys(numero);
            driver.FindElement(byInputComplemento).SendKeys(complemento);
            driver.FindElement(byBotaoContinuarEndereco).Click();
        }

        public void SelecionarKit(string kit)
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 15))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(byLoadContainer));

            if (kit == "entrada")
            {
                driver.FindElement(byBotaoKitEntrada).Click();
            }
            else
            {
                driver.FindElement(byBotaoKitPassaporte).Click();
            }
        }

        public void SelecionarRecebimento(string frete)
        {
            if (frete == "receber depois")
            {
                driver.FindElement(byCheckReceberDepois).Click();
            }
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            driver.FindElement(byBotaoComprar).Click();
            driver.FindElement(byBotaoPagar).Click();
            driver.FindElement(byBotaoCartao).Click();
            driver.FindElement(byInputNumeroCartao).SendKeys(numero);
            Thread.Sleep(1000);
            driver.FindElement(byInputNomeCartao).SendKeys("Teste");

            var mesCartao = new SelectElement(driver.FindElement(bySelectMes));
            mesCartao.SelectByValue(mes);

            var anoCartao = new SelectElement(driver.FindElement(bySelectAno));
            anoCartao.SelectByValue(ano);

            driver.FindElement(byInputCodigo).SendKeys(codigo);

            driver.FindElement(byBotaoContinuarPagamento).Click();
            driver.FindElement(byBotaoConfirmarCheckout).Click();
        }
    }
}
