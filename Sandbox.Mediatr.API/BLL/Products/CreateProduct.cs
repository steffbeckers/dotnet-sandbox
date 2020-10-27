using MediatR;
using Sandbox.Mediatr.API.BLL.Common.Interfaces;
using Sandbox.Mediatr.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Mediatr.API.BLL.Products
{
    public class CreateProduct : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreateProductHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Product product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Send(new ProductCreated() { Product = product });

            return product;
        }
    }
}
