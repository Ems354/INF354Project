using System;
using System.Linq;
using GroupProject.Entity;

namespace GroupProject.Data
{
    public static class DataSeeder
    {
        public static void Seed(ISPContext context)
        {
            context.Database.EnsureCreated();

            // Look for any clientw.
            if (context.Clients.Any())
            {
                // DB has been seeded
                return;
            }

            var titles = new Title[]
            {
                new Title {
                    Name = "Prof."
                },
                new Title {
                    Name = "Dr."
                },
                new Title {
                    Name = "Mr."
                },
                new Title {
                    Name = "Ms."
                },
                new Title {
                    Name = "Mrs."
                }
            };
            foreach (Title t in titles)
            {
                context.Titles.Add(t);
            }
            context.SaveChanges();

            var clients = new Client[]
            {
                new Client {
                    Name = "Carson",
                    Surname = "Alexander",
                    Number = "0835126789",
                    TitleID = 3
                },
                new Client {
                    Name = "Meredith",
                    Surname = "Alonso",
                    Number = "0835126789",
                    TitleID = 5
                },
                new Client {
                    Name = "Arturo",
                    Surname = "Anand",
                    Number = "0835126789",
                    TitleID = 3
                },
                new Client {
                    Name = "Gytis",
                    Surname = "Barzdukas",
                    Number = "0835126789",
                    TitleID = 3
                },
                new Client {
                    Name = "Yan",
                    Surname = "Li",
                    Number = "0835126789",
                    TitleID = 3
                },
                new Client {
                    Name = "Peggy",
                    Surname = "Justice",
                    Number = "0835126789",
                    TitleID = 4
                },
                new Client {
                    Name = "Laura",
                    Surname = "Norman",
                    Number = "0835126789",
                    TitleID = 4
                },
                new Client {
                    Name = "Nino",
                    Surname = "Olivetto",
                    Number = "0835126789",
                    TitleID = 1
                }
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var connections = new Connection[]
            {
                new Connection {
                    Name = "ADSL"
                },
                new Connection {
                    Name = "VDSL"
                },
                new Connection {
                    Name = "Fibre"
                },
                new Connection {
                    Name = "LTE"
                }
            };
            foreach (Connection c in connections) 
            {
                context.Connections.Add(c);
            }
            context.SaveChanges();

            var packages = new Package[]
            {
                new Package {
                    Name = "ADSL 2Mb Uncapped",
                    Cap = "100",
                    ConnectionID = 1
                },
                new Package {
                    Name = "ADSL 4Mb Uncapped",
                    Cap = "100",
                    ConnectionID = 1
                },
                new Package {
                    Name = "ADSL 10Mb Uncapped",
                    Cap = "100",
                    ConnectionID = 1
                },
                new Package {
                    Name = "ADSL 20Mb Uncapped",
                    Cap = "100",
                    ConnectionID = 1
                },
            };
            foreach (Package p in packages)
            {
                context.Packages.Add(p);
            }
            context.SaveChanges();

            var subscriptions = new Subscription[]
            {
                new Subscription {
                    ClientID = 1,
                    PackageID = 2,
                    Date = DateTime.Parse("2018-04-30")
                },
                new Subscription {
                    ClientID = 2,
                    PackageID = 3,
                    Date = DateTime.Parse("2018-04-30")
                },
                new Subscription {
                    ClientID = 4,
                    PackageID = 2,
                    Date = DateTime.Parse("2018-04-30")
                },
                new Subscription {
                    ClientID = 5,
                    PackageID = 2,
                    Date = DateTime.Parse("2018-04-30")
                },
                new Subscription {
                    ClientID = 6,
                    PackageID = 1,
                    Date = DateTime.Parse("2018-04-30")
                }
            };
            foreach (Subscription s in subscriptions)
            {
                context.Subscriptions.Add(s);
            }
            context.SaveChanges();
        }
    }
}
