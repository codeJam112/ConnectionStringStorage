using Newtonsoft.Json;

namespace Api.ErrorHandling.Models
{
    public class ErrorDetail : IErrorDetail
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }
    }
}