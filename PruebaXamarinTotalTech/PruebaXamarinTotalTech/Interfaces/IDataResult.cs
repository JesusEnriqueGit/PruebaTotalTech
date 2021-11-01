using System.Threading.Tasks;

namespace PruebaXamarinTotalTech.Interfaces
{
    public interface IDataResult
    {
        Task OnGetDataResult(object result, string call_type);
        Task OnInsertDataResult(object result, string call_type);
        Task OnErrorResult(string result, string type_error);
    }
}
