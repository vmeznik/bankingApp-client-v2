using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.Shared
{
    public class Transaction
    {
        [JsonPropertyName("id")]
        private int id { get; set; }
        [JsonPropertyName("senderAccNumber")]
        public string senderAccNumber { get; set; }
        [JsonPropertyName("receiverAccNumber")]
        public string receiverAccNumber { get; set; }
        [JsonPropertyName("amount")]
        public double amount { get; set; }
        [JsonPropertyName("date")]
        public string date { get; set; }

        public Transaction(string senderAccNumber, string receiverAccNumber, double amount,string date)
        {
            this.id = -1;
            this.senderAccNumber = senderAccNumber;
            this.receiverAccNumber = receiverAccNumber;
            this.amount = amount;
            this.date = date;
        }

        public Transaction()
        {
        }

        
    public override string ToString()
        {
            return "Transaction{" +
                    "senderAccNumber=" + senderAccNumber +
                    ", receiverAccNumber=" + receiverAccNumber +
                    ", amount=" + amount +
                    '}';
        }
    }
}
