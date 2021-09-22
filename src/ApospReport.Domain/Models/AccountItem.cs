namespace ApospReport.Domain.Models
{
    public abstract class AccountItem
    {
        public int Id { get; set; }

        public int ItemDefinitionId { get; set; }
        public ItemDefinition ItemDefinition { get; set; }

        public int Count { get; set; }
        public Account Account { get; set; }
    }
}
