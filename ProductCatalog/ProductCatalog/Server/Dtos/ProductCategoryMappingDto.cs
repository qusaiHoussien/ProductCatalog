using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class ProductCategoryMappingDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="CategoryId is required")]
        public int CategoryId { get; set; }
        [Required (ErrorMessage ="ProductId is required")]
        public int ProductId { get; set; }
    }
}