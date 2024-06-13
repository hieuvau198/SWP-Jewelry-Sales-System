namespace JewelSystemBE
{
    public class GoldPrice
    {
        public string Name { get; set; } = "Some GoldPrice Name";
        public string Key { get; set; } = "Some GoldPrice Key";
        public decimal Sell { get; set; }
        public decimal Buy { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
