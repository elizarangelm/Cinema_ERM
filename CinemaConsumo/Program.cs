using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaConsumo
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumir();
        }
    public static void Consumir()
        {
            HttpClient cine = new HttpClient();
            cine.BaseAddress = new Uri("http://misapis.azurewebsites.net");

            var request = cine.GetAsync("/api/Cartelera").Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJSON = request.Content.ReadAsStringAsync().Result;
                var respuesta = JsonConvert.DeserializeObject<List<Cartelera>>(responseJSON);
            }
        }
    }
}
