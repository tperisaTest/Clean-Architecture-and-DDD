using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entity
{
    public sealed class Rating : Entity<RatingId>
    {
        private Rating(
            RatingId ratingId,
            HostId hostId,
            DinnerId dinnerId,
            int rating)
            : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            RatingValue = rating;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int RatingValue { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Rating Create(HostId hostId, DinnerId dinnerId, int rating)
        {
            return new(
                RatingId.CreateUnique(),
                hostId,
                dinnerId,
                rating);
        }
    }
}
