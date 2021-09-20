using System.Collections.Generic;

namespace ApospReport.Domain
{
    public class ItemDefinition
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Name { get; set; }
        public bool IsStackable { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }
        public ICollection<BankItem> BankItems { get; set; }
    }
}
