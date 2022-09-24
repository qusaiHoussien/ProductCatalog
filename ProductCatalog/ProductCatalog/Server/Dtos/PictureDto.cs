using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class PictureDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="productId is required")]
        public int ProductId { get; set; }
        [Required (ErrorMessage ="Image url is required")]
        public string ImgUrl { get; set; }=string.Empty;
        public string Alt { get; set; }="no image";
    }
}