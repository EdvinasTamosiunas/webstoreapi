using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly DatabaseContext _context;

        public BuyerService(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Buyer> PostBuyerToDb(BuyerRequest buyer)
        {
            var newBuyer = new Buyer(buyer);
            _context.Add(newBuyer);
            await _context.SaveChangesAsync();
            return newBuyer;
        }
    }
}