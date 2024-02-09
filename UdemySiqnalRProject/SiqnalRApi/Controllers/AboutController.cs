using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.CategoryDto;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TAdd(new About 
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageURL = createAboutDto.ImageURL
            });
            return Ok("About me section added successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id) 
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("About me section has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            _aboutService.TUpdate(new About
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageURL = updateAboutDto.ImageURL
            });
            return Ok("About me section has been successfully updated!");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
