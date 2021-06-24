using Commons.PageObject.Common;
using Commons.Core;

namespace Commons
{
    public class PedidosEcritorioPO : BasePage
    {
        public PedidosEcritorioPO(WebDriver driver)
        {
            this.driver = driver;
            
        }

        public void Visitar()
        {
            driver.OnClick(MANEGER_ORDER_OFFICE_PAGE.byLinkPedidosEscritorio, 30);
        }

    }
}
