using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Escritorio.PageObjects
{
    public class ChekoutPO
    {
        private IWebDriver driver;
        private By byBotaoCartao;
        private By byInputNumeroCartao;
        private By byInputNomeCartao;
        private By bySelectMes;
        private By bySelectAno;
        private By byInputCodigo;
        private By byBotaoContinuar1;
        private By byBotaoContinuar2;
        private By byBotaoConfirmar;
        private By byPedidoFinalizado;
        private By byBotaoPagar;

        public string PedidoFinalizado => driver.FindElement(byPedidoFinalizado).Text;

        public ChekoutPO(IWebDriver driver)
        {
            this.driver = driver;
            byBotaoCartao = By.XPath("//*[@id='checkoutModal']/div/div/div[2]/div/form/button[2]");
            byInputNumeroCartao = By.Id("cardNumber");
            byInputNomeCartao = By.Id("cardName");
            bySelectMes = By.Id("cardMonth");
            bySelectAno = By.Id("cardYear");
            byInputCodigo = By.Id("cardCvv");
            byBotaoContinuar1 = By.XPath("//*[@id='app']/div/div[2]/div[5]/div/button[1]");
            byBotaoContinuar2 = By.XPath("//*[@id='checkoutModal']/div/div/div[2]/div/div/form/button[1]");
            byBotaoConfirmar = By.XPath("//*[@id='checkoutModal']/div/div/div[2]/div/div/button[1]");
            byPedidoFinalizado = By.Id("swal2-content");
            byBotaoPagar = By.CssSelector("button.btn-success");
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            Thread.Sleep(5000);
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

            driver.FindElement(byBotaoContinuar1).Click();
            driver.FindElement(byBotaoContinuar2).Click();

            driver.FindElement(byBotaoConfirmar).Click();

        }
    }
}
