using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Models
{
    public class Activity
    {
        public long ActivityId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Activity() { }

    }
}
