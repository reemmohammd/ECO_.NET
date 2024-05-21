using ECommerce_2.BL.Dtos.Cart;
using ECommerce_2.BL.Manager.Cart;
using ECommerce_2.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManeger;
        private readonly UserManager<User2> _userManage;
        public CartController(ICartManager cartManeger, UserManager<User2> userManage)
        {
            _cartManeger = cartManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProductToCart(AddToCartDto addToCartDto)
        {
            User2? user = await _userManage.GetUserAsync(User);

            _cartManeger.AddProductToCart(addToCartDto.ProductId, addToCartDto.Quantity, user.Id);

            return Ok("product is added to cart");

        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveProductFromCart(int id)
        {
            User2? user = await _userManage.GetUserAsync(User);
            _cartManeger.RemoveProductFromCart(id, user.Id);
            return Ok("product is deleted from cart");
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpadteProductQuentity(EditQuantityProCartDto editQuentityProCartDto)
        {
            User2? user = await _userManage.GetUserAsync(User);

            _cartManeger.UpadteProductQuentity(editQuentityProCartDto.ProductId,
             editQuentityProCartDto.Quantity, user.Id);
            return Ok("product  is updated successfully");
        }

    }
}

