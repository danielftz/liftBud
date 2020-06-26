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
    public partial class DataEntry_dev : ContentPage
    {
        private double stepValue = 1;
        public DataEntry_dev()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            PersonData person_data = new PersonData()
            {
                Id = Convert.ToInt32(id.Text),
                Male = sexSwitch.IsToggled,
                Age = Convert.ToInt32(age.Text),
                Height = Convert.ToInt32(height.Text),
                Weight = Convert.ToInt32(weight.Text),
                Measurement1 = Convert.ToDouble(measurement1.Text),
                Measurement2 = Convert.ToDouble(measurement2.Text),
                Measurement3 = Convert.ToDouble(measurement3.Text),
                BFPercent = Convert.ToDouble(bfPercent.Text),
                NormalModel = modeSwitch.IsToggled,
                Activity = Convert.ToInt32(activity.Text),
                MealsPerDay = Convert.ToInt32(mealsPerDay.Text),
                Goal = Convert.ToInt32(goal.Text),
                CurrentDateTime = DateTime.Now,
                LBM = 0,
                BMR = 0,
                TDEE = 0,
                TDEEG = 0,



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
        
        public void OnMacroChnaged(object Sender, ValueChangedEventArgs args)
        {
            var sumPercent = protein_slider.Value + fat_slider.Value + carb_slider.Value;

        }
    }
}