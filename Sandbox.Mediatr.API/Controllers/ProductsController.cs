using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Mediatr.API.BLL.Products;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Mediatr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct product, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(product, cancellationToken));
        }
    }
}
