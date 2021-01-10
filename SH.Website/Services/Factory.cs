
using AutoMapper;
using SH.Website.Models;
using SH.Website.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SH.Website.Services
{
    public class Factory : IFactory
    {
        protected IDAL _dal;
        protected Timer _timer;
        protected IMapper _mapper;
        public Factory(IDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;

        }
        
        public async Task<IndexViewModel> GetIndexViewModel()
        {
            var model = await _dal.GetIndexModel();

            var viewModels = new List<PartialViewModel>();

            foreach (var item in model.Partials)
            {
                if (item.Active)
                {
                    viewModels.Add(new PartialViewModel
                    {
                        PartialName = item.PartialName,
                        Order = item.Order
                        // Mode = *SomeObject*
                    });
                }
            }

            return new IndexViewModel
            {
                Partials = viewModels.ToArray()
            };
        }

        public async Task<bool> PostContactViewModel(ContactViewModel viewModel)
        {
            try
            {
                if (await _dal.PostContact(_mapper.Map<ContactModel>(viewModel)) != null)
                {
                    return true;
                }
            }
            catch 
            {
            }
            return false;
            
        }
        public async Task<bool> PostLoginViewModel(LoginViewModel viewModel)
        {
            try
            {
                if (await _dal.PostLogin(_mapper.Map<LoginModel>(viewModel)) != null)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;

        }
        public async Task<bool> PostRegisterViewModel(RegisterViewModel viewModel)
        {
            try
            {
                if (await _dal.PostRegister(_mapper.Map<RegisterModel>(viewModel)) != null)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;

        }

        public async Task<bool> PostAdminContactViewModel(AdminContactViewModel viewModel)
        {
            try
            {
                if (await _dal.PostAdminContact(_mapper.Map<AdminContactModel>(viewModel)) != null)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;

        }
    }
}
