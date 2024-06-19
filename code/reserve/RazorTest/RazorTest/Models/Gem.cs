using System.ComponentModel.DataAnnotations;

namespace RazorTest.Models
{
    public class Gem
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string GemId { get; set; }

        [Required]
        [StringLength(200)]
        public string GemName { get; set; }

        [Required]
        public double GemPrice { get; set; } = 0;
    }
}
