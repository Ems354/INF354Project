using System;
using GroupProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace GroupProject.Data
{
    public class ISPContext: DbContext
    {
        public ISPContext(DbContextOptions<ISPContext> options): base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
