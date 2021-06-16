using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using WebstoreAPI.Contracts;
using WebstoreAPI.Services;

namespace API.Controllers
{
    
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemsService)
        {
            _itemService = itemsService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route(ApiRoutes.Items.GetAll)]
        public async Task<IActionResult> GetItemsResponse()
        {
            var items = await _itemService.GetItemsResponse();
            if (items == null) return NoContent();
            return Ok(items);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route(ApiRoutes.Items.GetPicture)]
        public async Task<IActionResult> GetItemPicture(string id)
        {
            var item = await _itemService.GetItemById(id);
            var image = item.Image;
            return File(image, "image/jpeg");
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route(ApiRoutes.Items.UpdateItem)]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            var updatedItem = await _itemService.EditItem(item);
            if (updatedItem == null) return NotFound();
            return Ok(updatedItem);
        }
    }
}