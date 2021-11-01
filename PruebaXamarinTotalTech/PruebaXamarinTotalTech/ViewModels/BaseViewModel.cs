
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PruebaXamarinTotalTech.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
       



       
        public BaseViewModel()
        {
           
        }

        
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;



      

    }
}
