/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	2173124
* Date: 		<08> <12> 2024
* Class Name: 	Customers Controller.cs
* Description: 	It's the controller for the Customers project. 
* Time for Task:	5 hours the whole thing. 
    */
using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;
        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult>GetOrdersAsync(int customerId)
        {
            var result= await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
