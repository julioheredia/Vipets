using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Services.Models
{
    public class Credentials
    {
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }

        public Credentials() { }

        public Credentials(string email, string password, string token)
        {
            this.email = email;
            this.password = password;
            this.token = token;
        }
    }
}
