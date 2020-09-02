using liftBud.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace liftBud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordDetailPage_dev : ContentPage
    {
        PersonData selected_data;
        SQLiteConnection conn;
        public RecordDetailPage_dev(PersonData selected_data)
        {
            InitializeComponent();

            this.selected_data = selected_data;
            this.selected_data.CurrentDateTime = selected_data.CurrentDateTime;
            
            id.Text = selected_data.Id;
            sex.SelectedIndex = Convert.ToInt32(selected_data.Male);
            age.Text = selected_data.Age.ToString();
            height.Text = selected_data.Height.ToString();
            weight.Text = selected_data.Weight.ToString();
            waist_measurement.Text = selected_data.Waist_m.ToString();
            neck_measurement.Text = selected_data.Neck_m.ToString();
            hip_measurement.Text = selected_data.Hip_m.ToString();
            bf_percent.Text = selected_data.BFPercent.ToString();
            model.SelectedIndex = Convert.ToInt32(selected_data.NormalModel);
            ideal_activity_level.SelectedIndex = Convert.ToInt32(selected_data.Activity);
            meals_per_day.SelectedIndex = Convert.ToInt32(selected_data.MealsPerDay);
            goal.SelectedIndex = Convert.ToInt32(selected_data.Goal);
            lbm.Text = selected_data.LBM.ToString();
            bmr.Text = selected_data.BMR.ToString();
            tdee.Text = selected_data.TDEE.ToString();
            tdeeg.Text = selected_data.TDEEG.ToString();
            fat_g.Text = selected_data.Fat_amount.ToString();
            protein_g.Text = selected_data.Protein_amount.ToString();
            carb_g.Text = selected_data.Carb_amount.ToString();

        }

        private void bt_update_Clicked(object sender, EventArgs e)
        { 
            this.selected_data.Id = id.Text;
            this.selected_data.Male = Convert.ToBoolean(sex.SelectedIndex);
            this.selected_data.Age = Convert.ToInt32(age.Text);
            this.selected_data.Height = Convert.ToDouble(height.Text);
            this.selected_data.Weight = Convert.ToDouble(weight.Text);
            this.selected_data.Waist_m = Convert.ToDouble(waist_measurement.Text);
            this.selected_data.Neck_m = Convert.ToDouble(neck_measurement.Text);
            this.selected_data.Hip_m = Convert.ToDouble(hip_measurement.Text);
            this.selected_data.BFPercent = Convert.ToDouble(bf_percent.Text);
            this.selected_data.NormalModel = Convert.ToBoolean(model.SelectedIndex);
            this.selected_data.Activity = Convert.ToInt32(ideal_activity_level.SelectedIndex);
            this.selected_data.MealsPerDay = Convert.ToInt32(meals_per_day.SelectedIndex);
            this.selected_data.Goal = Convert.ToInt32(goal.SelectedIndex);
            this.selected_data.LBM = 0;
            this.selected_data.BMR = 0;
            this.selected_data.TDEE = 0;
            this.selected_data.TDEEG = 0;
            this.selected_data.Protein_amount = 0;
            this.selected_data.Fat_amount = 0;
            this.selected_data.Carb_amount = 0;

            lbm.Text = this.selected_data.LBM.ToString();
            bmr.Text = this.selected_data.BMR.ToString();
            tdee.Text = this.selected_data.TDEE.ToString();
            tdeeg.Text = this.selected_data.TDEEG.ToString();
            fat_g.Text = this.selected_data.Fat_amount.ToString();
            protein_g.Text = this.selected_data.Protein_amount.ToString();
            carb_g.Text = this.selected_data.Carb_amount.ToString();

            using (conn = new SQLiteConnection(App.dbLocation))
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