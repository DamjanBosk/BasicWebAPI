using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using BasicWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(CreateUpdateContactRequest request)
        {
            var contact = await _contactRepository.CreateContact(request);
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, CreateUpdateContactRequest request)
        {
            var contact = await _contactRepository.UpdateContact(id, request);
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var result = await _contactRepository.DeleteContact(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Contact>>> FilterContacts([FromQuery] int companyId, [FromQuery] int countryId)
        {
            var result = await _contactRepository.FilterContacts(companyId, countryId);
            return Ok(result);
        }
    }
}