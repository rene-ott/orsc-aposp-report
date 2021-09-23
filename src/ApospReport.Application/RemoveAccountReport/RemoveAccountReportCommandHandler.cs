using System.Threading;
using System.Threading.Tasks;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.RemoveAccountReport
{
    internal class RemoveAccountReportCommandHandler : IRequestHandler<RemoveAccountReportCommand>
    {
        private readonly IGenericRepository genericRepository;

        public RemoveAccountReportCommandHandler(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(RemoveAccountReportCommand command, CancellationToken cancellationToken)
        {
            var existingAccount = await genericRepository.GetAccount(command.Username);
            genericRepository.Remove(existingAccount);
            await genericRepository.Save();

            return Unit.Value;
        }
    }
}
