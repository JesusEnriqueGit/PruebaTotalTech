

using Nancy.Json;
using Newtonsoft.Json;
using PruebaXamarinTotalTech.Interfaces;
using PruebaXamarinTotalTech.Models;
using PruebaXamarinTotalTech.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PruebaXamarinTotalTech.Services
{
    public class GetInformationService : BaseViewModel, IGetInformation
    {
        async Task IGetInformation.Popular(IDataResult result)
        {
            try
            {
                ImageSource Image;
                ImageSource ImageStar = ""; 
                List<ResultsModel> ResultList = new List<ResultsModel>();
                List<MainResultMovieListModel> MainList = new List<MainResultMovieListModel>();

                PopularModel MovieInformation = new PopularModel();
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString("https://api.themoviedb.org/3/movie/popular?api_key=663b4e172550da8b4a630ac0eb664e01");
                    MovieInformation = JsonConvert.DeserializeObject<PopularModel>(json);
                }

                ResultList.AddRange(MovieInformation.results);

                foreach (ResultsModel item in ResultList)
                {
                    if (MainList.Count < 10)
                    {
                        using (var wc = new System.Net.WebClient())
                        {
                            byte[] buffer;
                            buffer = wc.DownloadData("https://image.tmdb.org/t/p/original" + item.poster_path);
                            Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                        }
                        if (item.vote_average < 1)
                        {
                            ImageStar = "star_cero.png";
                        }
                        if (item.vote_average >= 2)
                        {
                            ImageStar = "star_uno.png";
                        }
                        if (item.vote_average >= 4)
                        {
                            ImageStar = "star_dos.png";
                        }
                        if (item.vote_average >= 6)
                        {
                            ImageStar = "star_tres.png";
                        }
                        if (item.vote_average >= 8)
                        {
                            ImageStar = "star_cuatro.png";
                        }
                        if (item.vote_average == 10)
                        {
                            ImageStar = "star_cinco.png";
                        }
                        MainList.Add(new MainResultMovieListModel
                        {
                            ID = item.id,
                            posterImage = Image,
                            title = item.title,
                            popularity = ImageStar
                        });
                    }
                    
                }
                await result.OnGetDataResult(MainList, "GET_POPULAR");
            }

            catch (Exception exc)
            {
                await result.OnErrorResult(exc.ToString(), "GET_POPULAR");
            }
        }

        async Task IGetInformation.Upcoming(IDataResult result)
        {
            try
            {
                ImageSource Image;
                ImageSource ImageStar = "";
                List<ResultsModel> ResultList = new List<ResultsModel>();
                List<MainResultMovieListModel> MainList = new List<MainResultMovieListModel>();

                UpComingModel MovieInformation = new UpComingModel();
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString("https://api.themoviedb.org/3/movie/upcoming?api_key=663b4e172550da8b4a630ac0eb664e01");
                    MovieInformation = JsonConvert.DeserializeObject<UpComingModel>(json);
                }

                ResultList.AddRange(MovieInformation.results);

                foreach (ResultsModel item in ResultList)
                {
                    if (MainList.Count < 10)
                    {
                        using (var wc = new System.Net.WebClient())
                        {
                            byte[] buffer;
                            buffer = wc.DownloadData("https://image.tmdb.org/t/p/original" + item.poster_path);
                            Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                        }

                        if (item.vote_average < 1)
                        {
                            ImageStar = "star_cero.png";
                        }
                        if (item.vote_average >= 2)
                        {
                            ImageStar = "star_uno.png";
                        }
                        if (item.vote_average >= 4)
                        {
                            ImageStar = "star_dos.png";
                        }
                        if (item.vote_average >= 6)
                        {
                            ImageStar = "star_tres.png";
                        }
                        if (item.vote_average >= 8)
                        {
                            ImageStar = "star_cuatro.png";
                        }
                        if (item.vote_average == 10)
                        {
                            ImageStar = "star_cinco.png";
                        }
                        MainList.Add(new MainResultMovieListModel
                        {
                            ID = item.id,
                            posterImage = Image,
                            title = item.title,
                            popularity = ImageStar
                        });
                    }
                    
                }
                await result.OnGetDataResult(MainList, "GET_UPCOMING");
            }

            catch (Exception exc)
            {
                await result.OnErrorResult(exc.ToString(), "GET_UPCOMING");
            }
        }

        async Task IGetInformation.Top_rated(IDataResult result)
        {
            try
            {
                ImageSource Image;
                ImageSource ImageStar = "";
                List<ResultsModel> ResultList = new List<ResultsModel>();
                List<MainResultMovieListModel> MainList = new List<MainResultMovieListModel>();

                TopRatedModel MovieInformation = new TopRatedModel();
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString("https://api.themoviedb.org/3/movie/top_rated?api_key=663b4e172550da8b4a630ac0eb664e01");
                    MovieInformation = JsonConvert.DeserializeObject<TopRatedModel>(json);
                }

                ResultList.AddRange(MovieInformation.results);

                foreach (ResultsModel item in ResultList)
                {
                    if (MainList.Count < 10)
                    {
                        using (var wc = new System.Net.WebClient())
                        {
                            byte[] buffer;
                            buffer = wc.DownloadData("https://image.tmdb.org/t/p/original" + item.poster_path);
                            Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                        }

                        if (item.vote_average < 1)
                        {
                            ImageStar = "star_cero.png";
                        }
                        if (item.vote_average >= 2)
                        {
                            ImageStar = "star_uno.png";
                        }
                        if (item.vote_average >= 4)
                        {
                            ImageStar = "star_dos.png";
                        }
                        if (item.vote_average >= 6)
                        {
                            ImageStar = "star_tres.png";
                        }
                        if (item.vote_average >= 8)
                        {
                            ImageStar = "star_cuatro.png";
                        }
                        if (item.vote_average == 10)
                        {
                            ImageStar = "star_cinco.png";
                        }
                        MainList.Add(new MainResultMovieListModel
                        {
                            ID = item.id,
                            posterImage = Image,
                            title = item.title,
                            popularity = ImageStar
                        });
                    }
                    
                }

                

                await result.OnGetDataResult(MainList, "GET_TOP_RATED");
            }

            catch (Exception exc)
            {
                await result.OnErrorResult(exc.ToString(), "GET_TOP_RATED");
            }

        }

        async Task IGetInformation.GetMovieDetails(int id, IDataResult result)
        {
            try
            {
                ImageSource Image;
                ImageSource ImageStar = "";                
                MainResultMovieListModel MainList = new MainResultMovieListModel();

                MovieDetailModel MovieInformation = new MovieDetailModel();
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString("https://api.themoviedb.org/3/movie/"+id+"?api_key=663b4e172550da8b4a630ac0eb664e01");
                    MovieInformation = JsonConvert.DeserializeObject<MovieDetailModel>(json);
                }

                using (var wc = new System.Net.WebClient())
                {
                    byte[] buffer;
                    buffer = wc.DownloadData("https://image.tmdb.org/t/p/original" + MovieInformation.poster_path);
                    Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                }

                if (MovieInformation.vote_average < 1)
                {
                    ImageStar = "star_cero.png";
                }
                if (MovieInformation.vote_average >= 2)
                {
                    ImageStar = "star_uno.png";
                }
                if (MovieInformation.vote_average >= 4)
                {
                    ImageStar = "star_dos.png";
                }
                if (MovieInformation.vote_average >= 6)
                {
                    ImageStar = "star_tres.png";
                }
                if (MovieInformation.vote_average >= 8)
                {
                    ImageStar = "star_cuatro.png";
                }
                if (MovieInformation.vote_average == 10)
                {
                    ImageStar = "star_cinco.png";
                }


                MainList.posterImage = Image;
                MainList.title = MovieInformation.title;
                MainList.popularity = ImageStar;
                MainList.Description = MovieInformation.overview;
                MainList.Genres = MovieInformation.genres;
                MainList.Relase = MovieInformation.release_date;
                MainList.Studio = MovieInformation.production_companies;
                





                await result.OnGetDataResult(MainList, "GET_DETAILS");
            }

            catch (Exception exc)
            {
                await result.OnErrorResult(exc.ToString(), "GET_DETAILS");
            }
        }

        async Task IGetInformation.GetMovieCredits(int id, IDataResult result)
        {
            try
            {
                ImageSource Image;
                ImageSource ImageStar = "";
                List<CastModel> ResultList = new List<CastModel>();
                List < MainResultMovieListModel> MainList = new List<MainResultMovieListModel>();

                MovieDetailCreditsModel MovieInformation = new MovieDetailCreditsModel();
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString("https://api.themoviedb.org/3/movie/" + id + "/credits?api_key=663b4e172550da8b4a630ac0eb664e01");
                    MovieInformation = JsonConvert.DeserializeObject<MovieDetailCreditsModel>(json);
                }
                ResultList.AddRange(MovieInformation.cast);
                
                foreach (CastModel item in ResultList)
                {

                    if (MainList.Count < 5)
                    {
                        using (var wc = new System.Net.WebClient())
                        {
                            byte[] buffer;
                            buffer = wc.DownloadData("https://image.tmdb.org/t/p/w500" + item.profile_path);
                            Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                        }

                        MainList.Add(new MainResultMovieListModel
                        {
                            posterImage = Image,
                            title = item.name

                        });
                    }
                        
                }
                    await result.OnGetDataResult(MainList, "GET_CAST");
            }

            catch (Exception exc)
            {
                await result.OnErrorResult(exc.ToString(), "GET_CAST");
            }
        }
    }
}
