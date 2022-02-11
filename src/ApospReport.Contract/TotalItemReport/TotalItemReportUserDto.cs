namespace ApospReport.Contract.TotalItemReport
{
    public class TotalItemReportUserDto
    {
        public string Username { get; set; }
        public int TotalItemCount { get; set; }
        public int BankItemCount { get; set; }
        public int InventoryItemCount { get; set; }
    }
}
