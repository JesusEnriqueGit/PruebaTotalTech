
using PruebaXamarinTotalTech.Interfaces;
using PruebaXamarinTotalTech.Models;
using PruebaXamarinTotalTech.Services;
using PruebaXamarinTotalTech.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaXamarinTotalTech.ViewModels
{
    public class MovieListViewModel : BaseViewModel , IDataResult
    {

        #region Properties
        
        
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnTextFilterChanged(_searchText);

            }
        }
        private bool _flag = true;
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; RaisePropertyChanged(); }
        }
        private MainResultMovieListModel _currentSelected;
        public MainResultMovieListModel CurrentSelected
        {
            get { return _currentSelected; }
            set { _currentSelected = value; RaisePropertyChanged(); }
        }


        #endregion

        #region Commands
        public ICommand ViewDetailsTopCommand { get; set; }
        public ICommand ViewDetailsUpcomingCommand { get; set; }
        public ICommand ViewDetailsPopularCommand { get; set; }

        #endregion

        #region DataCollections
        public ObservableCollection<MainResultMovieListModel> listprovTop { get; set; }
        public ObservableCollection<MainResultMovieListModel> listprovUpComing { get; set; }
        public ObservableCollection<MainResultMovieListModel> listprovPopual { get; set; }

        //Es para el buscador
        private ObservableCollection<MainResultMovieListModel> _upcomingDataCollection;
        public ObservableCollection<MainResultMovieListModel> UpcomingDataCollection
        {
            get { return _upcomingDataCollection; }
            set
            {
                _upcomingDataCollection = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<MainResultMovieListModel> _topReatedDataCollection;
        public ObservableCollection<MainResultMovieListModel> TopReatedDataCollection
        {
            get { return _topReatedDataCollection; }
            set
            {
                _topReatedDataCollection = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<MainResultMovieListModel> _popularDataCollection;
        public ObservableCollection<MainResultMovieListModel> PopularDataCollection
        {
            get { return _popularDataCollection; }
            set
            {
                _popularDataCollection = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Interfaces
        private IGetInformation _getInformationService { get; set; }
       
        #endregion

        public MovieListViewModel()
        {
            
            _getInformationService = new GetInformationService();
            UpcomingDataCollection = new ObservableCollection<MainResultMovieListModel>();
            TopReatedDataCollection = new ObservableCollection<MainResultMovieListModel>();
            PopularDataCollection = new ObservableCollection<MainResultMovieListModel>();
            ViewDetailsTopCommand = new Command(async () => await SelectionChangedTask());
            ViewDetailsUpcomingCommand = new Command(async () => await SelectionChangedTask());
            ViewDetailsPopularCommand = new Command(async () => await SelectionChangedTask());
            Task.Run(async () => await GetMovieList());
            
        }
       
       
     
        private async Task GetMovieList()
        {
            await _getInformationService.Popular(this);
            await _getInformationService.Top_rated(this);
            await _getInformationService.Upcoming(this);
        }

        //Metodo para filtrar los casos en el search 
        public async Task OnTextFilterChanged(string searchtext)
        {
            if (searchtext.Length > 2)
            {
                string firstMayus = searchtext[0].ToString().ToUpper() + searchtext.Substring(1, searchtext.Length - 1);
                var list = UpcomingDataCollection.Where(item => item.title.Contains(searchtext) || item.title.Contains(firstMayus));
                UpcomingDataCollection = new ObservableCollection<MainResultMovieListModel>(list);
                var list1 = TopReatedDataCollection.Where(item => item.title.Contains(searchtext) || item.title.Contains(firstMayus));
                TopReatedDataCollection = new ObservableCollection<MainResultMovieListModel>(list1);
                var list2 = PopularDataCollection.Where(item => item.title.Contains(searchtext) || item.title.Contains(firstMayus));
                PopularDataCollection = new ObservableCollection<MainResultMovieListModel>(list2);
                return;
            }
            else if (searchtext.Length < 3)
            {
                UpcomingDataCollection.Clear();
                TopReatedDataCollection.Clear();
                PopularDataCollection.Clear();
                UpcomingDataCollection = new ObservableCollection<MainResultMovieListModel>(listprovUpComing);
                TopReatedDataCollection = new ObservableCollection<MainResultMovieListModel>(listprovTop);
                PopularDataCollection = new ObservableCollection<MainResultMovieListModel>(listprovPopual);
            }
        }
        private async Task SelectionChangedTask()
        {
         
            if (CurrentSelected.ID != null && CurrentSelected.ID != 0 && Flag)
            {
                Flag = false;
                await App.Current.MainPage.Navigation.PushAsync(new MovieDescriptionView(CurrentSelected.ID));
                Flag = true;
            }
            

        }
        
       
        async Task IDataResult.OnGetDataResult(object result, string call_type)
        {
            switch (call_type)
            {
                case "GET_POPULAR":
                    {
                        if (result != null)
                        {
                            var movielistResult = result as List<MainResultMovieListModel>;
                            PopularDataCollection = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                            listprovPopual = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                        }
                        
                    }
                    break;
                case "GET_UPCOMING":
                    {
                        if (result != null)
                        {
                            var movielistResult = result as List<MainResultMovieListModel>;
                            UpcomingDataCollection = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                            listprovUpComing = new ObservableCollection<MainResultMovieListModel>(movielistResult);

                        }
                    }
                    break;
                case "GET_TOP_RATED":
                    {
                        if (result != null)
                        {                           
                            var movielistResult = result as List<MainResultMovieListModel>;
                            TopReatedDataCollection = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                            listprovTop = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                        }
                        
                    }
                    break;


                default:
                    break;
            }
        }

        public Task OnInsertDataResult(object result, string call_type)
        {
            throw new System.NotImplementedException();
        }

        public Task OnErrorResult(string result, string type_error)
        {
            throw new System.NotImplementedException();
        }
    }
}
