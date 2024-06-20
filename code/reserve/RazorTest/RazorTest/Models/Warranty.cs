
namespace RazorTest.Models
{
    public class Warranty
    {
        public string WarrantyId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
