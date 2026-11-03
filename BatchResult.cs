namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class BatchResult
    {
        public List<Request> Accepted { get; } = new();
        public List<string> Rejected { get; } = new();
    }
}