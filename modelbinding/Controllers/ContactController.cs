using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelbinding.Models;

namespace modelbinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private static readonly ContactModel[] Contacts = new[]
       {
            new ContactModel { Id = 1, Name="Sam", ContactType="Phone" },
            new ContactModel { Id = 2,  Name="Jet", ContactType="Phone"},
            new ContactModel { Id = 3, Name="AAng",  ContactType="Fax"},
            new ContactModel { Id = 4, Name="Raj" , ContactType="Email"},
            new ContactModel { Id = 5,  Name="Pinky", ContactType="Mail"},
        };

        [HttpGet("GetContacts")]
        public IEnumerable<ContactModel> Get()
        {
            return Contacts;
        }

        [BindProperty(Name="contact_id", SupportsGet =true)]
        public int? ContactId { get; set; }

        [BindProperty(SupportsGet =true)]
        public ContactModel Contact { get; set; }

        [HttpGet("GetContact")]
        public ContactModel GetContact()
        {
            var contact = Contacts.FirstOrDefault(c => c.Id == ContactId);
            return contact ?? new ContactModel();
        }

        [HttpPost]
        public void InsertContact([FromBody]ContactModel contactModel)
        {

        }
    }
}
