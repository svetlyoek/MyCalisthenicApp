namespace MyCalisthenicApp.Web.Infrastructure.ReCAPTCHA
{
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

    public interface ICaptchaValidator
    {
        Task<bool> IsCaptchaPassedAsync(string token);

        Task<JObject> GetCaptchaResultDataAsync(string token);
    }
}
