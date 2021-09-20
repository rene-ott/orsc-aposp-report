namespace ApospReport.Application
{
    public class Result<TContent>
    {
        public TContent Content { get; }

        public Result(TContent content)
        {
            Content = content;
        }
    }
}
