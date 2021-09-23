using System;
using System.Collections.Generic;
using ApospReport.Contract;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API.Samples
{
    public class SaveAccountReportExample : IExamplesProvider<AccountDto>
    {
        public AccountDto GetExamples()
        {
            return new()
            {
                Username = "TestUser",
                Attack = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Defense = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Strength = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Prayer = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Ranged = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Agility = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Herblaw = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Cooking = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Crafting = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Firemaking = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Fishing = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Magic = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Mining = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Fletching = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Smithing = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Hits = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Thieving = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                Woodcut = new SkillDto { BaseLevel = 1, CurrentLevel = 1 },
                BankItems = new List<ItemDto>
                {
                    // Mace
                    new()
                    {
                        Id = 0,
                        Count = 10
                    }
                },
                InventoryItems = new List<ItemDto>
                {
                    // Coins
                    new()
                    {
                        Id = 10,
                        Count = 1000
                    }
                },
                BankViewTimestamp = new DateTime(2021, 10, 1),
            };
        }
    }
}
