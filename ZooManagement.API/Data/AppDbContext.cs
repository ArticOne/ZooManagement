using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ZooManagement.API.Model;

namespace ZooManagement.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FoodStorage> FoodStorage { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasDiscriminator<string>("Type")
                .HasValue<CarnivoreAnimal>("Carnivore")
                .HasValue<HerbivoreAnimal>("Herbivore")
                .HasValue<GiraffeAnimal>("Giraffe");

            modelBuilder.Entity<FoodStorage>();

            modelBuilder.Entity<CarnivoreAnimal>().HasData(new List<Animal>()
            {
                new CarnivoreAnimal(),
                new CarnivoreAnimal(),
                new CarnivoreAnimal()
            });

            modelBuilder.Entity<HerbivoreAnimal>().HasData(new List<HerbivoreAnimal>()
            {
                new HerbivoreAnimal(),
                new HerbivoreAnimal(),
                new HerbivoreAnimal()
            });

            modelBuilder.Entity<GiraffeAnimal>().HasData(new List<GiraffeAnimal>()
            {
                new GiraffeAnimal(),
                new GiraffeAnimal(),
                new GiraffeAnimal()
            });


            modelBuilder.Entity<FoodStorage>().HasData(new List<FoodStorage>()
            {
                new()
                {
                    Id = 1,
                    Inventory = 200
                }
            });
        }
    }
}
