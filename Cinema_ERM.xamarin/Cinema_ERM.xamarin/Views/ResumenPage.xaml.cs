using Cinema_ERM.xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_ERM.xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResumenPage : ContentPage
	{
		public ResumenPage (Funciones funcion,Cartelera cartelera, int precio )
		{
            int valor = precio * (funcion.Precio);
            InitializeComponent ();
            infopeli.BindingContext = funcion;
            resumenpeli.BindingContext = cartelera;
            lbl1.Text = Convert.ToString(precio);
            lbl1.Text = Convert.ToString(valor);
        }
        private void Finalizar(object sender, EventArgs e)
        {
            DisplayAlert("Reserva", "“La reserva se ha generado correctamente", "Finalizar");
        }
    }
}