
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaXamarinTotalTech.Interfaces
{
    public interface IGetInformation
    {
        #region Case 
        
        Task Top_rated(IDataResult result);
        Task Upcoming(IDataResult result);
        Task Popular(IDataResult result);

        Task GetMovieDetails(int id, IDataResult result);
        Task GetMovieCredits(int id,IDataResult result);

        #endregion



    }
}
