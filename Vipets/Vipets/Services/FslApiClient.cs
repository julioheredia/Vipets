using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Services
{
    public sealed class FslApiClient
    {
        private static volatile IAuthenticationApiClient _instance;
        private static object syncRoot = new object();

        public static IAuthenticationApiClient Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        _instance = new AuthenticationApiClient(); // You can use Dependency Injection
                    }
                }

                return _instance;
            }
        }
    }
}
