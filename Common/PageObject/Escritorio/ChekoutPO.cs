using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Escritorio.Helpers;
using Common;

namespace Escritorio.PageObjects
{
    public class ChekoutPO
    {
        Utilitarios util;
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
            util = new Utilitarios(driver);
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            util.OnClick(byBotaoPagar, 5);
            util.OnClick(byBotaoCartao, 5);
            util.SendKey(byInputNumeroCartao, numero, 10);
            util.SendKey(byInputNomeCartao, "Teste", 10);

            var mesCartao = new SelectElement(driver.FindElement(bySelectMes));
            mesCartao.SelectByValue(mes);

            var anoCartao = new SelectElement(driver.FindElement(bySelectAno));
            anoCartao.SelectByValue(ano);

            driver.FindElement(byInputCodigo).SendKeys(codigo);

            util.OnClick(byBotaoContinuar1, 5);
            util.OnClick(byBotaoContinuar2, 5);

            util.OnClick(byBotaoConfirmar, 5);

        }
    }
}
