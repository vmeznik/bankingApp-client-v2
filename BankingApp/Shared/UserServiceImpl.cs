using System.Text.Json;
using System.Text;
using System.Runtime.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BankingApp.Shared
{
    public class UserServiceImpl : IUserService
    {
        private User userLoginInfo;
        public async Task<RequestConfirmation> Login(User user)
        {
            userLoginInfo = user;
            var client = new HttpClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/bankingApp/login", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                string jsonObj = await response.Content.ReadAsStringAsync();
                RequestConfirmation requestConfirmation = JsonSerializer.Deserialize<RequestConfirmation>(jsonObj);
                return requestConfirmation;
            }
            else
            {
                var requestConfirmation = new RequestConfirmation(false, "We are sorry server is off ");
                return requestConfirmation;
            }
        }

        public async Task<RequestConfirmation> Register(User user)
        {
            var client = new HttpClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/bankingApp/register", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                string jsonObj = await response.Content.ReadAsStringAsync();
                RequestConfirmation requestConfirmation = JsonSerializer.Deserialize<RequestConfirmation>(jsonObj);
                return requestConfirmation;
            }
            else
            {
                var requestConfirmation = new RequestConfirmation(false, "We are sorry server is off ");
                return requestConfirmation;
            }
        }

        public async Task<User> getUserInfo()
        {
            var client = new HttpClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(userLoginInfo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/bankingApp/accountInfo", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                string jsonObj = await response.Content.ReadAsStringAsync();
                User userInfo = JsonSerializer.Deserialize<User>(jsonObj);
                userLoginInfo.AccountNumber = userInfo.AccountNumber;
                return userInfo;
            }
            return new User(null, null, null, null, 0);
        }


        public async Task<List<Transaction>> getTransactions()
        {
            var client = new HttpClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(userLoginInfo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/bankingApp/getTransactions", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                string jsonObj = await response.Content.ReadAsStringAsync();
                List<Transaction> transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonObj);
                return transactions;
            }

            List<Transaction> transactions1 = new List<Transaction>();
            return transactions1;
        }

        public async Task<RequestConfirmation> sendMoney(Transaction transaction)
        {
            transaction.senderAccNumber = userLoginInfo.AccountNumber;
            var client = new HttpClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/bankingApp/sendMoney", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                string jsonObj = await response.Content.ReadAsStringAsync();
                RequestConfirmation requestConfirmation = JsonSerializer.Deserialize<RequestConfirmation>(jsonObj);
                return requestConfirmation;
            }
            else
            {
                var requestConfirmation = new RequestConfirmation(false, "We are sorry server is off ");
                return requestConfirmation;
            }
        }
    }
}
    

        

    

