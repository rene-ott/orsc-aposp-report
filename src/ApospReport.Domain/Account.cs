using System.Collections.Generic;

namespace ApospReport.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public Skill Attack { get; set; }
        public Skill Defense { get; set; }
        public Skill Strength { get; set; }
        public Skill Hits { get; set; }
        public Skill Ranged { get; set; }
        public Skill Prayer { get; set; }
        public Skill Magic { get; set; }
        public Skill Cooking { get; set; }
        public Skill Woodcut { get; set; }
        public Skill Fletching { get; set; }
        public Skill Fishing { get; set; }
        public Skill Firemaking { get; set; }
        public Skill Crafting { get; set; }
        public Skill Smithing { get; set; }
        public Skill Mining { get; set; }
        public Skill Herblaw { get; set; }
        public Skill Agility { get; set; }
        public Skill Thieving { get; set; }

        public ICollection<InventoryItem> InventoryItems{ get; set; }
        public ICollection<BankItem> BankItems { get; set; }
    }
}
