﻿namespace Customers.API.Controllers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public long InsurancePrice { get; set; }
    }
}
