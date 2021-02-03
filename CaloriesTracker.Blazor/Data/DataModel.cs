using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesTracker.Blazor.Data
{
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
}
