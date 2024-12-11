/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	2173124
* Date: 		<08> <12> 2024
* Class Name: 	CustomersController.cs
* Description: 	It's the controller for the Customers project. 
* Time for Task:	5 hours the whole thing. 
    */
using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider =customersProvider;
        }
        [HttpGet]
        public async Task<IActionResult>GetCustomersAsync()
        {
            var result =await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
               return Ok(result.Customers);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCustomerAsync(int id)
        {
            var result  = await customersProvider.GetCustomerAsync(id);
            if(result.IsSuccess)
            {
               return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
