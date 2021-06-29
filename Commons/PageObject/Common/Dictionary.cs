using OpenQA.Selenium;

namespace Commons.PageObject.Common
{
    public class Dictionary
    {

        public const string URL_BASE_ESCRITORIO = "http://localhost:8080/#/";
        public const string URL_BASE_GESTOR = "http://localhost:8081/#/";
        public const string URL_BASE_CAPTURA = "https://hlg-revenda.styllus.online/#/";

        public static class OFFICE_HOME_PAGE
        {
            public static readonly By byDangerMessage = By.CssSelector("p.vn-message");
            public static readonly By byLimiteCredito = By.CssSelector("div:nth-child(1) div.col > span");
            public static readonly By byExtratoLimiteCredito = By.XPath("//b");
        }

        public static class BASE_PAGE
        {
            //gestor
            public static readonly By byBotaoFiltro = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/button");
            public static readonly By byInputNome = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[1]/div/div/div[1]/div/input");
            public static readonly By byInputCodStyllus = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[2]/div/div/div[1]/div/input");
            public static readonly By bySelectStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[3]/div/div/div[1]/div[1]/div[1]");
            public static readonly By byInputValorMin = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[4]/div/div/div[1]/div/input");
            public static readonly By byInputValorMax = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[5]/div/div/div[1]/div/input");
            public static readonly By bySelectFormaPagamento = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[6]/div/div/div[1]/div[1]/div[1]");
            public static readonly By byInputDataInicio = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[7]/div[1]/div[2]/div[1]/div/input");
            public static readonly By byInputDataFim = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[8]/div[1]/div[2]/div[1]/div/input");
            public static readonly By bySelectStatusPagamento = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[9]/div/div/div[1]/div[1]/div[1]");
            public static readonly By byBotaoBuscarPedido = By.CssSelector("button.primary");
            public static readonly By byTdNome = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
            public static readonly By byTdCod = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]");
            public static readonly By byOptionNovo = By.XPath("/html/body/div/div[2]/div/div[2]/div/div");
            public static readonly By byOptionNaoEntregue = By.XPath("/html/body/div/div[2]/div/div[6]/div/div");
            public static readonly By byTdStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]");
            public static readonly By byTdValor = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]");
            public static readonly By byOptionPrazo = By.XPath("/html/body/div/div[2]/div/div[1]/div/div");
            public static readonly By byTdFormPag = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]");
            public static readonly By byDiaSeisInicio = By.XPath("/html/body/div/div[2]/div/div/div/div[2]/table/tbody/tr[1]/td[7]/button/div");
            public static readonly By byDiaOnzeInicio = By.XPath("/html/body/div[1]/div[2]/div/div/div/div[2]/table/tbody/tr[2]/td[5]/button/div");
            public static readonly By byDiaSeisFim = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/table/tbody/tr[1]/td[7]/button/div");
            public static readonly By byDiaOnzeFim = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/table/tbody/tr[2]/td[5]/button/div");
            public static readonly By byTdData = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[6]");
            public static readonly By byOptionEstornado = By.XPath("/html/body/div[1]/div[2]/div/div[2]/div/div");
            public static readonly By byOptionRecusado = By.XPath("/html/body/div/div[2]/div/div[3]/div/div");
            public static readonly By byTdStatusPgto = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr/td[9]");
            public static readonly By byBotaoAlterarEstado = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[10]/button/span");
            public static readonly By bySelectEstado = By.XPath("/html/body/div[1]/div[4]/div/div/div[2]/div[1]/div/div[1]/div[1]");
            public static readonly By byOptionEstadoCancelado = By.XPath("/html/body/div/div[5]/div/div[1]/div/div");
            public static readonly By byBotaoSalvar = By.CssSelector("button.blue--text");
            public static readonly By byBotaoAlterarDesabilitado = By.CssSelector("button[disabled='disabled']");
            public static readonly By byOptionCancelado = By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div");
            public static readonly By byLoadProducts = By.XPath("//span[contains(@class, 'sr-only')]");
            public static readonly By byLoadPage = By.XPath("//div[contains(@class, 'loader')]");
        }

        public static class OFFICE_LOGIN_PAGE
        {
            public static readonly By byInputLogin = By.Id("input-email");
            public static readonly By byInputPassword = By.Id("input-password");
            public static readonly By byBotaoLogin = By.ClassName("btn-primary");
        }

        public static class OFFICE_CART_PAGE
        {
            public static readonly By byTable = By.CssSelector("table tbody tr");
            public static readonly By byAlertaTotalPedido = By.CssSelector(".alert-danger");
            public static readonly By byAlertaSemEstoque = By.CssSelector(".alert-danger");
            public static readonly By byAlertaLimiteCredito = By.CssSelector(".alert-primary");
            public static readonly By byInputQuantidade = By.XPath("//input[contains(@type, 'number')]");
            public static readonly By bySubtotal = By.XPath("//li[contains(text(),'SubTotal:')]");
            public static readonly By byDesconto = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[2]/strong");
            public static readonly By byTotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]/strong");
            public static readonly By byOptionPagamentoPrazo = By.XPath("//*[@id='fr_pgto']/option[2]");
            public static readonly By bySelectPagamento = By.Id("fr_pgto");
            public static readonly By byCheckEntregaNormal = By.XPath("//p[text()[contains(.,'Entrega Normal')]]");
            public static readonly By byCheckEntregaRapida = By.XPath("//p[text()[contains(.,'Entrega Rápida')]]");
            public static readonly By byBotaoFinalizarPedido = By.Id("place_order");
            public static readonly By byTdDesconto = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[3]/table/tbody/tr/td[5]");
            public static readonly By byAlertaEstoque = By.CssSelector("p.alert.alert-danger");
            public static readonly By byInputCashback = By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/div/div[2]/div[1]/div/div/div/div/input");
            public static readonly By byBotaoAplicarCashback = By.CssSelector("button.btn.mt-2.btn-info.btn-block");
            public static readonly By byDivProdutos = By.CssSelector("div.card");
        }

        public static class OFFICE_CHECKOUT_PAGE
        {
            public static readonly  By byBotaoCartao = By.XPath("//*[@id='checkoutModal']/div/div/div[2]/div/form/button[2]");
            public static readonly  By byInputNumeroCartao = By.Id("cardNumber");
            public static readonly  By byInputNomeCartao = By.Id("cardName");
            public static readonly  By bySelectMes = By.Id("cardMonth");
            public static readonly  By bySelectAno = By.Id("cardYear");
            public static readonly  By byInputCodigo = By.Id("cardCvv");
            public static readonly  By byBotaoContinuar = By.XPath("//button[text()[contains(.,'Continuar')]]");
            public static readonly  By byBotaoConfirmar = By.XPath("//*[@id='checkoutModal']/div/div/div[2]/div/div/button[1]");
            public static readonly  By byPedidoFinalizado = By.Id("swal2-content");
            public static readonly  By byBotaoPagar = By.CssSelector("button.btn-success");
        }

        public static class OFFICE_PRODUCT_PAGE
        {
            public static readonly By byInputRef = By.Id("search_ref");
            public static readonly By byBotaoBuscar = By.XPath("//button[text()= ' Buscar ']");
            public static readonly By byInputQuantidade = By.CssSelector("input[type='number']");
            public static readonly By byBotaoAdicionar = By.CssSelector("div.card-footer div:nth-child(2) span");
            public static readonly By bySelectTamanho = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div[3]/div[1]/select");
            public static readonly By bySelectCor = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div[3]/div[2]/select");
            public static readonly By bySpanEstoque = By.CssSelector("span.badge-danger");
            public static readonly By byBotaoAdicionarModal = By.CssSelector("#add-to-cart-modal > div.card-footer > div > div:nth-child(2) > button");
            public static readonly By byBotaoLimpar = By.XPath("//button[text()=' Limpar ']");
            public static readonly By byQuantidadePaginas = By.XPath("//p[text()=' Você está na página 1 de 1 ']");
        }

        public static class MANEGER_HOME_PAGE
        {
            public static readonly By byLoginMessage = By.CssSelector("p.toast-text");
        }

        public static class MANEGER_LOGIN_PAGE
        {
            public static readonly By byInputLogin = By.CssSelector("input[name='email']");
            public static readonly By byInputPassword = By.XPath("//*[@id='app']/div/main/div/div[2]/div/div/form/div[2]/input");
            public static readonly By byBotaoLogin = By.ClassName("login100-form-btn");
        }

        public static class MANEGER_ORDER_CATCH_PAGE
        {
            public static readonly By byLinkPedidosCaptura = By.XPath("/html/body/div/div/nav/div[2]/div[2]/a[3]/div[2]");
        }
        
        public static class MANEGER_ORDER_OFFICE_PAGE
        {
            public static readonly By byLinkPedidosEscritorio = By.XPath("/html/body/div/div/nav/div[2]/div[2]/a[3]/div[2]");
        }

        public static class MANEGER_RESELLER_PAGE
        {
            public static readonly By byInputNome = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[2]/div/div/div/input");
            public static readonly By byInputCpf = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[3]/div/div/div/input");
            public static readonly By byInputCodStyllus = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[4]/div/div/div/input");
            public static readonly By byBotaoBuscar = By.CssSelector("button.v-btn.primary");
            public static readonly By byLinkRevendedoras = By.XPath("/html/body/div[1]/div/nav/div[2]/div[2]/a[2]");
            public static readonly By byEditarRevendedora = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr/td[10]/a");
            public static readonly By byTabCashBack = By.XPath("/html/body/div[1]/div/main/div/div[2]/div/div/div/div/div[1]/div[2]/div/div[6]");
            public static readonly By byBotaoAdicionarCashback = By.XPath("/html/body/div[1]/div/main/div/div[2]/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div[1]/div[1]/button");
            public static readonly By byInputValorCashback = By.CssSelector("input[name='valor']");
            public static readonly By byInputDataCashback = By.CssSelector("input[name='expiresAt']");
            public static readonly By byBotaoSalvar = By.CssSelector("button.success--text");
            public static readonly By byMensagemSucesso = By.CssSelector("p.toast-text");
            public static readonly By byInputAccount = By.ClassName("mdi-account");
            public static readonly By byBotaoDeletar = By.CssSelector("button.error--text");
            public static readonly By byBotaoProssiga = By.XPath("/html/body/div/div[3]/div/div/div[3]/button[2]");
            public static readonly By byTable = By.CssSelector("table tbody tr");
            public static readonly By byTdName = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[1]");
            public static readonly By byTdCpf = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[4]");
            public static readonly By byTdCod = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[7]");
            public static readonly By byTabCredit = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div/div/div/div/div[1]/div[2]/div/div[7]");
            public static readonly By byAddCredit = By.XPath("/html/body/div[1]/div/main/div/div[2]/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div/div[1]/button/span/i");
            public static readonly By byNovoLimite = By.CssSelector("input[name='novoLimite']");
            public static readonly By byBotaoSalvarLimite = By.CssSelector("button.blue--text");
        }

        public static class RESELLER_CATCH_PAGE
        {
            public static readonly By byInputCpf = By.Id("novacaptura__field--cpf");
            public static readonly By byInputNome = By.Id("novacaptura__field--nome");
            public static readonly By byInputData = By.Id("novacaptura__field--data-nascimento");
            public static readonly By byInputTelefone = By.Id("novacaptura__field--telefone");
            public static readonly By byInputEmail = By.Id("novacaptura__field--email");
            public static readonly By byInputIndicador = By.Id("novacaptura__field--codigo-indicador");
            public static readonly By byCheckTermos = By.CssSelector("i.primary--text");
            public static readonly By byBotaoAceitoTermos = By.Id("terms__button--aceitar");
            public static readonly By byBotaoContinuar = By.Id("novacaptura__span--continuar");
            public static readonly By byBotaoFinalizarCadastro = By.Id("carrinho__span--update");
            public static readonly By byTituloMensagem = By.XPath("//h1[contains(@class, 'title')]");
            public static readonly By byConteudoMensagem = By.XPath("//div//p");
        }
    }
}
