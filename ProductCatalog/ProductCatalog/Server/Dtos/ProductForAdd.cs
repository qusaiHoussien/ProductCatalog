using System.ComponentModel.DataAnnotations;


namespace ProductCatalog.Server
{
    public class ProductForAdd
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="category is required")]
        public string Name { get; set; } = String.Empty;
        [Required (ErrorMessage ="category is required")]
        public string Description { get; set; } = String.Empty;
        [Required (ErrorMessage ="category is required")]
        public float Price { get; set; }=0.0f;
        public ICollection<PictureDto> Pictures { get; set; }
        [Required (ErrorMessage ="category is required")]
        public ICollection<ProductCategoryMappingDto> productCategoryMapping { get; set; }
        public ICollection<ProductAttributeMappingDto> productAttributeMapping { get; set; }    }
}