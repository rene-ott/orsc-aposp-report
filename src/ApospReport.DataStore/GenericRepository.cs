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

        public async Task UpsertAccount(Account account)
        {
            if (account.Id == 0)
                await dbContext.Accounts.AddAsync(account);
            else
                dbContext.Accounts.Update(account);
        }

        public async Task<IList<ItemDefinition>> GetItemDefinitions()
        {
            return await dbContext.ItemDefinitions.ToListAsync();
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
