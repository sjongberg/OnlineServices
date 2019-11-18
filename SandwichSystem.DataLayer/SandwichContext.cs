using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer
{
    public class SandwichContext :DbContext
    {
        public SandwichContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=SandwishDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<SandwichEF> Sandwiches { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
    }
}
