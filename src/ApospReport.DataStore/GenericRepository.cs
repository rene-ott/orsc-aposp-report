using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApospReport.Domain.Contracts;
using ApospReport.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApospReport.DataStore
{
    internal class GenericRepository : IGenericRepository
    {
        private readonly ApospReportDbContext dbContext;

        public GenericRepository(ApospReportDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Account> GetAccount(string username)
        {
            return await dbContext.Accounts
                .Where(x => x.Username == username)
                .SingleOrDefaultAsync();
        }

        public async Task<Account> GetAccountWithItems(string username)
        {
            return await dbContext.Accounts
                .Where(x => x.Username == username)
                .Include(x => x.BankItems)
                .Include(x => x.InventoryItems)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<Account>> GetAccountsWithItems()
        {
            return await dbContext.Accounts
                .Include(x => x.BankItems)
                    .ThenInclude(x => x.ItemDefinition).AsSplitQuery()
                .Include(x => x.InventoryItems)
                    .ThenInclude(x => x.ItemDefinition)
                .OrderBy(x => x.Username)
                .ToListAsync();
        }

        public async Task<IList<ItemDefinition>> GetBankItemsWithAccounts()
        {
            return await dbContext.ItemDefinitions
                .Include(x => x.BankItems)
                    .ThenInclude(x => x.Account)
                .Where(x => x.BankItems.Any())
                .ToListAsync();
        }

        public async Task<IList<ItemDefinition>> GetAllItemsWithAcounts()
        {
            return await dbContext.ItemDefinitions
                .Include(x => x.BankItems)
                    .ThenInclude(x => x.Account)
                .Include(x => x.InventoryItems)
                    .ThenInclude(x => x.Account)
                .Where(x => x.BankItems.Any() || x.InventoryItems.Any())
                .ToListAsync();
        }

        public void Remove(Account account)
        {
            dbContext.Remove(account);
        }

        public async Task UpsertAccount(Account account)
        {
            if (account.Id == 0)
                await dbContext.Accounts.AddAsync(account);
            else
                dbContext.Accounts.Update(account);
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
