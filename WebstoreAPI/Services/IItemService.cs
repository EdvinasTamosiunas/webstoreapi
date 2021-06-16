using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public interface IItemService
    {
        public Task<List<ItemResponse>> GetItemsResponse();
        public Task<Item> GetItemById(string id);
        public Task<Item> EditItem(Item item);
    }
}