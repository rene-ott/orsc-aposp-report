using ApospReport.Contract.Common;

namespace ApospReport.Contract.AccountReport
{
    public class AccountReportItemDto : ItemDefinitionDto
    {
        public int Position { get; set; }
        public int Count { get; set; }
    }
}
