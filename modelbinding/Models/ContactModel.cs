using Microsoft.AspNetCore.Mvc;

namespace modelbinding.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [FromQuery]
        public string Name { get; set; }
        public string ContactType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
    }
}
