using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Application.Mappers;
using ApospReport.Contract;
using ApospReport.Domain.Contracts;
using ApospReport.Domain.Models;
using MediatR;

namespace ApospReport.Application.SaveReport
{
    internal class SaveReportCommandHandler : IRequestHandler<SaveReportCommand>
    {
        private readonly IGenericRepository genericRepository;
        private readonly ISkillMapper skillMapper;
        private readonly IAccountItemMapper accountItemMapper;

        public SaveReportCommandHandler(IGenericRepository genericRepository, IAccountItemMapper accountItemMapper, ISkillMapper skillMapper)
        {
            this.genericRepository = genericRepository;
            this.accountItemMapper = accountItemMapper;
            this.skillMapper = skillMapper;
        }

        public async Task<Unit> Handle(SaveReportCommand request, CancellationToken cancellationToken)
        {
            var report = request.Report;

            var account = await genericRepository.GetAccount(report.Username) ?? new Account { Username = report.Username };

            UpdateAccountBankItems(account, report.BankItems, report.BankViewTimestamp);
            UpdateAccountInventoryItems(account, report.InventoryItems);
            //UpdateAccountSkills(account, report.Skills);

            await genericRepository.UpsertAccount(account);
            await genericRepository.Save();

            return Unit.Value;
        }

        private void UpdateAccountBankItems(Account account, IList<ReportItemDto> reportBankItems, DateTime? bankViewTimestamp)
        {
            if (bankViewTimestamp == null)
                return;

            account.BankViewTimestamp = bankViewTimestamp;

            account.BankItems.Clear();
            var bankItems = accountItemMapper.MapFromReport<BankItem>(reportBankItems);
            foreach (var bankItem in bankItems)
                account.BankItems.Add(bankItem);
        }

        private void UpdateAccountInventoryItems(Account account, IList<ReportItemDto> reportInventoryItems)
        {
            account.InventoryItems.Clear();
            var inventoryItems = accountItemMapper.MapFromReport<InventoryItem>(reportInventoryItems);
            foreach (var inventoryItem in inventoryItems)
                account.InventoryItems.Add(inventoryItem);
        }

        private void UpdateAccountSkills(Account account, IList<ReportSkillDto> reportSkills)
        {
            var skills = skillMapper.MapFromReport(reportSkills);

            /*
            account.Attack = skills[0];
            account.Defense = skills[0];
            account.Strength = skills[0];
            account.Hits = skills[0];
            account.Ranged = skills[0];
            account.Prayer = skills[0];
            account.Magic = skills[0];
            account.Cooking = skills[0];
            account.Woodcut = skills[0];
            account.Fletching = skills[0];
            account.Fishing = skills[0];
            account.Firemaking = skills[0];
            account.Crafting = skills[0];
            account.Smithing = skills[0];
            account.Mining = skills[0];
            account.Herblaw = skills[0];
            account.Agility = skills[0];
            account.Thieving = skills[0];
            */
        }
    }
}
