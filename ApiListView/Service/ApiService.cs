using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ApiListView.Model;
using Newtonsoft.Json;

namespace ApiListView.Service
{
    public class ApiService
    {
        private const string Url_API = "https://jsonplaceholder.typicode.com/photos";

        public List<Photo> GetPhotoMock()
        {
            var lst = new List<Photo>();

            lst.Add(new Photo() { Title = "Praia 1", Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTDCn0frTG4GSPuvc5Rn95VqQHuJy2J8IhWaFsJAgDhZYffFPJG" });
            lst.Add(new Photo() { Title = "Praia 2", Url = "https://upload.wikimedia.org/wikipedia/commons/7/79/PE_-_Jaboat%C3%A3o_dos_Guararapes_-_Praia_de_Piedade_1.jpg" });
            lst.Add(new Photo() { Title = "Praia 3", Url = "https://upload.wikimedia.org/wikipedia/commons/c/ca/Praia_de_Candeias.jpg" });

            return lst;
        }

        public List<Photo> GetPhotoApi(int porPagina)
        {
            var client = new WebClient();
            var response = client.DownloadString(new Uri(Url_API));

            var lst = JsonConvert.DeserializeObject<List<Photo>>(response);

            return lst.Take(porPagina).ToList();
        }
    }
}