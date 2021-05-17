using Albelli.OrderManager.Application.CQRS.Orders.Command;
using Albelli.OrderManager.Application.CQRS.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albelli.OrderManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Creates a new Order",
            Description = "productTypes: PhotoBook, Calendar, Canvas, Cards, Mug ")
        ]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            var createdOrder = await _mediator.Send(command);
            return Ok(createdOrder);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Gets a single Order by Id",
            Description = "Gets a single Order by Id")
        ]
        public async Task<IActionResult> Get([FromRoute] GetOrderByIdQuery query)
        {
            var orderDetails = await _mediator.Send(query);

            if (orderDetails == null)
                return NotFound(query.Id);

            return Ok(orderDetails);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Gets a list of all Orders",
            Description = "Gets a list of all Orders")
        ]
        public async Task<IActionResult> Get()
        {
            var listOfOrders = await _mediator.Send(new GetOrdersQuery());

            if (listOfOrders == null || !listOfOrders.Any())
                return NoContent();

            return Ok(listOfOrders);
        }
    }
}
