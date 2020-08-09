using Sandbox.Dapper.Core.Models;
using System.Collections.Generic;

namespace Sandbox.Dapper.Core.Interfaces
{
    public interface IContactpersoonRepository
    {
        List<Contactpersoon> GetAllContacts();
    }
}
