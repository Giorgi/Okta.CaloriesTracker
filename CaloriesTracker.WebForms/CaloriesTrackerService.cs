using System;
using System.Collections.Generic;
using System.Linq;
using CaloriesTracker.WebForms.Data;
using Microsoft.EntityFrameworkCore;

namespace CaloriesTracker.WebForms
{
    public class CaloriesTrackerService
    {
        public List<Food> GetFood()
        {
            using (var caloriesContext = new CaloriesContext())
            {
                return caloriesContext.Food.ToList();
            }
        }

        public List<Exercise> GetExercises()
        {
            using (var caloriesContext = new CaloriesContext())
            {
                return caloriesContext.Exercises.ToList();
            }
        }

        public void AddFood(int foodId, DateTime date)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                caloriesContext.CalorieDiaries.Add(new CalorieDiary()
                {
                    AddedAt = date,
                    FoodId = foodId
                });
                caloriesContext.SaveChanges();
            }
        }

        public void AddExercise(int exerciseId, DateTime date)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                caloriesContext.CalorieDiaries.Add(new CalorieDiary
                {
                    AddedAt = date,
                    ExerciseId = exerciseId
                });
                caloriesContext.SaveChanges();
            }
        }

        public void DeleteRecord(int id)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                caloriesContext.CalorieDiaries.Remove(new CalorieDiary { Id = id });
                caloriesContext.SaveChanges();
            }
        }

        public List<CalorieDiary> GetDailyList(DateTime date)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                var list = caloriesContext.CalorieDiaries.Where(diary => diary.AddedAt == date)
                    .Include(d => d.Food)
                    .Include(d => d.Exercise)
                    .OrderByDescending(diary => diary.Id)
                    .ToList();

                return list;
            }
        }
    }
}