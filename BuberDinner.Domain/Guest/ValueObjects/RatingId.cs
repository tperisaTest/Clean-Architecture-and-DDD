using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class RatingId : ValueObject
    {
        public Guid Value { get; set; }
        private RatingId(Guid value)
        {
            Value = value;
        }

        public static RatingId CreateUnique()
        {
            return new RatingId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
