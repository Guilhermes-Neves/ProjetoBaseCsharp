using Commons.PageObject.Common;
using Commons.Core;

namespace Commons
{
    public class LoginPO : BasePage
    {
        public LoginPO(WebDriver driver)
        {
            this.driver = driver;
        }

       public void Visitar()
        {
            driver.NavigateTo(URL_BASE);
        }

       //Implementar métodos de login


    }
}
