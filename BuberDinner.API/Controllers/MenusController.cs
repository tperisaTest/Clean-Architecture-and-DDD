using BuberDinner.API.Common.Mapping;
using BuberDinner.Contracts.Menus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly MenuMapper _menuMapper;
        private readonly ISender _mediator;
        public MenusController(MenuMapper menuMapper, ISender mediator)
        {
            _menuMapper = menuMapper;
            _mediator = mediator;
        }
        [HttpPost]
        public IActionResult CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _menuMapper.CreateMenuRequestToCreateMenuCommand(request);
            _mediator.Send(command);
            return Ok(request);
        }
    }
}
