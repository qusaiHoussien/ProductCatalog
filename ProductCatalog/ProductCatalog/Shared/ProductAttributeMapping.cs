using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProductCatalog.Shared
{
    public class ProductAttributeMapping
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
        public ProductAttribute productAttribute { get; set; }
    }
}
