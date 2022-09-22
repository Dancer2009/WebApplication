using Newtonsoft.Json;
using System.Text;

namespace WebApplication1
{
    public class SendMessage
    {
        public void ReturnResponse(string identificador)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Key bGlhYXNzaXN0ZW50ZWNzZTpYR1RSYTduejNOOUgxOVVCejc4Rg==");
            var objeto = new
            {
                id = "0001",
                to = identificador,
                type = "application/json",
                content = new
                {
                    type = "template",
                    template = new
                    {
                        name = "validar_mfa",
                        language = new
                        {
                            code = "pt_BR",
                            policy = "deterministic"
                        }
                    }
                }
            };
            var content = ToRequest(objeto);
            var response = httpClient.PostAsync(requestUri: "https://energisatap.http.msging.net/messages", content);
           
        }
        private static StringContent ToRequest(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, mediaType: "application/json");
            return data;
        }
    }
}
