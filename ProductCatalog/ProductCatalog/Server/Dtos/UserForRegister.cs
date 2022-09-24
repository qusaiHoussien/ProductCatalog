using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Server
{
    public class UserForRegister
    {
        [Required (ErrorMessage ="UserName is required")]
        public string UserName { get; set; }
        [Required (ErrorMessage ="Password is required")]
        public string Password{ get; set; }
    }
}