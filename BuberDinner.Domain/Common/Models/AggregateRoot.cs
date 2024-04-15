namespace BuberDinner.Domain.Common.Models
{
    public class AggregateRoot<TId> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id) { }
    }
}