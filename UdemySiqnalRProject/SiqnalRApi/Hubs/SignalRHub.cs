using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Xml.Linq;

namespace SiqnalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()
        {
            var categorycount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categorycount);

            var activecategorycount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activecategorycount);

            var passivecategorycount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passivecategorycount);

            var productcount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productcount);

            var mostexpensiveproduct = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveMostExpensiveProduct", mostexpensiveproduct);

            var cheapestproduct = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveCheapestProduct", cheapestproduct);

            var totalordercount = _orderService.TTotalOrderDal();
            await Clients.All.SendAsync("ReceiveTotalOrder", totalordercount);

            var nowwatch = DateTime.Now.ToString("MMMM dd, yyyy  dddd HH:mm");
            await Clients.All.SendAsync("ReceiveWatch", nowwatch);

            string api = "13749a3611369eedf0e43632840b5a4f";
            string city = "Jalilabad";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=en&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            var weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var weathertype = document.Descendants("weather").ElementAt(0).Attribute("value").Value;

            var weathertemp = weather;
            await Clients.All.SendAsync("ReceiveWeatherTemp", weathertemp + "°C") ;

            var weathertypes = weathertype;
            await Clients.All.SendAsync("ReceiveWeatherType", weathertypes);

            var totalactiveordercount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTotalActiveOrder", totalactiveordercount);

            var totalmoneycaseamount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", "₼ " + totalmoneycaseamount);

            var menutablecount = _menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menutablecount);
        }

        public async Task GetBookingList()
        {
            var bookinglist = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", bookinglist);
        }

        
        public async Task SendNotifications()
        {
            var falsenotificationcount = _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveFalseNotificationCount", falsenotificationcount);

            var falsenotificationcounttitle = _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveFalseNotificationCountTitle", falsenotificationcounttitle);

            var falsenotificationlist = _notificationService.TGetListAll();
            await Clients.All.SendAsync("ReceiveFalseNotificationList", falsenotificationlist);
        }
    }
}
