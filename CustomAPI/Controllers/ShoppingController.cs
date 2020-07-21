using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI.Data;
using CustomAPI.Models;
using CustomAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private IShopping _shop;
        public ShoppingController(IShopping shoppingRepo )
        {
            _shop = shoppingRepo;
        }
        // GET: api/Shopping
        //[HttpGet]
        //public IEnumerable<Shopping> Get()
        //{
        //    return _dbContext.Shopping;
        //}

        // GET: api/Shopping/5
        [HttpGet("{id}")]        
        public IActionResult GetItem(int id)
        {
            var item = _shop.GetItem(id);
            if(item == null)
            {
                return NotFound("No Record Found...");
            }

            return Ok(item);
        }

        //Implementation of Search
        [HttpGet("search")]
        public IEnumerable<Shopping> GetSearch(string search)
        {
            var items = _shop.GetSearch(search);
            return items;
        }

        //Implementation of Paging
        [HttpGet("pagination")]
        public IEnumerable<Shopping> GetPagingData(int? pageNumer,int? pageSize)
        {
            return _shop.GetPagingData(pageNumer, pageSize);
        }

        //Implementation of Sorting
        [HttpGet("sort")]        
        public IEnumerable<Shopping> GetSortedItem(string sortPrice)
        {
            return _shop.GetSortedItem(sortPrice);
        }

        // POST: api/Shopping
        [HttpPost]
        public IActionResult Post([FromBody] Shopping item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _shop.AddItem(item);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Shopping/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Shopping item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!= item.ShoppingId)
            {
                return BadRequest();
            }
            try
            {
                _shop.Update(item);
            }
            catch(Exception ex)
            {
                return NotFound("Item not found..");
            }
            return Ok("Successfully Updated ...");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _shop.GetItem(id);
            if (item == null)
            {
                return NotFound("No Record Found...");
            }
            _shop.DeleteItem(item);
            return Ok("Deleted Successfully...");
        }
    }
}
