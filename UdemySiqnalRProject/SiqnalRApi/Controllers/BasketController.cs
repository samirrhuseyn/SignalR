using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SiqnalRApi.Models;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTable(int id)
        {
            return Ok(_basketService.TGetBasketByTableName(id));
        }

        [HttpGet("GetBasketByMenuTableGroupBy")]
        public IActionResult GetBasketByMenuTableGroupBy()
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x=>x.MenuTables).Select(y=> new ResultBasketListByTable
            {
                MenuTableID = y.MenuTableID,
                BasketID = y.BasketID,
                Count = y.Count,
                MenuTableName = y.MenuTables.Name,
                ProductID = y.ProductID,
                TotalPrice = y.TotalPrice,
            }).ToList().DistinctBy(x=>x.MenuTableName);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(x => x.MenuTableID == id).Select(z => new ResultBasketListWithProduct
            {
                BasketID = z.BasketID,
                Count = z.Count,
                TotalPrice = z.TotalPrice,
                MenuTableID = z.MenuTableID,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName,
                ProductPrice = z.Product.Price
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                Count = 1,
                MenuTableID = 6,
                TotalPrice = 0,
                ProductID = createBasketDto.ProductID
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Basket section has been deleted successfully!");
        }
    }
}
