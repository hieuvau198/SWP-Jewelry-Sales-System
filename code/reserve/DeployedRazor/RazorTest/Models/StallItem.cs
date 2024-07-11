namespace RazorTest.Models
{
    public class StallItem
    {
        public string StallItemId { get; set; } = Guid.NewGuid().ToString();
        public string StallId { get; set; } = "Some Stall ID";
        public string ProductId { get; set; } = "Some Product Id";
        public string ProductName { get; set; } = "Some Product Name";
        public int quantity { get; set; } = 0;
    }
}
