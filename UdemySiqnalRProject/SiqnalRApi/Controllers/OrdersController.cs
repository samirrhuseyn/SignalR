﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

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
    }
}