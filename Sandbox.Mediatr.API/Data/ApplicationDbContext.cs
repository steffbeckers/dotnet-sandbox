using Microsoft.EntityFrameworkCore;
using Sandbox.Mediatr.API.BLL.Common.Interfaces;
using Sandbox.Mediatr.API.Models;

namespace Sandbox.Mediatr.API.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
