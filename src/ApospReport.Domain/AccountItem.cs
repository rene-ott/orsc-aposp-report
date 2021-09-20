namespace ApospReport.Domain
{
    public abstract class AccountItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public ItemDefinition Definition { get; set; }
        public Account Account { get; set; }
    }
}
