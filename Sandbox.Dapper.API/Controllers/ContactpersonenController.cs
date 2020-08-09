using Microsoft.AspNetCore.Mvc;
using Sandbox.Dapper.Core.Interfaces;
using Sandbox.Dapper.Core.Models;
using System.Collections.Generic;

namespace Sandbox.Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactpersonenController : ControllerBase
    {
        private readonly IContactpersoonRepository contactpersoonRepository;

        public ContactpersonenController(IContactpersoonRepository contactpersoonRepository)
        {
            this.contactpersoonRepository = contactpersoonRepository;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            List<Contactpersoon> contacts = contactpersoonRepository.GetAllContacts();

            return Ok(contacts);
        }
    }
}
