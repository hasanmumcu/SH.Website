using SH.Website.Models.ViewModels;
using System.Threading.Tasks;

namespace SH.Website.Data
{
    public interface IDataCache
    {
        Task<IndexViewModel> GetIndexViewModel();

        void Dispose();
    }
}