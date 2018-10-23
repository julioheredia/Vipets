using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Services
{
    public sealed class FslApiClient
    {
        private static volatile ILoginApiClient _instance;
        private static object syncRoot = new object();

        public static ILoginApiClient Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        _instance = new LoginApiClient(); // You can use Dependency Injection
                    }
                }

                return _instance;
            }
        }
    }
}
