using System;
using System.Collections.Generic;

namespace GroupProject.Entity
{
    public class Package
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cap { get; set; }

        public int ConnectionID { get; set; }
        public Connection Connection { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
