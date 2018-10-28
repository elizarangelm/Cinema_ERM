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
	public partial class FuncionPage : ContentPage
    {
        {
        Cartelera infopeli;
        public FuncionPage (Cartelera cartelera)
		{
			InitializeComponent ();
            BindingContext = cartelera;
            listFuncion.ItemsSource = cartelera.Funciones;
            infopeli = cartelera;
        }


        private async void FuncionSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            int precio = Convert.ToInt32(MiEntry.Text);
            var funcion = e.SelectedItem as Funciones;
            await Navigation.PushAsync(new ResumenPage(funcion, infopeli, precio));
        }
    }
}