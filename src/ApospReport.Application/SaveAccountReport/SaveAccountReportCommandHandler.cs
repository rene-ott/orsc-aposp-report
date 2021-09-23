using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Application.Mappers;
using ApospReport.Contract;
using ApospReport.Domain.Contracts;
using ApospReport.Domain.Models;
using MediatR;

namespace ApospReport.Application.SaveAccountReport
{
    internal class SaveAccountReportCommandHandler : IRequestHandler<SaveAccountReportCommand>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IAccountItemMapper accountItemMapper;
        private readonly IAccountMapper accountMapper;

        public SaveAccountReportCommandHandler(IGenericRepository genericRepository, IAccountItemMapper accountItemMapper, IAccountMapper accountMapper)
        {
            this.genericRepository = genericRepository;
            this.accountItemMapper = accountItemMapper;
            this.accountMapper = accountMapper;
        }

        public async Task<Unit> Handle(SaveAccountReportCommand request, CancellationToken cancellationToken)
        {
            var report = request.Account;

            var existingAccount = await genericRepository.GetAccount(report.Username);
            var inputAccount = accountMapper.MapFromReport(request.Account);

            UpdateAccountSkills(existingAccount, inputAccount);

            existingAccount ??= inputAccount;

            UpdateAccountBankItems(existingAccount, report.BankItems, report.BankViewTimestamp);
            UpdateAccountInventoryItems(existingAccount, report.InventoryItems);

            await genericRepository.UpsertAccount(existingAccount);
            await genericRepository.Save();

            return Unit.Value;
        }

        private void UpdateAccountBankItems(Account account, IList<ItemDto> reportBankItems, DateTime? bankViewTimestamp)
        {
            if (bankViewTimestamp == null)
                return;

            account.BankViewTimestamp = bankViewTimestamp;

            account.BankItems.Clear();
            var bankItems = accountItemMapper.MapFromReport<BankItem>(reportBankItems);
            foreach (var bankItem in bankItems)
                account.BankItems.Add(bankItem);
        }

        private void UpdateAccountInventoryItems(Account account, IList<ItemDto> reportInventoryItems)
        {
            account.InventoryItems.Clear();
            var inventoryItems = accountItemMapper.MapFromReport<InventoryItem>(reportInventoryItems);
            foreach (var inventoryItem in inventoryItems)
                account.InventoryItems.Add(inventoryItem);
        }

        private static void UpdateAccountSkills(Account existingAccount, Account inputAccount)
        {
            if (existingAccount == null)
                return;

            static void MapSkill(Skill skill, Skill inputSkill)
            {
                skill.BaseLevel = inputSkill.BaseLevel;
                skill.CurrentLevel = inputSkill.CurrentLevel;
            }

            MapSkill(existingAccount.Attack, inputAccount.Attack);
            MapSkill(existingAccount.Defense, inputAccount.Defense);
            MapSkill(existingAccount.Strength, inputAccount.Strength);
            MapSkill(existingAccount.Hits, inputAccount.Hits);
            MapSkill(existingAccount.Ranged, inputAccount.Ranged);
            MapSkill(existingAccount.Prayer, inputAccount.Prayer);
            MapSkill(existingAccount.Magic, inputAccount.Magic);
            MapSkill(existingAccount.Cooking, inputAccount.Cooking);
            MapSkill(existingAccount.Woodcut, inputAccount.Woodcut);
            MapSkill(existingAccount.Fletching, inputAccount.Fletching);
            MapSkill(existingAccount.Fishing, inputAccount.Fishing);
            MapSkill(existingAccount.Firemaking, inputAccount.Firemaking);
            MapSkill(existingAccount.Smithing, inputAccount.Smithing);
            MapSkill(existingAccount.Mining, inputAccount.Mining);
            MapSkill(existingAccount.Herblaw, inputAccount.Herblaw);
            MapSkill(existingAccount.Agility, inputAccount.Agility);
            MapSkill(existingAccount.Thieving, inputAccount.Thieving);
        }
    }
}
