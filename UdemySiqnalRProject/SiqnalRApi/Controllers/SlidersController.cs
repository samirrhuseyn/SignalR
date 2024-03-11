using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SlideDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSlider()
        {
            var value = _sliderService.TGetListAll();
            return Ok(value);
        }

        [HttpGet("GetSliderUI")]
        public IActionResult GetSliderUI()
        {
            var value = _sliderService.TGetListAll().Where(x=>x.Status is true);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSlideDto createSlideDto)
        {
            _sliderService.TAdd(new Slider
            {
                Title = createSlideDto.Title,
                Status = true,
                Description = createSlideDto.Description
            });
            return Ok("Addition Successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSlideDto updateSlideDto)
        {
            _sliderService.TUpdate(new Slider
            {
                Title = updateSlideDto.Title,
                Description = updateSlideDto.Description,
                SliderID = updateSlideDto.SliderID,
                Status = updateSlideDto.Status
            });
            return Ok("Update Successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Deletion successfuly");
        }
    }
}
