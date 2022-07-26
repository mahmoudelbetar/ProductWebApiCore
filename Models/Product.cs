using System.ComponentModel.DataAnnotations;

namespace Day1Lab.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        public string Description { get; set; }

        [Required]
        [Range(50, 1000)]
        public int Price { get; set; }
    }
}
