using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public interface IBuyerService
    {
        public Task<Buyer> PostBuyerToDb(BuyerRequest buyer);
    }
}