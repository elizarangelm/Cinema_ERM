using Cinema_ERM.xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_ERM.xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarteleraPage : ContentPage
	{
		public CarteleraPage ()
		{
			InitializeComponent ();
            CargarPeliculas();
		}

        private async void CargarPeliculas()
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");
            var request = await cliente.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var cartelera = JsonConvert.DeserializeObject<List<Cartelera>>(responseJson);
                listCartelera.ItemsSource = cartelera;
            }
        }


        private async void PeliculaSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            var cartelera= e.SelectedItem as Cartelera;
            await Navigation.PushAsync(new FuncionPage(cartelera));

        }
    }
}