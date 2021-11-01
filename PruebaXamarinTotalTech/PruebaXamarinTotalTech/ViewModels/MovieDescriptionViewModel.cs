
using PruebaXamarinTotalTech.Interfaces;
using PruebaXamarinTotalTech.Models;
using PruebaXamarinTotalTech.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaXamarinTotalTech.ViewModels
{
    public class MovieDescriptionViewModel : BaseViewModel , IDataResult
    {

        #region Properties
        private TopRatedModel _movieList;
        public TopRatedModel MovieList
        {
            get { return _movieList; }
            set { _movieList = value; RaisePropertyChanged(); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }
        private string _studio;
        public string Studio
        {
            get { return _studio; }
            set { _studio = value; RaisePropertyChanged(); }
        }
        private string _genres;
        public string Genres
        {
            get { return _genres; }
            set { _genres = value; RaisePropertyChanged(); }
        }
        private string _fecha;
        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; RaisePropertyChanged(); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(); }
        }
        private ImageSource _poster;
        public ImageSource Poster
        {
            get { return _poster; }
            set { _poster = value; RaisePropertyChanged(); }
        }
        private ImageSource _raiting;
        public ImageSource Raiting
        {
            get { return _raiting; }
            set { _raiting = value; RaisePropertyChanged(); }
        }


        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }
        
        #endregion

        #region Commands
        public ICommand CaseSelectionChangedCommand { get; set; }
        public ICommand GetAllCasesDataCommand { get; set; }        
        public ICommand GetUserPreferencesCommand { get; private set; }
        #endregion

        #region DataCollections
        

        
        private ObservableCollection<MainResultMovieListModel> _castDataCollection;
        public ObservableCollection<MainResultMovieListModel> CastDataCollection
        {
            get { return _castDataCollection; }
            set
            {
                _castDataCollection = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Interfaces
        private IGetInformation _getInformationService { get; set; }

        #endregion

        public MovieDescriptionViewModel(int id)
        {
            ID = id;
            _getInformationService = new GetInformationService();
            Task.Run(async () => await GetMovieDetails());
            
        }
       
       
       
        //Ejemplo de metodo
        private async Task GetMovieDetails()
        {
            await _getInformationService.GetMovieDetails(ID,this);
          
        }

        
        async Task IDataResult.OnGetDataResult(object result, string call_type)
        {
            switch (call_type)
            {
                case "GET_DETAILS":
                    {
                        if (result != null)
                        {
                            var movielistResult = result as MainResultMovieListModel;
                            Title = movielistResult.title;
                            Description = movielistResult.Description;
                            Poster = movielistResult.posterImage;
                            Raiting = movielistResult.popularity;
                            Fecha = movielistResult.Relase;
                            Studio = movielistResult.Studio[0].name  ;
                            Genres = movielistResult.Genres[0].name + ", " + movielistResult.Genres[1].name + ", " + movielistResult.Genres[2].name;
                        }
                        await _getInformationService.GetMovieCredits(ID, this);
                    }
                    break;
                case "GET_CAST":
                    {
                        if (result != null)
                        {
                            var movielistResult = result as List<MainResultMovieListModel>;
                            CastDataCollection = new ObservableCollection<MainResultMovieListModel>(movielistResult);
                            
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
