using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(string Name, string Description, List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;
    public record MenuSectionCommand(string Name, string Description, List<MenuItemCommand> items);
    public record MenuItemCommand(string Name, string Description);
}
