using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is required")]
        public string Name { get; set; }=string.Empty;
        [Required (ErrorMessage ="Description is required")]
        public string Description { get; set; }=string.Empty;
    }
}