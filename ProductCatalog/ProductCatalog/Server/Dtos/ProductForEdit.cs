using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class ProductForEdit
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is required")]
        public string Name { get; set; } = String.Empty;
        [Required (ErrorMessage ="Description is required")]
        public string Description { get; set; } = String.Empty;
        [Required (ErrorMessage ="Price is required")]
        public float Price { get; set; }=0.0f;
    }
}