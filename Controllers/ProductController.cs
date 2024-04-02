using GenericProject.Model;
using GenericProject.Repository;
using GenericProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest product)
        {
            var productEntity = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,

            };
            var AddedProduct = await _productRepository.AddAsync(productEntity);
            return Ok(new
            {
                AddedProduct,
                message = "Product Added Successfully"
            });
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] ProductRequest product, int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            productEntity.ProductName = product.ProductName;
            productEntity.Price = product.Price;
            await _productRepository.UpdateAsync(productEntity);
            return Ok(new
            {
                message="Product Updated Successfully"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(product);
            return Ok(new
            {
                message="Product Deleted Successfully"
            });
        }

    }
}
