using ApospReport.Contract;
using MediatR;

namespace ApospReport.Application.SaveReport
{
    public class SaveReportCommand : IRequest
    {
        public ReportDto Report { get; }

        public SaveReportCommand(ReportDto report)
        {
            Report = report;
        }
    }
}
