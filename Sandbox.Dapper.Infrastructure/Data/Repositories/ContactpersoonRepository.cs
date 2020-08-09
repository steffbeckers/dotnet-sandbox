using Dapper;
using Microsoft.Extensions.Configuration;
using Sandbox.Dapper.Core.Interfaces;
using Sandbox.Dapper.Core.Models;
using Sandbox.Dapper.Infrastructure.Data.Mappers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sandbox.Dapper.Infrastructure.Data.Repositories
{
    public class ContactpersoonRepository : IContactpersoonRepository
    {
        private readonly IConfiguration configuration;
        private readonly IDbConnection db;

        public ContactpersoonRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.db = new SqlConnection(this.configuration.GetConnectionString("CRM_MSSQL_DATABASE"));
        }

        public List<Contactpersoon> GetAllContacts()
        {
            // TODO
            ClassMappers.Initialize();

            return db.Query<Contactpersoon>("SELECT * FROM Contacts").ToList();
        }
    }
}
