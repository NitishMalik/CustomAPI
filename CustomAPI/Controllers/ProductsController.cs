using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomAPI.Controllers
{    
    [ApiController]
    [Route("[controller]")]    
    public class ProductsController : ControllerBase
    {
        List<Product> _products = new List<Product>()
        {
            new Product(){ProductID =1 , ProductName="Photo Frame", Description="Used for Display"},
            new Product(){ProductID =1 , ProductName="Study Table", Description="Used for Sitting"}
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("LoadWelcome")]
        public IActionResult GetWelcome()
        {
            return Ok("Welcome Nitish Malik");
        }
        [HttpPost]
        public IActionResult PostProduct([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(product);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            _products[id] = product;
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _products.RemoveAt(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}