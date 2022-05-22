using APICrudWithRepository.Models;
using APICrudWithRepository.Models.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productService;

        public ProductController(IProduct productService)
        {
            this.productService = productService;
        }

        
        [HttpGet]
        [Route("GetProductRecord")]
        public IActionResult GetProductRecord()
        {
            var results = productService.GetProducts();
            if (results.Count > 0)
            {
                return Ok(results);
                
            }
            else
            {
                return NotFound("Product not found !");
            }
        }
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult PostProductRecord(Product product)
        {
            var results = productService.PostProduct(product);
            if(results != null)
            {
                return Ok(results);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet]
        [Route("GetProductById/{Id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var results = productService.GetProductById(id);
                if(results != null)
                {
                    return Ok(results);
                }
                else
                {
                    return NotFound("Product not Found");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProductRecord(Product product)
        {
            try
            {
                if(product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var results = productService.UpdateProduct(product);
                    if(results != null)
                    {
                        return Ok(results);
                    }    
                    else
                    {
                        return NotFound();
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                if(Id ==0)
                {
                    return BadRequest();
                }
                else
                {
                    var results = productService.DeleteProduct(Id);
                    if(results != null)
                    {
                        return Ok(results);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
}

        
    }
}
