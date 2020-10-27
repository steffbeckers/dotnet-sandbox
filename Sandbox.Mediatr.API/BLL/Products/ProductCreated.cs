using MediatR;
using Sandbox.Mediatr.API.BLL.Common.Interfaces;
using Sandbox.Mediatr.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Mediatr.API.BLL.Products
{
    public class ProductCreated : IRequest
    {
        public Product Product { get; set; }
    }

    public class ProductCreatedHandler : IRequestHandler<ProductCreated, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ProductCreatedHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ProductCreated request, CancellationToken cancellationToken)
        {
            // Save a copy as test
            Product productCopy = new Product
            {
                Name = request.Product.Name + " Copy",
                Description = request.Product.Description,
                Price = request.Product.Price
            };

            _context.Products.Add(productCopy);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
