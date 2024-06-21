namespace JewelSystemBE
{
    public class GoldPriceData
    {
        public int Row { get; set; }
        public string Name { get; set; } = "Some GoldPriceData Name";
        public string Karat { get; set; } = "Some GoldPriceData Karat";
        public double Purity { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double SpotPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
