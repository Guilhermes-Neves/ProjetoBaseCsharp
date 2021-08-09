using Commons.Core;

namespace Commons.PageObject.Common
{
    public class BasePage : Dictionary
    {
        public WebDriver driver;

        public double DEFAULT_TIMEOUT = 60;
                
        //Implementar métodos comuns a diferentes páginas
    }
}
