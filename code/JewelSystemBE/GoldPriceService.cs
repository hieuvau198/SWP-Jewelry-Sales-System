using System.Xml.Linq;

namespace JewelSystemBE
{
    public class GoldPriceService
    {
        private readonly HttpClient _httpClient;

        public GoldPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GoldPrice>> GetGoldPricesAsync()
        {
            var goldPrices = new List<GoldPrice>();
            var response = await _httpClient.GetStringAsync("http://giavang.doji.vn/api/giavang/?api_key=258fbd2a72ce8481089d88c678e9fe4f");

            var xmlDoc = XDocument.Parse(response);

            foreach (var element in xmlDoc.Descendants("Row"))
            {
                var sellString = element.Attribute("Sell")?.Value.Replace(",", "");
                var buyString = element.Attribute("Buy")?.Value.Replace(",", "");

                decimal sell = 0;
                decimal buy = 0;

                if (!string.IsNullOrEmpty(sellString) && sellString != "-")
                {
                    sell = decimal.Parse(sellString);
                }

                if (!string.IsNullOrEmpty(buyString) && buyString != "-")
                {
                    buy = decimal.Parse(buyString);
                }

                var goldPrice = new GoldPrice
                {
                    Name = element.Attribute("Name")?.Value,
                    Key = element.Attribute("Key")?.Value,
                    Sell = sell,
                    Buy = buy,
                    DateTime = DateTime.Now
                };

                goldPrices.Add(goldPrice);
            }
            return goldPrices;
        }
    }
}
