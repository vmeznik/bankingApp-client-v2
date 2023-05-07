using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.Shared
{

    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }

        public User(string name, string password, string email, string accountNumber, double balance)
        {
            Name = name;
            Password = password;
            Email = email;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return $"User{{ name='{Name}', password='{Password}', email='{Email}', account_number={AccountNumber}, balance={Balance} }}";
        }
    }

}
