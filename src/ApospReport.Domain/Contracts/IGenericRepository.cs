using System.Collections.Generic;
using System.Threading.Tasks;
using ApospReport.Domain.Models;

namespace ApospReport.Domain.Contracts
{
    public interface IGenericRepository
    {
        Task<Account> GetAccount(string username);
        Task UpsertAccount(Account account);
        Task<IList<ItemDefinition>> GetItemDefinitions();
        Task Save();
    }
}
