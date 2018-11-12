using System;
using System.Collections.Generic;

namespace Vipets.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
        public bool Admin { get; set; }
        public bool Employee { get; set; }
        public bool Client { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Petshop> Petshops { get; set; }

        public User() { }

    }
}
