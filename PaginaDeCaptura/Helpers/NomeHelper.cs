using RestSharp;

namespace PaginaDeCaptura.Helpers
{
    public static class NomeHelper
    {
        public static string GetNome()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            request.AddHeader("x-requested-with", "XMLHttpRequest");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";
            request.AddHeader("content-type", "application/json");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddParameter("application/x-www-form-urlencoded", "gerar_pessoa&sexo=I&pontuacao=S&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string teste = response.Content;
        }
    }
}
