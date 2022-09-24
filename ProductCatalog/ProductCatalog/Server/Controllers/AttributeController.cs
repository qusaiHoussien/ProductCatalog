using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Server.Data;
using Microsoft.AspNetCore.Authorization;
using ProductCatalog.Server.IRepository;
using AutoMapper;
namespace ProductCatalog.Server.Controllers
{
   
   [Authorize]
    [Route("api/[controller]")]
    public class AttributeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IAttributeRepository _attributeRepository { get; set; }
        private IMapper _mapper{get; set;}
        public AttributeController(IAttributeRepository attributeRepository,IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper=mapper;
        }

        
        [Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddAttribute([FromBody] AttributeDto attribute)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
            attribute.Name = attribute.Name.ToLower();
            if (await _attributeRepository.AttributeExists(attribute.Name))
                return BadRequest("attribute name is already taken");

            var attributeToSave=_mapper.Map<ProductAttribute>(attribute);    
            await _attributeRepository.Add(attributeToSave);
            return Ok(attribute);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAttribute([FromBody] AttributeDto attribute)
        {
            var attributeToDelete=_mapper.Map<ProductAttribute>(attribute);
            await _attributeRepository.Delete(attributeToDelete);
            return Ok(attribute);
        }


    }
}