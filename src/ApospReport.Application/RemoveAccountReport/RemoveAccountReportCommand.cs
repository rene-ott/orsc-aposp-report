using MediatR;

namespace ApospReport.Application.RemoveAccountReport
{
    public class RemoveAccountReportCommand : IRequest
    {
        public string Username { get; }
        
        public RemoveAccountReportCommand(string username)
        {
            Username = username;
        }

    }
}
