using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId menuItemid, string name, string description) : base(menuItemid)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get; }
        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
