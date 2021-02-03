using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaloriesTracker.Blazor.Data;
using Microsoft.EntityFrameworkCore;

namespace CaloriesTracker.Blazor.Context
{
    public class CaloriesContext : DbContext
    {
        public DbSet<Food> Food { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<CalorieDiary> CalorieDiaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CaloriesTracker.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
