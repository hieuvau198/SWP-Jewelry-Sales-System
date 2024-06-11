namespace JewelSystemBE
{
    public class GoldPriceData
    {
        public int Row { get; set; }
        public string Name { get; set; }
        public string Karat { get; set; }
        public decimal Purity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal SpotPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
