using Microsoft.Extensions.DependencyInjection;
using Sandbox.Dapper.Core.Interfaces;
using Sandbox.Dapper.Infrastructure.Data.Mappers;
using Sandbox.Dapper.Infrastructure.Data.Repositories;

namespace Sandbox.Dapper.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IContactpersoonRepository, ContactpersoonRepository>();
        }
    }
}
