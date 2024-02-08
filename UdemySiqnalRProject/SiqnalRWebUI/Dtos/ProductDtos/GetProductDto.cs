﻿namespace SiqnalRWebUI.Dtos.ProductDtos
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
    }
}
