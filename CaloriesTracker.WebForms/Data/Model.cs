using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace CaloriesTracker.WebForms.Data
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

    public class CalorieDiary
    {
        public int Id { get; set; }
        public DateTime AddedAt { get; set; }

        public int? FoodId { get; set; }
        public Food Food { get; set; }

        public int? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
    }

    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
    }

    //public class CalorieDiaryFood
    //{
    //    public int FoodId { get; set; }
    //    public Food Food { get; set; }
        
    //    public int CalorieDiaryId { get; set; }
    //    public CalorieDiary CalorieDiary { get; set; }
    //}

    //public class CalorieDiaryExercise
    //{
    //    public int ExerciseId { get; set; }
    //    public Exercise Exercise { get; set; }
        
    //    public int CalorieDiaryId { get; set; }
    //    public CalorieDiary CalorieDiary { get; set; }
    //}
}