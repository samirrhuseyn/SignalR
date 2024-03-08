using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;
using SiqnalRApi.Models;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var context = new SignalRContext();
            var values = context.Orders.OrderByDescending(x => x.Date).Include(x => x.MenuTable).Select(y => new ResultOrdersWithMenuTable
            {
                OrderID = y.OrderID,
                Date = y.Date,
                Description = y.Description,
                MenuTableID = y.MenuTableID,
                MenuTableName = y.MenuTable.Name,
                TotalPrice = y.TotalPrice
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            _orderService.TAdd(new Order
            {
                MenuTableID = createOrderDto.MenuTableID,
                Description = "Custumer at the table",
                Date = createOrderDto.Date,
                TotalPrice = 0,
            });
            return Ok("Addition successfuly!");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("TotalOrderCount")]
        public ActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderDal());
        }

        [HttpGet("ActiveOrderCount")]
        public ActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public ActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayTotalEarning")]
        public ActionResult TodayTotalEarning()
        {
            return Ok(_orderService.TTodayTotalEarning());
        }

        [HttpPut("{id}")]
        public IActionResult CloseInvoice(int id)
        {
            var value = _orderService.TGetByID(id);
            value.Description = "Invoice paid";
            _orderService.TUpdate(value);
            return Ok("Update successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _orderService.TGetByID(id);
            _orderService.TDelete(value);
            return Ok("Order section has been deleted successfully!");
        }
    }
}
