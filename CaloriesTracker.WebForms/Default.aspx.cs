using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaloriesTracker.WebForms
{
    public partial class _Default : Page
    {
        private CaloriesTrackerService service = new CaloriesTrackerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foodDropDown.DataSource = service.GetFood();
                exerciseDropDown.DataSource = service.GetExercises();

                DisplayDiary();

                Page.DataBind();
            }
        }

        protected void ShowData(object sender, CommandEventArgs e)
        {
            DisplayDiary();
        }

        private void DisplayDiary()
        {
            var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

            var list = service.GetDailyList(date);
            diaryGridView.DataSource = list;

            var totalConsumed = list.Sum(d => d.Food?.Calories);
            var totalBurned = list.Sum(d => d.Exercise?.Calories);

            totalConsumedLabel.Text = totalConsumed.ToString();
            totalBurnedLabel.Text = totalBurned.ToString();

            diaryGridView.DataBind();
        }

        protected void AddFoodClicked(object sender, CommandEventArgs e)
        {
            var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

            service.AddFood(int.Parse(foodDropDown.SelectedValue), date);

            DisplayDiary();
        }

        protected void AddExerciseClicked(object sender, CommandEventArgs e)
        {
            var date = string.IsNullOrEmpty(dateTextBox.Text) ? DateTime.Today : DateTime.Parse(dateTextBox.Text);

            service.AddExercise(int.Parse(exerciseDropDown.SelectedValue), date);

            DisplayDiary();
        }

        protected void DiaryDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = (int) e.Keys[0];

            service.DeleteRecord(id);

            DisplayDiary();
        }
    }
}