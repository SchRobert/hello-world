﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagStore.Service.Data.Items;
using TagStore.Service.Models.Items;

namespace TagStore.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(CancellationToken cancellationToken = default(CancellationToken))
        {
            var items = _repository.FindItems();
            return await items.ToArrayAsync(cancellationToken);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var item = await _repository.GetItemAsync(id, cancellationToken);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateItem(Guid id, Item item)
        //{
        //    if (id != item.ItemId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(item).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Items
        //[HttpPost]
        //public async Task<ActionResult<Item>> AddItem(Item item)
        //{
        //    _context.Items.Add(item);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        //}

        // DELETE: api/Items/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Item>> DeleteItem(Guid id)
        //{
        //    var item = await _context.Items.FindAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Items.Remove(item);
        //    await _context.SaveChangesAsync();

        //    return item;
        //}

        //private bool ItemExists(Guid id)
        //{
        //    return _context.Items.Any(e => e.ItemId == id);
        //}
    }
}
