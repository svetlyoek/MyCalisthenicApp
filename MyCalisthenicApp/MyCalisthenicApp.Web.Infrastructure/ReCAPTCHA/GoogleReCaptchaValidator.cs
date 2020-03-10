namespace MyCalisthenicApp.Web.Infrastructure.ReCAPTCHA
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json.Linq;

    public class GoogleReCaptchaValidator : ICaptchaValidator
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private const string RemoteAddress = "https://www.google.com/recaptcha/api/siteverify";

        public GoogleReCaptchaValidator(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<bool> IsCaptchaPassedAsync(string token)
        {
            dynamic response = await this.GetCaptchaResultDataAsync(token);
            return response.success == "true";
        }

        public async Task<JObject> GetCaptchaResultDataAsync(string token)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("secret", this.configuration["googleReCaptcha:SecretKey"]),
                new KeyValuePair<string, string>("response", token),
            });
            var result = await this.httpClient.PostAsync(RemoteAddress, content);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(result.ReasonPhrase);
            }

            var jsonResult = await result.Content.ReadAsStringAsync();
            return JObject.Parse(jsonResult);
        }
    }
}
