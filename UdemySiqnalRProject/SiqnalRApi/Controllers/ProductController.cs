using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                ImageURL = createProductDto.ImageURL,
                Price = createProductDto.Price,
                ProductStatus = true
            });
            return Ok("Product section added successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Product section has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                ImageURL = updateProductDto.ImageURL,
                Price = updateProductDto.Price,
                ProductStatus = updateProductDto.ProductStatus
            });
            return Ok("Product section has been successfully updated!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
    }
}
