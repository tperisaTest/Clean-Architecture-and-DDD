using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();

        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            float averageRating,
            UserId userId)
            : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public float AverageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public static Host Create(string firstName, string lastName, string profileImage, float averageRating, UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId);
        }
    }
}
