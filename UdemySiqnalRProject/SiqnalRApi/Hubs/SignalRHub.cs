using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SiqnalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
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

            var totalactiveordercount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTotalActiveOrder", totalactiveordercount);

            var lastorderprice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastorderprice + "₼");

            var totalmoneycaseamount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", totalmoneycaseamount + "₼");

            var menutablecount = _menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menutablecount);
        }
    }
}
