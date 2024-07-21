namespace PharmacyManagementAPI.Models

{
    using Microsoft.EntityFrameworkCore;

    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }

        public DbSet<Pharmacy> Pharmacies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Ensures Id is generated on add
        }
    }
}
