using System.ComponentModel.DataAnnotations;

namespace UnionMarket.Validators
{
    public class ProductValidator
    {

        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

    }
}
