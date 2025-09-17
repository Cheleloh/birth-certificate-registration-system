using Microsoft.EntityFrameworkCore;
using BirthCertificateRegistrationSystem.Models;

namespace BirthCertificateRegistrationSystem.Data
{
    public class BirthCertificateDbContext : DbContext
    {
        public BirthCertificateDbContext(DbContextOptions<BirthCertificateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}