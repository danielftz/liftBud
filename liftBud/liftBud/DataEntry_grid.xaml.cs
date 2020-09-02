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
    public partial class DataEntry_grid : ContentPage
    {
        public DataEntry_grid()
        {
            InitializeComponent();
        }


        private void bt_submit_Clicked(object sender, EventArgs e)
        {
            PersonData person_data = new PersonData()
            {
                Id = id.Text,
                Male = Convert.ToBoolean(sex.SelectedIndex),
                Age = Convert.ToInt32(age.Text),
                Height = Convert.ToDouble(height.Text),
                Weight = Convert.ToDouble(weight.Text),
                Waist_m = Convert.ToDouble(waist_measurement.Text),
                Neck_m = Convert.ToDouble(neck_measurement.Text),
                Hip_m = Convert.ToDouble(hip_measurement.Text),
                BFPercent = Convert.ToDouble(bf_percent.Text),
                NormalModel = Convert.ToBoolean(model.SelectedIndex),
                Activity = Convert.ToInt32(ideal_activity_level.SelectedIndex),
                MealsPerDay = Convert.ToInt32(meals_per_day.SelectedIndex),
                Goal = Convert.ToInt32(goal.SelectedIndex),
                CurrentDateTime = DateTime.Now,
                LBM = 0,
                BMR = 0,
                TDEE = 0,
                TDEEG = 0,
                Protein_amount = 0,
                Fat_amount = 0,
                Carb_amount = 0,
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.dbLocation))
            {
                conn.CreateTable<PersonData>();
                var rows = conn.Insert(person_data);
                if (rows > 0) DisplayAlert("Succes", "Successfully added new entry", "OK");
                else DisplayAlert("Failure", "Something went wrong", "OK");
                conn.Close();
            }
        }


        private void bt_auto_macro_Clicked(object sender, EventArgs e)
        {

        }
    }

}