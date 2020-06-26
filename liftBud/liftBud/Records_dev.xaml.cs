using liftBud.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace liftBud
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Records_dev : ContentPage
    {
        private SQLiteConnection conn;
        public Records_dev()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (conn = new SQLiteConnection(App.dbLocation))
            {
                conn.CreateTable<PersonData>();
                var entries = conn.Table<PersonData>().ToList();
                PersonData_List.ItemsSource = entries;
                conn.Close();
            }
        }

        private void PersonData_List_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            PersonData selected_data = PersonData_List.SelectedItem as PersonData;
            if (selected_data != null) Navigation.PushAsync(new DataDetailPage_dev(selected_data));
        }

        private void Reset_Table_Clicked(object sender, EventArgs e)
        {
            using (conn = new SQLiteConnection(App.dbLocation))
            {
                conn.DeleteAll<PersonData>();
                conn.Close();
                
            }


        }
    }
}