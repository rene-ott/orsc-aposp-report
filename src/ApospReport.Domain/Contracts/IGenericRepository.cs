using System.Collections.Generic;
using System.Threading.Tasks;
using ApospReport.Domain.Models;

namespace ApospReport.Domain.Contracts
{
    public interface IGenericRepository
    {
        Task<Account> GetAccount(string username);
        Task<IList<Account>> GetAccountsWithItems();
        Task<Account> GetAccountWithItems(string username);
        Task UpsertAccount(Account account);
        void Remove(Account account);
        Task<IList<ItemDefinition>> GetBankItemsWithAccounts();
        Task Save();
    }
}
