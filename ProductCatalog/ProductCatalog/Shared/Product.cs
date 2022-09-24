using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; } = 0.0f;
        public string forSearchByCategory { get; set; } = string.Empty;
        public ICollection<ProductCategoryMapping> productCategoryMapping { get; set; }
        public ICollection<ProductAttributeMapping> productAttributeMapping { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
