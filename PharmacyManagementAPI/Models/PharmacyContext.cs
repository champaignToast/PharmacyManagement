namespace PharmacyManagementAPI.Models

{
    using Microsoft.EntityFrameworkCore;

    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }

        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
