using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.AccountReport;
using ApospReport.Domain.Models;

namespace ApospReport.Application.GetAccountReport
{
    internal interface IGetAccountReportQueryResultMapper
    {
        IList<AccountReportDto> MapResult(IList<Account> account);
    }

    internal class GetAccountReportQueryResultMapper : IGetAccountReportQueryResultMapper
    {
        public IList<AccountReportDto> MapResult(IList<Account> account)
        {
            return account.Select(Map).ToList();
        }

        private static AccountReportDto Map(Account account)
        {
            return new()
            {
                Username = account.Username,
                BankViewTimestamp = account.BankViewTimestamp,

                BankItems = account.BankItems.Select(MapItem).ToList(),
                InventoryItems = account.InventoryItems.Select(MapItem).ToList(),

                Skill = new AccountReportSkillDto
                {
                    Agility = MapSkill(account.Agility),
                    Attack = MapSkill(account.Attack),
                    Fletching = MapSkill(account.Fletching),
                    Cooking = MapSkill(account.Cooking),
                    Crafting = MapSkill(account.Crafting),
                    Defense = MapSkill(account.Defense),
                    Firemaking = MapSkill(account.Firemaking),
                    Fishing = MapSkill(account.Firemaking),
                    Herblaw = MapSkill(account.Herblaw),
                    Hits = MapSkill(account.Hits),
                    Magic = MapSkill(account.Magic),
                    Mining = MapSkill(account.Mining),
                    Prayer = MapSkill(account.Prayer),
                    Ranged = MapSkill(account.Ranged),
                    Smithing = MapSkill(account.Smithing),
                    Strength = MapSkill(account.Strength),
                    Thieving = MapSkill(account.Thieving),
                    Woodcut = MapSkill(account.Woodcut)
                }
            };
        }

        private static AccountReportItemDto MapItem(AccountItem accountItem)
        {
            return new()
            {
                Position = accountItem.Position,
                Count = accountItem.Count,
                Id = accountItem.ItemDefinition.Id,
                IsStackable = accountItem.ItemDefinition.IsStackable,
                Name = accountItem.ItemDefinition.Name
            };
        }

        private static AccountReportSkillLevelDto MapSkill(Skill skill)
        {
            return new()
            {
                Base = skill.BaseLevel,
                Current = skill.CurrentLevel
            };
        }
    }
}
