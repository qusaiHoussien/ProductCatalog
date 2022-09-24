using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductCatalog.Server.IRepository;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
namespace ProductCatalog.Server.Controllers
{
   
   [Authorize]
    [Route("api/[controller]")]
    public class PictureController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IPictureRepository _pictureRepository { get; set; }
        private IMapper _mapper{get; set;}
        public PictureController(IPictureRepository pictureRepository,IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper=mapper;
        }

        
        [Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddPicture([FromBody] PictureDto picture)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var pictureToSave=_mapper.Map<Picture>(picture);
            await _pictureRepository.Add(pictureToSave);
            return Ok(pictureToSave);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePicture([FromBody] PictureDto picture)
        {
            var pictureToDelete=_mapper.Map<Picture>(picture);
            await _pictureRepository.Delete(pictureToDelete);
            return Ok(picture);
        }


    }
}