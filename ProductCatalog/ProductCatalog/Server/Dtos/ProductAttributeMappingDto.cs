using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class ProductAttributeMappingDto
    {
                [Required (ErrorMessage ="ProductId is required")]

        public int ProductId { get; set; }
        [Required (ErrorMessage ="AttributeId is required")]
        public int AttributeId { get; set; }
        [Required (ErrorMessage ="Value is required")]
        public string Value { get; set; }="no value";
    }
}