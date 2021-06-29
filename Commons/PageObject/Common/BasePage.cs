using Commons.Core;

namespace Commons.PageObject.Common
{
    public class BasePage : Dictionary
    {
        public WebDriver driver;

        public double DEFAULT_TIMEOUT = 60;
                
        public void AplicarFiltro(string value1, string value2, string field)
        {
            switch (field)
            {
                case "nome":
                    driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    driver.SendKey(BASE_PAGE.byInputNome, value1, 30);
                    //driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "codStyllus":
                    driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    driver.SendKey(BASE_PAGE.byInputCodStyllus, value1, 30);
                    //driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "status":
                    switch (value1)
                    {
                        case "NOVO":
                            driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            driver.OnClick(BASE_PAGE.bySelectStatus, 30);
                            driver.OnClick(BASE_PAGE.byOptionNovo, 30);
                            //driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "NÃO ENTREGUE":
                            driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            driver.OnClick(BASE_PAGE.bySelectStatus, 30);
                            driver.OnClick(BASE_PAGE.byOptionNaoEntregue, 30);
                            //driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "CANCELADO":
                            driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            driver.OnClick(BASE_PAGE.bySelectStatus, 30);
                            driver.OnClick(BASE_PAGE.byOptionCancelado, 30);
                            //driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        default:
                            break;
                    }

                    break;

                case "valorMin":
                    driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    driver.SendKey(BASE_PAGE.byInputValorMin, value2, 30);
                    driver.SendKey(BASE_PAGE.byInputValorMax, value1, 30);
                   // driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "formaPag":
                    driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    driver.OnClick(BASE_PAGE.bySelectFormaPagamento, 30);
                    driver.OnClick(BASE_PAGE.byOptionPrazo, 30);
                   // driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "data":
                    driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    driver.OnClick(BASE_PAGE.byInputDataInicio, 30);
                    driver.OnClick(BASE_PAGE.byDiaOnzeInicio, 30);
                    driver.OnClick(BASE_PAGE.byInputDataFim, 30);
                    driver.OnClick(BASE_PAGE.byDiaOnzeFim, 30);
                  //  driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "statusPag":
                    switch (value1)
                    {
                        case "Estornado":
                            driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            driver.OnClick(BASE_PAGE.bySelectStatusPagamento, 30);
                            driver.OnClick(BASE_PAGE.byOptionEstornado, 30);
                      //      driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "Recusado":
                            driver.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            driver.OnClick(BASE_PAGE.bySelectStatusPagamento, 30);
                            driver.OnClick(BASE_PAGE.byOptionRecusado, 30);
                       //     driver.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    break;
            }
        }

        public string EncontrarPedido(string field)
        {
            switch (field)
            {
                case "nome":
                    string nome = driver.GetText(BASE_PAGE.byTdNome, 30);
                    return nome;

                case "codStyllus":
                    string cod = driver.GetText(BASE_PAGE.byTdCod, 30);
                    return cod;

                case "status":
                    string status = driver.GetText(BASE_PAGE.byTdStatus, 30);
                    return status;

                case "valorMin":
                    string valor = driver.GetText(BASE_PAGE.byTdValor, 30);
                    return valor;

                case "formaPag":
                    string formaPag = driver.GetText(BASE_PAGE.byTdFormPag, 30);
                    return formaPag;

                case "data":
                    string data = driver.GetText(BASE_PAGE.byTdData, 30);
                    return data;

                case "statusPag":
                    string statusPag = driver.GetText(BASE_PAGE.byTdStatusPgto, 30);
                    return statusPag;

                default:
                    return "não encontrou";
            }
        }

        public void AlterarEstadoPedido(string value)
        {
            switch (value)
            {
                case "CANCELADO":
                    driver.OnClick(BASE_PAGE.byBotaoAlterarEstado, 30);
                    driver.OnClick(BASE_PAGE.bySelectEstado, 30);
                    driver.OnClick(BASE_PAGE.byOptionEstadoCancelado, 30);
                    driver.OnClick(BASE_PAGE.byBotaoSalvar, 30);
                    break;

                default:
                    break;
            }

        }

        public void AguardarCarregamentoPagina()
        {
            driver.WaitUntilElementDesappear(BASE_PAGE.byLoadPage, 20);
        }
    }
}
