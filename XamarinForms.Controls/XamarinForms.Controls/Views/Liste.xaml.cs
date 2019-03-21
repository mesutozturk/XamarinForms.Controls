using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Model;

namespace XamarinForms.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Liste : ContentPage
    {
        public Liste()
        {
            InitializeComponent();
            LoadData();
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            AlbumView.ItemsSource = model;
        }

        List<AlbumModel> model = new List<AlbumModel>();
        private void LoadData()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://rallycoding.herokuapp.com/api/music_albums")).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<List<AlbumModel>>(responseString);
            int a = 0;
            BindingContext = model;
        }

    }
}