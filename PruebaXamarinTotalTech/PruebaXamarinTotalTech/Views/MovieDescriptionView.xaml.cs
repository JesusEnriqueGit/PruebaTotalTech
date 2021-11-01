using PruebaXamarinTotalTech.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaXamarinTotalTech.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDescriptionView : ContentPage
    {
        public MovieDescriptionView(int ID)
        {
            BindingContext = new MovieDescriptionViewModel(ID);
            InitializeComponent();
        }
    }
}