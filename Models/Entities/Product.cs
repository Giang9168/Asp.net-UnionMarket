using System.ComponentModel.DataAnnotations;

namespace UnionMarket.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

    }
}
