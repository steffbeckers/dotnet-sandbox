using DapperExtensions.Mapper;
using Sandbox.Dapper.Core.Models;

namespace Sandbox.Dapper.Infrastructure.Data.Mappers
{
    public sealed class ContactClassMapper : ClassMapper<Contactpersoon>
    {
        public ContactClassMapper()
        {
            base.Table("Contacts");
            Map(x => x.Voornaam).Column("FirstName");
            Map(x => x.Naam).Column("LastName");
            AutoMap();
        }
    }
}
