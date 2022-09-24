using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProductCatalog.Shared
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
        public Product Product { get; set; }

    }
}
