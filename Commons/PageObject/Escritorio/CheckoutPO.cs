using OpenQA.Selenium.Support.UI;
using Commons.PageObject.Common;
using Commons.Core;

namespace Commons
{
    public class CheckoutPO : BasePage
    {
        public CheckoutPO(WebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidarPedidoFinalizado(string mensagem)
        {
            string mensagemDesejada = driver.GetText(OFFICE_CHECKOUT_PAGE.byPedidoFinalizado, 30);

            if (mensagemDesejada == mensagem)
            {
                return true;
            }

            return false;
        }

        public void FinalizarCheckoutCartao(string numero, string mes, string ano, string codigo)
        {
            driver.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoCartao, 30);
            driver.SendKey(OFFICE_CHECKOUT_PAGE.byInputNumeroCartao, numero, 10);
            driver.SendKey(OFFICE_CHECKOUT_PAGE.byInputNomeCartao, "Teste", 10);

            var mesCartao = new SelectElement(driver.FindElement(OFFICE_CHECKOUT_PAGE.bySelectMes));
            mesCartao.SelectByValue(mes);

            var anoCartao = new SelectElement(driver.FindElement(OFFICE_CHECKOUT_PAGE.bySelectAno));
            anoCartao.SelectByValue(ano);

            driver.FindElement(OFFICE_CHECKOUT_PAGE.byInputCodigo).SendKeys(codigo);

            driver.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoContinuar, 15);
            driver.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoContinuar, 15);

            driver.OnClick(OFFICE_CHECKOUT_PAGE.byBotaoConfirmar, 5);

        }
    }
}
