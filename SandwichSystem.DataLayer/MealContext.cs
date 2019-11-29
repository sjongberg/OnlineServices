using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Entities;

namespace SandwichSystem.DataLayer
{
    public class MealContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MealDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealCompositionEF>().HasKey(si => new { si.MealId, si.IngredientId });

            modelBuilder.Entity<MealCompositionEF>()
                .HasOne<MealEF>(MealsIngredientsEF => MealsIngredientsEF.Meal)
                .WithMany(MealEF => MealEF.MealsComposition)
                .HasForeignKey(MealCompositionEF => MealCompositionEF.MealId);


            modelBuilder.Entity<MealCompositionEF>()
                .HasOne<IngredientEF>(MealCompositionEF => MealCompositionEF.Ingredient)
                .WithMany(IngredientEF => IngredientEF.MealsComposition)
                .HasForeignKey(MealCompositionEF => MealCompositionEF.IngredientId);
        }

        public DbSet<MealEF> Sandwiches { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
        public DbSet<MealCompositionEF> MealCompositions { get; set; }
        public DbSet<SupplierEF> Suppliers { get; set; }
    }
}
