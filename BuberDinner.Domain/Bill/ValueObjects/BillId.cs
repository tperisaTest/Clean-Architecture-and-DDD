using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; set; }
        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new BillId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
