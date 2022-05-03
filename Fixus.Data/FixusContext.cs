using System.Data.Entity;
using Fixus.Data.Entities;

namespace Fixus.Data
{
    public class FixusContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }

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
