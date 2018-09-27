using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.ErrorHandling.Models
{
    public class Error : IError
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("displayMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayMessage { get; set; }

        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

        [JsonProperty("innerError", NullValueHandling = NullValueHandling.Ignore)]
        public IError InnerError { get; set; }

        [JsonProperty("errorDetail", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<IErrorDetail> ErrorDetails { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

    }
}
