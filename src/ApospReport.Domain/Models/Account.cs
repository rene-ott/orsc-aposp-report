using System;
using System.Collections.Generic;

namespace ApospReport.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Base64EncodedScreenshot { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Skill Attack { get; set; } = new();
        public Skill Defense { get; set; } = new();
        public Skill Strength { get; set; } = new();
        public Skill Hits { get; set; } = new();
        public Skill Ranged { get; set; } = new();
        public Skill Prayer { get; set; } = new();
        public Skill Magic { get; set; } = new();
        public Skill Cooking { get; set; } = new();
        public Skill Woodcut { get; set; } = new();
        public Skill Fletching { get; set; } = new();
        public Skill Fishing { get; set; } = new();
        public Skill Firemaking { get; set; } = new();
        public Skill Crafting { get; set; } = new();
        public Skill Smithing { get; set; } = new();
        public Skill Mining { get; set; } = new();
        public Skill Herblaw { get; set; } = new();
        public Skill Agility { get; set; } = new();
        public Skill Thieving { get; set; } = new();

        public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
        public ICollection<BankItem> BankItems { get; set; } = new List<BankItem>();

        public DateTime? BankViewTimestamp { get; set; }

        public void UpdateBankItems(ICollection<BankItem> bankItems, DateTime? bankViewTimestamp)
        {
            if (bankViewTimestamp == null)
                return;

            BankViewTimestamp = bankViewTimestamp;

            BankItems.Clear();

            foreach (var bankItem in bankItems)
                BankItems.Add(bankItem);
        }

        public void UpdateInventoryItems(ICollection<InventoryItem> inventoryItems)
        {
            InventoryItems.Clear();

            foreach (var inventoryItem in inventoryItems)
                InventoryItems.Add(inventoryItem);
        }

        public void UpdateSkills(Account account)
        {
            static void UpdateSkill(Skill skill, Skill newSkill)
            {
                skill.Level = newSkill.Level;
                skill.CurrentLevel = newSkill.CurrentLevel;
                skill.Xp = newSkill.Xp;
            }

            UpdateSkill(Attack, account.Attack);
            UpdateSkill(Defense, account.Defense);
            UpdateSkill(Strength, account.Strength);
            UpdateSkill(Hits, account.Hits);
            UpdateSkill(Ranged, account.Ranged);
            UpdateSkill(Prayer, account.Prayer);
            UpdateSkill(Magic, account.Magic);
            UpdateSkill(Cooking, account.Cooking);
            UpdateSkill(Woodcut, account.Woodcut);
            UpdateSkill(Fletching, account.Fletching);
            UpdateSkill(Fishing, account.Fishing);
            UpdateSkill(Firemaking, account.Firemaking);
            UpdateSkill(Crafting, account.Crafting);
            UpdateSkill(Smithing, account.Smithing);
            UpdateSkill(Mining, account.Mining);
            UpdateSkill(Herblaw, account.Herblaw);
            UpdateSkill(Agility, account.Agility);
            UpdateSkill(Thieving, account.Thieving);
        }

        public int GetTotalLevel()
        {
            return Attack.Level + Defense.Level + Strength.Level +
                   Hits.Level + Ranged.Level + Prayer.Level +
                   Magic.Level + Cooking.Level + Woodcut.Level +
                   Fletching.Level + Fishing.Level + Firemaking.Level +
                   Crafting.Level + Smithing.Level + Mining.Level +
                   Herblaw.Level + Agility.Level + Thieving.Level;
        }
    }
}
