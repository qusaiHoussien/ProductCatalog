using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProductCatalog.Shared
{
    public class ProductCategoryMapping
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
