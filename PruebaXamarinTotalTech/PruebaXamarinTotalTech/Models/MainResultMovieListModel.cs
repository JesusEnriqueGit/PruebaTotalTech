using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PruebaXamarinTotalTech.Models
{
    public class MainResultMovieListModel
    {
        public int ID { get; set; } = 0;
        public ImageSource posterImage { get; set; }

        public string title { get; set; }

        public ImageSource popularity { get; set; }

        public string Description { get; set; }
        public string Relase { get; set; }

        public List<ProductionCompanies> Studio { get; set; }
        public List<Genres> Genres { get; set; }
    }
}
