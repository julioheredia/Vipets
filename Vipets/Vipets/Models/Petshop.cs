using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Petshop
    {
        public long petshopId { get; set; }
        public string name { get; set; }
        public string businessName { get; set; }
        public string logo { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string telephoneAux { get; set; }
        public DateTime dateRegistration { get; set; }
        public DateTime dateLastChange { get; set; }

        public Petshop() { }

    }
}
