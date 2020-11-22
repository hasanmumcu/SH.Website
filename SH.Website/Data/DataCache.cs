using SH.Website.Models.ViewModels;
using SH.Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SH.Website.Data
{
    public class DataCache : IDisposable, IDataCache
    {
        protected Timer _timer;
        protected IFactory _factory;
        protected IndexViewModel _indexViewModel;
        private volatile bool _isCacheRunning;
        public DataCache(IFactory factory)
        {
            _factory = factory;
            _timer = new Timer(async (s) =>
            {
                if (!_isCacheRunning)
                {
                    _isCacheRunning = true;
                    await TimerTick(s);
                    _isCacheRunning = false;

                }
            }, null, 0, 3600);
        }

        protected virtual async Task TimerTick(object state)
        {

            _indexViewModel = await _factory.GetIndexViewModel();

        }

        public async Task<IndexViewModel> GetIndexViewModel()
        {
            if (_indexViewModel == null)
            { 
            _indexViewModel = await _factory.GetIndexViewModel();
            
            }
            return _indexViewModel;
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }
    }
}
