using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Server.IRepository;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
namespace ProductCatalog.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController: Microsoft.AspNetCore.Mvc.Controller
    {
        public IProductRepository _productRepository { get; set; }
        private IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper=mapper;
        }

        [AllowAnonymous]
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int CategoryId)
        {
            var products=await _productRepository.GetProductsByCategory(CategoryId);
            var productsToReturn=_mapper.Map<List<ProductForAdd>>(products);
            return Ok(productsToReturn);
        }
        
        [Authorize(Roles="Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody]ProductForAdd product )
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var productToAdd=_mapper.Map<Product>(product);
            await _productRepository.Add(productToAdd);
            return Ok(productToAdd);

        }

        [Authorize(Roles="Admin")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] ProductForEdit product)
        {
            var productToDelete=_mapper.Map<Product>(product);
            await _productRepository.Delete(productToDelete);
            return Ok(productToDelete);
        }

        [Authorize(Roles="Admin")]
        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] ProductForEdit product)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var productToEdit=_mapper.Map<Product>(product);
            await _productRepository.Edit(productToEdit);
            return Ok(productToEdit);
        }

        [Authorize(Roles="Admin")]
        [HttpPost("addAttribute")]
        public async Task<IActionResult> AddAttributesToProduct([FromBody]List<ProductAttributeMappingDto> productAttributeMapping )
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var attributesToAdd=_mapper.Map<List<ProductAttributeMapping>>(productAttributeMapping);
            await _productRepository.AddAttributesToProduct(attributesToAdd);
            return Ok(productAttributeMapping);

        }
    }
}
