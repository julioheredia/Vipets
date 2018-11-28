using System;

namespace Vipets.Models
{
    public class PetActivity
    {
        public long petActivityId { get; set; }
        public User employed { get; set; }
        public Pet pet { get; set; }
        public Activity activity { get; set; }
        public Petshop petshop { get; set; }
        public DateTime clientScheduledTime { get; set; }
        public DateTime activityStart { get; set; }
        public DateTime activityEnd { get; set; }
        public User clientGetPet { get; set; }
        public bool isActivityCompleted { get; set; }
        public DateTime? activityCompletedTime { get; set; }

        public PetActivity() { }
    }
}
