using OpenQA.Selenium;
using Common.PageObject.Common;

namespace Common
{
    public class PedidosEcritorioPO : BasePage
    {
        Utilitarios util;

        public PedidosEcritorioPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            
        }

        public void Visitar()
        {
            util.OnClick(MANEGER_ORDER_OFFICE_PAGE.byLinkPedidosEscritorio, 30);
        }

    }
}
