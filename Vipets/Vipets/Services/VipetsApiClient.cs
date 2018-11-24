using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Services
{
    public sealed class VipetsApiClient
    {
        private static volatile IAuthenticationApiClient _instanceAuthentication;
        private static volatile IPetActivityApiClient _instancePetActivity;
        private static volatile IUserApiClient _instanceUser;
        private static volatile IActivityApiClient _instanceActivity;
        private static volatile IPetApiClient _instancePet;

        private static object syncRoot = new object();

        public static IAuthenticationApiClient CurrentAuthentications
        {
            get
            {
                if (_instanceAuthentication == null)
                {
                    lock (syncRoot)
                    {
                        _instanceAuthentication = new AuthenticationApiClient();
                    }
                }

                return _instanceAuthentication;
            }
        }

        public static IPetActivityApiClient CurrentPetActivitys
        {
            get
            {
                if (_instancePetActivity == null)
                {
                    lock (syncRoot)
                    {
                        _instancePetActivity = new PetActivityApiClient();
                    }
                }

                return _instancePetActivity;
            }
        }

        public static IUserApiClient CurrentUsers
        {
            get
            {
                if (_instanceUser == null)
                {
                    lock (syncRoot)
                    {
                        _instanceUser = new UserApiClient();
                    }
                }

                return _instanceUser;
            }
        }

        public static IActivityApiClient CurrentActivitys
        {
            get
            {
                if (_instanceActivity == null)
                {
                    lock (syncRoot)
                    {
                        _instanceActivity = new ActivityApiClient();
                    }
                }

                return _instanceActivity;
            }
        }

        public static IPetApiClient CurrentPets
        {
            get
            {
                if (_instancePet == null)
                {
                    lock (syncRoot)
                    {
                        _instancePet = new PetApiClient();
                    }
                }
                return _instancePet;
            }
        }
    }
}
