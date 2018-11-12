using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Petshop
    {
        public long PetshopId { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string TelephoneAux { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastChange { get; set; }

        public Petshop() { }

    }
}
