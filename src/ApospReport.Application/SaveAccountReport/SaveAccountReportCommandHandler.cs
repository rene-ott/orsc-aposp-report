using System.Threading;
using System.Threading.Tasks;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.SaveAccountReport
{
    internal class SaveAccountReportCommandHandler : IRequestHandler<SaveAccountReportCommand>
    {
        private readonly IGenericRepository genericRepository;
        private readonly ISaveAccountReportCommandInputMapper inputMapper;

        public SaveAccountReportCommandHandler(IGenericRepository genericRepository,
            ISaveAccountReportCommandInputMapper inputMapper)
        {
            this.genericRepository = genericRepository;
            this.inputMapper = inputMapper;
        }

        public async Task<Unit> Handle(SaveAccountReportCommand request, CancellationToken cancellationToken)
        {
            var inputAccount = inputMapper.MapInput(request.AccountReport);
            var existingAccount = await genericRepository.GetAccountWithItems(inputAccount.Username);

            if (existingAccount != null)
            {
                existingAccount.UpdatedAt = inputAccount.UpdatedAt;
                existingAccount.UpdateBankItems(inputAccount.BankItems, inputAccount.BankViewTimestamp);
                existingAccount.UpdateInventoryItems(inputAccount.InventoryItems);
                existingAccount.UpdateSkills(inputAccount);
            }

            await genericRepository.UpsertAccount(existingAccount ?? inputAccount);
            await genericRepository.Save();

            return Unit.Value;
        }
    }
}
