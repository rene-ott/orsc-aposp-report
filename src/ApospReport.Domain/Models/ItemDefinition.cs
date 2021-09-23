using System.Collections.Generic;

namespace ApospReport.Domain.Models
{
    public class ItemDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStackable { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }
        public ICollection<BankItem> BankItems { get; set; }
    }
}
