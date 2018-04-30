using System;
using System.Collections.Generic;

namespace GroupProject.Entity
{
    public class Client
    {
        public int ID { get; set; }
        public int Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
