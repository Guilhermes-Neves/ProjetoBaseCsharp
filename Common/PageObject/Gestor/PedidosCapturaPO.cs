using OpenQA.Selenium;
using Common.PageObject.Common;

namespace Common
{
    public class PedidosCapturaPO : BasePage
    {
        Utilitarios util;

        public PedidosCapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public void Visitar()
        {
            util.OnClick(MANEGER_ORDER_CATCH_PAGE.byLinkPedidosCaptura, 30);
        }

    }
}
