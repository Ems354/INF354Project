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

            var clients = new Client[]
            {
                new Client {
                    Name = "Carson",
                    Surname = "Alexander"
                },
                new Client {
                    Name = "Meredith",
                    Surname = "Alonso"
                },
                new Client {
                    Name = "Arturo",
                    Surname = "Anand"
                },
                new Client {
                    Name = "Gytis",
                    Surname = "Barzdukas"
                },
                new Client {
                    Name = "Yan",
                    Surname = "Li"
                },
                new Client {
                    Name = "Peggy",
                    Surname = "Justice"
                },
                new Client {
                    Name = "Laura",
                    Surname = "Norman"
                },
                new Client {
                    Name = "Nino",
                    Surname = "Olivetto"
                }
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var packages = new Package[]
            {
                new Package {
                    Name = "ADSL 2Mb Uncapped",
                    Cap = "100",
                    Type = 1
                },
                new Package {
                    Name = "ADSL 4Mb Uncapped",
                    Cap = "100",
                    Type = 1
                },
                new Package {
                    Name = "ADSL 10Mb Uncapped",
                    Cap = "100",
                    Type = 1
                },
                new Package {
                    Name = "ADSL 20Mb Uncapped",
                    Cap = "100",
                    Type = 1
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
