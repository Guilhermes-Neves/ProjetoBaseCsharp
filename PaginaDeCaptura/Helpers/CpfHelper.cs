using RestSharp;

namespace PaginaDeCaptura.Helpers
{
    public static class CpfHelper
    {
        public static string GetCpf(bool formatado = true)
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            request.AddHeader("x-requested-with", "XMLHttpRequest");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_cpf");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", "acao=gerar_cpf&pontuacao=S&cpf_estado=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string cpf = response.Content;
            if (formatado == false)
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
            }
            return cpf;
        }
    }
}