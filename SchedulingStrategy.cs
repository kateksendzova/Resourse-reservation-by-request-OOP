namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal abstract class SchedulingStrategy
    {
        public abstract string Name { get; }

        public abstract IEnumerable<Request> Order(IEnumerable<Request> requests);

        public override string ToString() => Name;
    }

    internal class ArrivalStrategy : SchedulingStrategy
    {
        public override string Name => "За часом надходження";

        public override IEnumerable<Request> Order(IEnumerable<Request> requests)
            => requests.OrderBy(r => r.CreationTime);
    }

    internal class PriorityStrategy : SchedulingStrategy
    {
        public override string Name => "За пріоритетом";

        public override IEnumerable<Request> Order(IEnumerable<Request> requests)
            => requests
                .OrderByDescending(r => (int)r.Person.Role)
                .ThenByDescending(r => (int)r.TypeOfWork)
                .ThenBy(r => r.CreationTime);
    }
}