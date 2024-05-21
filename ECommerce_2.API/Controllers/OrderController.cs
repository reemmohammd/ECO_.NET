using ECommerce_2.BL.Dtos.Order;
using ECommerce_2.BL.Manager.Order;
using ECommerce_2.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManeger;
        private readonly UserManager<User2> _userManage;
        public OrderController(IOrderManager orderManeger, UserManager<User2> userManage)
        {
            _orderManeger = orderManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNewOrder(List<AddOrderDto> newOrder)
        {
            User2? user = await _userManage.GetUserAsync(User);


            _orderManeger.AddNewOrder(newOrder, user.Id);


            return Ok("order is added successfully");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrderHistoryDto>>> GetAllOrder()
        {
            User2? user = await _userManage.GetUserAsync(User);

            var orders = _orderManeger.GetAllOrder(user.Id);
            return orders.ToList();
        }

    }
}
