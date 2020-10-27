using Microsoft.EntityFrameworkCore;
using Sandbox.Mediatr.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Mediatr.API.BLL.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
