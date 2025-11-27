using System.ComponentModel.DataAnnotations;

namespace UnionMarket.Validators
{
    public class LoginValidator
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
         
    }
}
