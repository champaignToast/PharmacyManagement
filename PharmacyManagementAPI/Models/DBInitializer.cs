namespace PharmacyManagementAPI.Models;
public static class DbInitializer
{
    public static void Initialize(PharmacyContext context)
    {
        context.Database.EnsureCreated();
        if (context.Pharmacies.Any())
        {
            return; // DB has been seeded
        }

        var pharmacies = new Pharmacy[]
        {
            new Pharmacy { Name = "Pharmacy Cat", Address = "1234 Cat Ln", City = "CatCity", State = "CatState", Zip = "75034", NumberOfFilledPrescriptions = 100, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
            new Pharmacy { Name = "Pharmacy Duck", Address = "4321 Duck St", City = "DuckCity", State = "DuckState", Zip = "75024", NumberOfFilledPrescriptions = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
            new Pharmacy { Name = "Pharmacy Dog", Address = "5678 Dog Ave", City = "DogCity", State = "DogState", Zip = "75878", NumberOfFilledPrescriptions = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
            new Pharmacy { Name = "Pharmacy Turtle", Address = "8765 Turtle St", City = "TurtleCity", State = "TurtleState", Zip = "34567", NumberOfFilledPrescriptions = 150, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
            new Pharmacy { Name = "Pharmacy Fish", Address = "0145 Fish St", City = "FishCity", State = "FishState", Zip = "12345", NumberOfFilledPrescriptions = 250, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
        };

        foreach (var p in pharmacies)
        {
            context.Pharmacies.Add(p);
        }
        context.SaveChanges();
    }
}

