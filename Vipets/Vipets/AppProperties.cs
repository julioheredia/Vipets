using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Vipets.Models;

namespace Vipets
{
    public class AppProperties
    {
        private User LoggedUser;
        private const string settingsKey = "user_logged";

        public User GetLoggedUser()
        {
            string jsonString = AppSettings.GetValueOrDefault(settingsKey, string.Empty);
            if (!jsonString.Equals(string.Empty))
            {
                var obj = JsonConvert.DeserializeObject<User>(jsonString);
                return obj;
            }
            return this.LoggedUser;
        }

        public void SetLoggedUser(User user)
        {
            var jsonString = JsonConvert.SerializeObject(user);
            AppSettings.AddOrUpdateValue(settingsKey, jsonString);
            this.LoggedUser = user;
        }

        public bool isUniquePetshop(User user)
        {
            if (user.petshops.Count > 1)
            {
                return false;
            }
            else
            {
                user.PetshopSession = user.petshops[0];
                return true;
            }
        }

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

    }
}
