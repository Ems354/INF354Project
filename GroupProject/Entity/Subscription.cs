using System;

namespace GroupProject.Entity
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int PackageID { get; set; }
        public Package Package { get; set; }

        public DateTime Date { get; set; }
    }
}
