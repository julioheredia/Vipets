using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Activity
    {
        public long activityId { get; set; }
        public string description { get; set; }
        public bool active { get; set; }

        public Activity() { }

    }
}
