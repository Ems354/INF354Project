using System;
using System.Collections.Generic;

namespace GroupProject.Entity
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }

        public int TitleID { get; set; }
        public Title Title { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
