using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Entities;

namespace SandwichSystem.DataLayer
{
    public class MealContext : DbContext
    {
        public MealContext()
        {

        }

        public MealContext(DbContextOptions<MealContext> options)
        : base(options)
        { }

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
                .HasForeignKey(MealCompositionEF => MealCompositionEF.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealCompositionEF>()
                .HasOne<IngredientEF>(MealCompositionEF => MealCompositionEF.Ingredient)
                .WithMany(IngredientEF => IngredientEF.MealsWithIngredient)
                .HasForeignKey(MealsWithIngredient => MealsWithIngredient.IngredientId);
                //.OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<MealEF> Meals { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
        public DbSet<MealCompositionEF> MealCompositions { get; set; }
        public DbSet<SupplierEF> Suppliers { get; set; }
    }
}
