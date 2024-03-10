using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _discountService.TGetListAll();
            return Ok(value);
        }

        [HttpGet("DiscountListUI")]
        public IActionResult DiscountListUI()
        {
            var value = _discountService.TGetListAll().Where(x => x.Status is true);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount
            {
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageURL = createDiscountDto.ImageURL,
                Status = true
            });
            return Ok("Discount section added successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("Discount section has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageURL = updateDiscountDto.ImageURL,
                Status = updateDiscountDto.Status
            });
            return Ok("Discount section has been successfully updated!");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }
    }
}
    