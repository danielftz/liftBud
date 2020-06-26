using liftBud.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace liftBud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataDetailPage_dev : ContentPage
    {
        PersonData selected_data;
        SQLiteConnection conn;
        public DataDetailPage_dev(PersonData selected_data)
        {
            InitializeComponent();
            this.selected_data = selected_data;
            id.Text = selected_data.Id.ToString();
            sexSwitch.IsToggled = selected_data.Male;
            height.Text = selected_data.Height.ToString();
            weight.Text = selected_data.Weight.ToString();
            measurement1.Text = selected_data.Measurement1.ToString();
            measurement2.Text = selected_data.Measurement2.ToString();
            measurement3.Text = selected_data.Measurement3.ToString();
            bfPercent.Text = selected_data.BFPercent.ToString();
            modeSwitch.IsToggled = selected_data.NormalModel;
            activity.Text = selected_data.Activity.ToString();
            mealsPerDay.Text = selected_data.MealsPerDay.ToString();
            goal.Text = selected_data.Goal.ToString();
            lbm.Text = "lean body mass:" + selected_data.LBM.ToString()+" kg";
            bmr.Text = "basal metabolic rate" + selected_data.BMR.ToString() + " kcal";
            tdee.Text = "total daily energy expenditure" + selected_data.TDEE.ToString() + " kcal";
            tdeeg.Text = "total daily energy expenditure based on goal" + selected_data.TDEEG.ToString() + " kcal";

            
        }

        private void bt_update_Clicked(object sender, EventArgs e)
        {
            this.selected_data.Id = Convert.ToInt32(id.Text);
            this.selected_data.Male = sexSwitch.IsToggled;
            this.selected_data.Age = Convert.ToInt32(age.Text);
            this.selected_data.Height = Convert.ToInt32(height.Text);
            this.selected_data.Weight = Convert.ToInt32(weight.Text);
            this.selected_data.Measurement1 = Convert.ToDouble(measurement1.Text);
            this.selected_data.Measurement2 = Convert.ToDouble(measurement2.Text);
            this.selected_data.Measurement3 = Convert.ToDouble(measurement3.Text);
            this.selected_data.BFPercent = Convert.ToDouble(bfPercent.Text);
            this.selected_data.NormalModel = modeSwitch.IsToggled;
            this.selected_data.Activity = Convert.ToInt32(activity.Text);
            this.selected_data.MealsPerDay = Convert.ToInt32(mealsPerDay.Text);
            this.selected_data.Goal = Convert.ToInt32(goal.Text);
            this.selected_data.LBM = 0;
            this.selected_data.BMR = 0;
            this.selected_data.TDEE = 0;
            this.selected_data.TDEEG = 0;

            using (conn=new SQLiteConnection(App.dbLocation))
            {
                conn.CreateTable<PersonData>();
                var rows = conn.Update(this.selected_data);
                if (rows > 0) DisplayAlert("Succes", "Successfully updated entry", "OK");
                else DisplayAlert("Failure", "Something went wrong", "OK");
                conn.Close();

            }
        }

        private void bt_delete_Clicked(object sender, EventArgs e)
        {
            using (conn = new SQLiteConnection(App.dbLocation))
            {
                conn.Delete<PersonData>(this.selected_data.CurrentDateTime);
                conn.Close();
            }
            Navigation.PopAsync();
        }

        
    }
}