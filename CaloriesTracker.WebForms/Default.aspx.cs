using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaloriesTracker.WebForms.Data;
using Microsoft.EntityFrameworkCore;

namespace CaloriesTracker.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var caloriesContext = new CaloriesContext())
                {
                    foodDropDown.DataSource = caloriesContext.Food.ToList();
                    exerciseDropDown.DataSource = caloriesContext.Exercises.ToList();

                    DisplayDiary(caloriesContext);
                }

                Page.DataBind();
            }
        }

        protected void ShowData(object sender, CommandEventArgs e)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                DisplayDiary(caloriesContext);
            }
        }

        private void DisplayDiary(CaloriesContext caloriesContext)
        {
            var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

            var list = caloriesContext.CalorieDiaries
                .Where(diary => diary.AddedAt == date).Include(d => d.Food)
                .Include(d => d.Exercise)
                .OrderByDescending(diary => diary.Id).ToList();
            diaryGridView.DataSource = list;

            var totalConsumed = list.Sum(d => d.Food?.Calories);
            var totalBurned = list.Sum(d => d.Exercise?.Calories);

            totalConsumedLabel.Text = totalConsumed.ToString();
            totalBurnedLabel.Text = totalBurned.ToString();

            diaryGridView.DataBind();
        }

        protected void AddFoodClicked(object sender, CommandEventArgs e)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

                caloriesContext.CalorieDiaries.Add(new CalorieDiary()
                {
                    AddedAt = date,
                    FoodId = int.Parse(foodDropDown.SelectedValue)
                });
                caloriesContext.SaveChanges();

                DisplayDiary(caloriesContext);
            }
        }

        protected void AddExerciseClicked(object sender, CommandEventArgs e)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

                caloriesContext.CalorieDiaries.Add(new CalorieDiary
                {
                    AddedAt = date,
                    ExerciseId = int.Parse(exerciseDropDown.SelectedValue)
                });
                caloriesContext.SaveChanges();

                DisplayDiary(caloriesContext);
            }
        }

        protected void DiaryDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (var caloriesContext = new CaloriesContext())
            {
                var id = (int)e.Keys[0];
                caloriesContext.CalorieDiaries.Remove(new CalorieDiary { Id = id });
                caloriesContext.SaveChanges();

                DisplayDiary(caloriesContext);
            }
        }
    }
}