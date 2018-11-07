using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.View.Models
{
    public class ActivityUserView
    {
        public string activityDesc { get; set; }
        public string userName { get; set; }
        public string petName { get; set; }
        public DateTime scheduledTime { get; set; }

        public ActivityUserView(string activity, string user, string pet, DateTime clientScheduledTime)
        {
            this.activityDesc = activity;
            this.userName = user;
            this.petName = pet;
            this.scheduledTime = clientScheduledTime;
        }
    }
}
