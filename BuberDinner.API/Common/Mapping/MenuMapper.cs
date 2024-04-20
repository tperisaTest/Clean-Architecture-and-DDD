using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using Riok.Mapperly.Abstractions;

namespace BuberDinner.API.Common.Mapping
{
    [Mapper]
    public partial class MenuMapper
    {
        public partial CreateMenuCommand CreateMenuRequestToCreateMenuCommand(CreateMenuRequest request);
    }
}