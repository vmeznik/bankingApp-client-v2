using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Shared
{
    interface IUserService
    {
        Task<RequestConfirmation> Login(User user);

        Task<RequestConfirmation> Register(User user);

        Task<User> getUserInfo();

        Task<List<Transaction>> getTransactions();

        Task<RequestConfirmation> sendMoney(Transaction transaction);



    }
}
