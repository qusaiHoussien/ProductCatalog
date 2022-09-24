using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductCatalog.Server.IRepository;
using AutoMapper;
namespace ProductCatalog.Server.Controllers
{
   
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICategoryRepository _categoryRepository { get; set; }
        private IMapper _mapper{get; set;}
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper=mapper;
        }

        [AllowAnonymous]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCategories()
        {
            
                var categories = await _categoryRepository.GetAllCategories();
                var categoriesToReturn=_mapper.Map<List<CategoryDto>>(categories);
                return Ok(categoriesToReturn);
       

        }
        

        [Authorize(Roles="Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto category)
        {
             if(!ModelState.IsValid)
            return BadRequest(ModelState);


            
                category.Name = category.Name.ToLower();
            if (await _categoryRepository.CategoryExists(category.Name))
                return BadRequest("category name is already taken");

            var categoryToSave=_mapper.Map<Category>(category);
            await _categoryRepository.Add(categoryToSave);
            return Ok(categoryToSave);
     
        }

        [Authorize(Roles="Admin")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryDto category)
        {
            var categoryToDelete=_mapper.Map<Category>(category);
            
            
                await _categoryRepository.Delete(categoryToDelete);
  
            return Ok(categoryToDelete);
        }

        [Authorize(Roles="Admin")]
        [HttpPut("edit")]
        public async Task<IActionResult> EditCategory([FromBody] CategoryDto category)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var categoryToEdit=_mapper.Map<Category>(category);
            
                await _categoryRepository.Edit(categoryToEdit);
    
            return Ok(categoryToEdit);
        }
    }
}
