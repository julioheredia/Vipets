using System;

namespace Vipets.Services.Models
{
    public class User
    {
        public long userId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public byte[] photo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime lastChangeDate { get; set; }
        public bool admin { get; set; }
        public bool employee { get; set; }
        public bool client { get; set; }

        public User() { }

    }
}
