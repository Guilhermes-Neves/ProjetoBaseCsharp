using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Common;
using Common.PageObject.Common;

namespace Common
{
    public class CheckoutPO : BasePage
    {
        Utilitarios util;
        
        public string PedidoFinalizado => driver.FindElement(OFFICE_CHECKOUT_PAGE.byPedidoFinalizado).Text;

        public CheckoutPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            util.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoPagar, 5);
            util.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoCartao, 5);
            util.SendKey(OFFICE_CHECKOUT_PAGE.byInputNumeroCartao, numero, 10);
            util.SendKey(OFFICE_CHECKOUT_PAGE.byInputNomeCartao, "Teste", 10);

            var mesCartao = new SelectElement(driver.FindElement(OFFICE_CHECKOUT_PAGE.bySelectMes));
            mesCartao.SelectByValue(mes);

            var anoCartao = new SelectElement(driver.FindElement(OFFICE_CHECKOUT_PAGE.bySelectAno));
            anoCartao.SelectByValue(ano);

            driver.FindElement(OFFICE_CHECKOUT_PAGE.byInputCodigo).SendKeys(codigo);

            util.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoContinuar1, 5);
            util.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoContinuar2, 5);

            util.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoConfirmar, 5);

        }
    }
}
