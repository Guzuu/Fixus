﻿using System.Data.Entity;
using Fixus.Data.Entities;

namespace Fixus.Data
{
    public class FixusContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<KindOfAddress> KindOfAddresses { get; set; }

        public FixusContext() : base("name=FixusDb")
        {
            //Database.SetInitializer<FixusContext>(new DropCreateDatabaseAlways<FixusContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
