using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _testimonialService.TGetListAll();
            return Ok(value);
        }

        [HttpGet("TestimonialListUI")]
        public IActionResult TestimonialListUI()
        {
            var value = _testimonialService.TGetListAll().Where(x=>x.Status is true);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial
            {
                Comment = createTestimonialDto.Comment,
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                ImamgeURL = createTestimonialDto.ImamgeURL,
                Status = true
            });
            return Ok("Testimonial section added successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial section has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                ImamgeURL = updateTestimonialDto.ImamgeURL,
                Status = updateTestimonialDto.Status
            });
            return Ok("Contact section has been successfully updated!");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }
    }
}
