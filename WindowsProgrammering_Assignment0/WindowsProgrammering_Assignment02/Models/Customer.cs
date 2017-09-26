using System;

namespace WindowsProgrammering_Assignment02.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Newsletter { get; set; }
        public string Notes { get; set; }
    }
}
