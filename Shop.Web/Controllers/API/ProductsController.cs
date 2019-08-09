using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Controllers.API
{
    using Shop.Web.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productRepository.GetAllWithUser());
        }
    }
}