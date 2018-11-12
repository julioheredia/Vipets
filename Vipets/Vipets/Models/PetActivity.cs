using System;

namespace Vipets.Models
{
    public class PetActivity
    {
        public long PetActivityId { get; set; }
        public User User { get; set; }
        public Pet Pet { get; set; }
        public Activity Activity { get; set; }
        public Petshop Petshop { get; set; }
        public DateTime ClientScheduledTime { get; set; }
        public DateTime ActivityStart { get; set; }
        public DateTime ActivityEnd { get; set; }

        public PetActivity() { }
    }
}
