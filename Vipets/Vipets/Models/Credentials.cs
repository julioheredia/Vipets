using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public Credentials() { }

        public Credentials(string email, string password, string token)
        {
            Email = email;
            Password = password;
            Token = token;
        }
    }
}
