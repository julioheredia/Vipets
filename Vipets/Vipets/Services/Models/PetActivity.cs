using System;

namespace Vipets.Services.Models
{
    public class PetActivity
    {
        public long petActivityId { get; set; }
        public User user { get; set; }
        public Pet pet { get; set; }
        public Activity activity { get; set; }
        public Petshop petshop { get; set; }
        public DateTime clientScheduledTime { get; set; }
        public DateTime activityStart { get; set; }
        public DateTime activityEnd { get; set; }

        public PetActivity() { }
    }
}
