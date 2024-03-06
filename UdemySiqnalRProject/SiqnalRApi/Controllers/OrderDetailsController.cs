using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.OrderDetailsDto;
using SignalR.EntityLayer.Entities;
using SiqnalRApi.Models;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetails(CreateOrderDetailDto createOrderDetailDto)
        {
            _orderDetailService.TAdd(new OrderDetail
            {
                OrderID = createOrderDetailDto.OrderID,
                Count = createOrderDetailDto.Count,
                ProductID = createOrderDetailDto.ProductID,
                TotalPrice = createOrderDetailDto.TotalPrice
            });
            return Ok("Addition successfuly");
        }

        [HttpGet]
        public async Task<IActionResult> GetDetail(int id)
        {
            var context = new SignalRContext();
            var value = context.OrderDetails.Where(x=>x.OrderID  == id).Include(y=>y.Product).Select(z=> new ResultOrderDetailWithProduct
            {
                ProductName = z.Product.ProductName,
                Count = z.Count,
                OrderDetailID = z.OrderDetailID,
                TotalPrice =z.TotalPrice,
                ProductID = z.ProductID,
                OrderID = z.OrderID,
                ProductPrice = z.Product.Price
            });
            return Ok(value.ToList());
        }
    }
}
