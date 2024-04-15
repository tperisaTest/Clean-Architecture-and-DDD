using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; set; }
        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
