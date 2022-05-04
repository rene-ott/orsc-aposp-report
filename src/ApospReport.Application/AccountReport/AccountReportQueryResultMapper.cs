﻿using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.AccountReport;
using ApospReport.Domain.Models;

namespace ApospReport.Application.AccountReport
{
    internal interface IAccountReportQueryResultMapper
    {
        IList<AccountReportDto> MapResult(IList<Account> account);
    }

    internal class AccountReportQueryResultMapper : IAccountReportQueryResultMapper
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
                Base64EncodedScreenshot = account.Base64EncodedScreenshot,
                BankViewTimestamp = account.BankViewTimestamp,
                ReportTimestamp = account.UpdatedAt,

                BankItems = account.BankItems.Select(MapItem).OrderBy(x => x.Position).ToList(),
                InventoryItems = account.InventoryItems.Select(MapItem).OrderBy(x => x.Position).ToList(),

                Skill = new AccountReportSkillDto
                {
                    Agility = MapSkill(account.Agility),
                    Attack = MapSkill(account.Attack),
                    Fletching = MapSkill(account.Fletching),
                    Cooking = MapSkill(account.Cooking),
                    Crafting = MapSkill(account.Crafting),
                    Defense = MapSkill(account.Defense),
                    Firemaking = MapSkill(account.Firemaking),
                    Fishing = MapSkill(account.Fishing),
                    Herblaw = MapSkill(account.Herblaw),
                    Hits = MapSkill(account.Hits),
                    Magic = MapSkill(account.Magic),
                    Mining = MapSkill(account.Mining),
                    Prayer = MapSkill(account.Prayer),
                    Ranged = MapSkill(account.Ranged),
                    Smithing = MapSkill(account.Smithing),
                    Strength = MapSkill(account.Strength),
                    Thieving = MapSkill(account.Thieving),
                    Woodcut = MapSkill(account.Woodcut),
                    TotalLevel = account.GetTotalLevel()
                }
            };
        }

        private static AccountReportItemDto MapItem(AccountItem accountItem)
        {
            return new()
            {
                Position = accountItem.Position,

                // This should be actually fixed on the bot side
                Count = accountItem is InventoryItem inventoryItem && !inventoryItem.ItemDefinition.IsStackable
                    ? 1
                    : accountItem.Count,

                Id = accountItem.ItemDefinition.Id,
                IsStackable = accountItem.ItemDefinition.IsStackable,
                Name = accountItem.ItemDefinition.Name
            };
        }

        private static AccountReportSkillLevelDto MapSkill(Skill skill)
        {
            return new()
            {
                Level = skill.Level,
                CurrentLevel = skill.CurrentLevel,
                Xp = skill.Xp,
                NextLevelCompletionPercentage = skill.NextLevelCompletionPercentage,
                XpUntilNextLevel = skill.XpUntilNextLevel,
                NextLevelXp = skill.NextLevelXp
            };
        }
    }
}
