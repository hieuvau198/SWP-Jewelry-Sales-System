namespace JewelBO
{
    public class GoldPrice
    {
        public string Name { get; set; } = "Some GoldPrice Name";
        public string Key { get; set; } = "Some GoldPrice Key";
        public double Sell { get; set; }
        public double Buy { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
