using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Entities;

namespace SandwichSystem.DataLayer
{
    public class SandwichSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SandwichDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SandwichIngredient>().HasKey(si => new { si.SandwichId, si.IngredientId });

            modelBuilder.Entity<SandwichIngredient>()
                .HasOne<SandwichEF>(si => si.Sandwich)
                .WithMany(sand => sand.SandwichIngredients)
                .HasForeignKey(sc => sc.SandwichId);


            modelBuilder.Entity<SandwichIngredient>()
                .HasOne<IngredientEF>(sc => sc.Ingredient)
                .WithMany(ing => ing.SandwichIngredients)
                .HasForeignKey(sc => sc.SandwichId);
        }

        public DbSet<SandwichEF> Sandwiches { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
        public DbSet<SandwichIngredient> SandwichIngredients { get; set; }
        public DbSet<SupplierEF> Suppliers { get; set; }
    }
}
