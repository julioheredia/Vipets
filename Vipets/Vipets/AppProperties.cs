using System;
using System.Collections.Generic;
using System.Text;
using Vipets.Services.Models;

namespace Vipets
{
    public class AppProperties
    {

        private User LoggedUser;
        
        public User GetLoggedUser()
        {
            return this.LoggedUser;
        }

        public void SetLoggedUser(User user)
        {
            this.LoggedUser = user;
        }
    }
}
