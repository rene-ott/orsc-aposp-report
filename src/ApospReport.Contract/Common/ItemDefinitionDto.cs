namespace ApospReport.Contract.Common
{
    public abstract class ItemDefinitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStackable { get; set; }
    }
}
