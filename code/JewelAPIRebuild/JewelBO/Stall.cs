using System.ComponentModel.DataAnnotations;

namespace JewelBO

{
    public class Stall
    {
        [Key]
        public string StallId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string StallName { get; set; } = "Some Stall Name";
        [Required]
        public string StallDescription { get; set; } = "Some Stall Description";
        [Required]
        public string StallType { get; set; } = "None";
        [Required]
        public string StaffId { get; set; } = "Some Staff Id";

    }
}
