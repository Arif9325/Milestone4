/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	2173124
* Date: 		<08> <12> 2024
* Class Name: 	ProductsController.cs
* Description: 	It's the controller for the Products project. 
* Time for Task:	5 hours the whole thing. 
    */


using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);
            if (result.IsSuccess) 
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
