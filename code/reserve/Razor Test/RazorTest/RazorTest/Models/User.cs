
using System.Text.Json.Serialization;

namespace JewelBO
{
    public class User
    {
        public string UserId {  get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
