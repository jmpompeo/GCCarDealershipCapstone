using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service.Models;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Service
{
    public interface IDealerService
    {
        Task<DealerModelData> Search(string query);


        Task<DealerModelData> GetDataAsync();

    }
}