﻿namespace modelbinding.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}