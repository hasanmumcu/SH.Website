using SH.Website.Models.ViewModels;
using System.Threading.Tasks;

namespace SH.Website.Services
{
    public interface IFactory
    {
        Task<IndexViewModel> GetIndexViewModel();
        Task<bool> PostContactViewModel(ContactViewModel viewModel);
        Task<bool> PostLoginViewModel(LoginViewModel viewModel);
        Task<bool> PostRegisterViewModel(RegisterViewModel viewModel);

    }
}