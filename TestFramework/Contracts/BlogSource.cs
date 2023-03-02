namespace TestFramework.Contracts
{
    public record BlogSource
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string H1Header { get; init; }
        public string [] H2Headers { get; init; }
        public string [] Paragraphs { get; init; }
    }
}
