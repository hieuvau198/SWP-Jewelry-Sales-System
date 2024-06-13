using System.ComponentModel.DataAnnotations;

namespace JewelSystemBE.Model
{
    public class User
    {
        [Key]
        public string UserId {  get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Username { get; set; } = "Some Username";
        [Required]
        public string Password { get; set; } = "Some Password";
        [Required]
        public string Fullname { get; set; } = "Some Fullname";
        [Required]
        public string Email { get; set; } = "Some Email";
        [Required]
        public string Role { get; set; } = "Sale";
    }
}
