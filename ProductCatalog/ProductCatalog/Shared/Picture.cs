using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProductCatalog.Shared
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImgUrl { get; set; }
        public string Alt { get; set; }
        public Product Product { get; set; }

    }
}
