using System;
using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.AccountReport;
using ApospReport.Domain.Extensions;
using ApospReport.Domain.Models;

namespace ApospReport.Application.SaveAccountReport
{
    internal interface ISaveAccountReportCommandInputMapper
    {
        Account MapInput(AccountReportDto dto);
    }

    internal class SaveAccountReportCommandInputMapper : ISaveAccountReportCommandInputMapper
    {
        public Account MapInput(AccountReportDto dto)
        {
            return new()
            {
                Username = dto.Username,
                Base64EncodedScreenshot = dto.Base64EncodedScreenshot,
                BankViewTimestamp = dto.BankViewTimestamp,
                UpdatedAt = DateTime.UtcNow.TruncateMillis(),

                InventoryItems = MapItems<InventoryItem>(dto.InventoryItems),
                BankItems = MapItems<BankItem>(dto.BankItems),

                Attack = MapSkillLevel(dto.Skill.Attack),
                Defense = MapSkillLevel(dto.Skill.Defense),
                Strength = MapSkillLevel(dto.Skill.Strength),
                Hits = MapSkillLevel(dto.Skill.Hits),
                Ranged = MapSkillLevel(dto.Skill.Ranged),
                Prayer = MapSkillLevel(dto.Skill.Prayer),
                Magic = MapSkillLevel(dto.Skill.Magic),
                Cooking = MapSkillLevel(dto.Skill.Cooking),
                Woodcut = MapSkillLevel(dto.Skill.Woodcut),
                Fletching = MapSkillLevel(dto.Skill.Fletching),
                Fishing = MapSkillLevel(dto.Skill.Fishing),
                Firemaking = MapSkillLevel(dto.Skill.Firemaking),
                Smithing = MapSkillLevel(dto.Skill.Smithing),
                Mining = MapSkillLevel(dto.Skill.Mining),
                Herblaw = MapSkillLevel(dto.Skill.Herblaw),
                Agility = MapSkillLevel(dto.Skill.Agility),
                Thieving = MapSkillLevel(dto.Skill.Thieving)
            };
        }

        private static IList<TAccountItem> MapItems<TAccountItem>(IList<AccountReportItemDto> items)
            where TAccountItem : AccountItem, new()
        {
            return (items == null ? Enumerable.Empty<TAccountItem>() : items.Select(MapItem<TAccountItem>)).ToList();
        }

        private static TAccountItem MapItem<TAccountItem>(AccountReportItemDto accountReportItem)
            where TAccountItem : AccountItem, new()
        {
            return new()
            {
                ItemDefinitionId = accountReportItem.Id,
                Position = accountReportItem.Position,
                Count = accountReportItem.Count
            };
        }

        private static Skill MapSkillLevel(AccountReportSkillLevelDto accountReportSkillLevel)
        {
            return new()
            {
                BaseLevel = accountReportSkillLevel.Base,
                CurrentLevel = accountReportSkillLevel.Current
            };
        }
    }
}