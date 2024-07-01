namespace JewelSystemBE.Model
{
    public class StallEmployee
    {
        public string StallEmployeeId { get; set; } = Guid.NewGuid().ToString();
        public string StallId { get; set; } = "Not yet";
        public string StallName { get; set; } = "Not yet";
        public string EmployeeId { get; set; } = "Not yet";
        public string EmployeeFullname { get; set; } = "Not yet";
        public string Role { get; set; } = "Not yet";
    }
}
