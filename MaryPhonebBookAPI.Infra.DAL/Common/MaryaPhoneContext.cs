using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Core.Entities.Phones;
using MaryPhonebBookAPI.Infra.DAL.People;
using MaryPhonebBookAPI.Infra.DAL.Phones;
using Microsoft.EntityFrameworkCore;

namespace MaryPhonebBookAPI.Infra.DAL.Common
{
    public class MaryaPhoneContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=maryaphonebook;integrated security =true;");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        }
    }
}
