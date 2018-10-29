using Cinema_ERM.xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_ERM.xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        HttpClient client = new HttpClient();
        public async Task GuardarLoginAsync(Iniciousuario item, bool isNewItem = false)
        {
            var uri = new Uri("https://misapis.azurewebsites.net");

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "api/Seguridad");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PostAsync(uri, content);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"Login successfully saved.");

            }
        }
        async void Continuar(object sender, EventArgs e)
        {
            var usuario = new Iniciousuario
            {
                Usuario = usuarioentry.Text,
                Password = Passwordentry.Text
            };

            var isValid = AreCredentialsCorrect(usuario);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new CarteleraPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                Label1.Text = "El Usuario No Es Permitido";
                Passwordentry.Text = string.Empty;
            }
        }


        bool AreCredentialsCorrect(Iniciousuario usuario)
        {
            return usuario.Usuario == Requerimientos.Username && usuario.Password == Requerimientos.Password;

        }
    }
}