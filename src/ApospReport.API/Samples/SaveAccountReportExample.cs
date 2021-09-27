using System;
using System.Collections.Generic;
using ApospReport.Contract.AccountReport;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API.Samples
{
    public class SaveAccountReportExample : IExamplesProvider<AccountReportDto>
    {
        public AccountReportDto GetExamples()
        {
            return new()
            {
                Username = "TestUser",
                Skill = new AccountReportSkillDto
                {
                    Attack = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Defense = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Strength = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Prayer = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Ranged = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Agility = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Herblaw = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Cooking = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Crafting = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Firemaking = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Fishing = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Magic = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Mining = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Fletching = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Smithing = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Hits = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Thieving = new AccountReportSkillLevelDto { Base = 1, Current = 1 },
                    Woodcut = new AccountReportSkillLevelDto { Base = 1, Current = 1 }
                },

                BankItems = new List<AccountReportItemDto>
                {
                    // Mace
                    new()
                    {
                        Id = 0,
                        Count = 10
                    }
                },
                InventoryItems = new List<AccountReportItemDto>
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
