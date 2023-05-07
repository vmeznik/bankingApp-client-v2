using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.Shared
{
    public class RequestConfirmation
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        public RequestConfirmation(bool success, String error)
        {
            this.Success = success;
            this.Error = error;
        }

        public RequestConfirmation()
        {
        }

    }
}
