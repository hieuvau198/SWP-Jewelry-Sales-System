
namespace RazorTest.Models
{
    public class Stall
    {
        public string StallId { get; set; } = Guid.NewGuid().ToString();
        public string StallName { get; set; } = "Some Stall Name";
        public string StallDescription { get; set; } = "Some Stall Description";
        public string StallType { get; set; } = "None";
        public string UserId { get; set; } = "Some Staff Id";
        public string StaffName { get; set; } = "Some Staff Name";
    }
}
