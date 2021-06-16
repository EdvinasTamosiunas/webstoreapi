using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.EntityFrameworkCore;
using WebstoreAPI.Contracts;

namespace WebstoreAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly DatabaseContext _context;

        public ItemService(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<ItemResponse>> GetItemsResponse()
        {
            var items = await _context.Items.ToListAsync();

            return items.Select(item => new ItemResponse(item)).ToList();
        }

        public async Task<ItemResponse> GetItemResponseById(string id)
        {
            var item = await _context
                .Items
                .SingleOrDefaultAsync(entity => entity.Id == id);

            var itemResponse = new ItemResponse(item);
            return itemResponse;
        }

        public async Task<Item> GetItemById(string id)
        {
            var item = await _context
                .Items
                .SingleOrDefaultAsync(entity => entity.Id == id);

            return item;
        }

        public async Task<Item> EditItem(Item itemRequest)
        {
            var item = await _context.Items.SingleOrDefaultAsync(entity => entity.Id == itemRequest.Id);
            var updateItem = new Item(item, itemRequest);
            _context.Items.Remove(item);
            await _context.Items.AddAsync(updateItem);
            await _context.SaveChangesAsync();
            return updateItem;
        }
    }
}