using System.Collections.Generic;
using ApospReport.Domain.Models;

namespace ApospReport.DataStore
{
    internal static class TestDataAccounts
    {
        public static Account TestFirstUser = new()
        {
            Username = "TestUser1",
            BankItems = CreateItems<BankItem>(198),
            InventoryItems = CreateItems<InventoryItem>(30),
            Attack = CreateSkill(21, 11),
            Defense = CreateSkill(22, 12),
            Strength = CreateSkill(23, 13),
            Hits = CreateSkill(24, 14),
            Ranged = CreateSkill(25, 15),
            Prayer = CreateSkill(26, 16),
            Magic = CreateSkill(27, 17),
            Cooking = CreateSkill(28, 18),
            Woodcut = CreateSkill(29, 19),
            Fletching = CreateSkill(30, 20),
            Fishing = CreateSkill(31, 21),
            Firemaking = CreateSkill(32, 22),
            Crafting = CreateSkill(33, 23),
            Smithing = CreateSkill(34, 24),
            Mining = CreateSkill(35, 25),
            Herblaw = CreateSkill(36, 26),
            Agility = CreateSkill(37, 27),
            Thieving = CreateSkill(38, 28)
        };

        public static Account TestSecondUser = new()
        {
            Username = "TestUser2",
            BankItems = CreateItems<BankItem>(198, true),
            InventoryItems = CreateItems<InventoryItem>(30, true),
            Attack = CreateSkill(51, 31),
            Defense = CreateSkill(52, 32),
            Strength = CreateSkill(53, 33),
            Hits = CreateSkill(54, 34),
            Ranged = CreateSkill(55, 35),
            Prayer = CreateSkill(56, 36),
            Magic = CreateSkill(57, 37),
            Cooking = CreateSkill(58, 38),
            Woodcut = CreateSkill(59, 39),
            Fletching = CreateSkill(60, 40),
            Fishing = CreateSkill(61, 41),
            Firemaking = CreateSkill(62, 42),
            Crafting = CreateSkill(63, 43),
            Smithing = CreateSkill(64, 44),
            Mining = CreateSkill(65, 45),
            Herblaw = CreateSkill(66, 46),
            Agility = CreateSkill(67, 47),
            Thieving = CreateSkill(68, 48)
        };

        private static Skill CreateSkill(int baseL, int current)
        {
            return new()
            {
                BaseLevel = baseL,
                CurrentLevel = current
            };
        }

        private static IList<TAccountItem> CreateItems<TAccountItem>(int max, bool skipOne = false) where TAccountItem : AccountItem, new()
        {
            var list = new List<TAccountItem>();
            int pos;
            int id;
            for (pos = 0, id = 0; pos < max;)
            {
                list.Add(new TAccountItem
                {
                    Count = id + 1,
                    ItemDefinitionId = id,
                    Position = pos
                });

                id = 1 + id;
                pos = (skipOne ? 2 : 1) + pos;
            }

            return list;
        }
    }
}
