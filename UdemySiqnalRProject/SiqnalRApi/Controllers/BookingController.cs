using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        MailManager mailManager = new MailManager();

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
           
            _bookingService.TAdd(new Booking
            {
                Name = createBookingDto.Name,
                Date = createBookingDto.Date.ToString("MMMM dd, yyyy HH:mm"),
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Status = true
            });
            mailManager.SendMail(createBookingDto.Mail,
                "<!DOCTYPE html>" +
                "<html>" +
                "<body>" +
                "<h2>Reservation received!</h2>" +
                "<br/>" +
                "<h3>" + "Your reservation for date " + createBookingDto.Date.ToString("MMMM dd, yyyy HH:mm") + " has been received." + "</h3>" +
                "</body>" +
                "</html>", 
                "Reservation received");
            return Ok("Booking section added successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Booking section has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
           
            _bookingService.TUpdate(new Booking
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            });
            return Ok("Booking section has been successfully updated!");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
