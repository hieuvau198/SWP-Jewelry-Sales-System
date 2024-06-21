using System.Globalization;
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
            var response = await _httpClient.GetStringAsync("https://sjc.com.vn/xml/tygiavang.xml");

            var xmlDoc = XDocument.Parse(response);

            foreach (var cityElement in xmlDoc.Descendants("city"))
            {
                var cityName = cityElement.Attribute("name")?.Value;
                foreach (var itemElement in cityElement.Descendants("item"))
                {
                    var sellString = itemElement.Attribute("sell")?.Value.Replace(",", "");
                    var buyString = itemElement.Attribute("buy")?.Value.Replace(",", "");

                    double sell = 0;
                    double buy = 0;

                    if (!string.IsNullOrEmpty(sellString) && sellString != "-")
                    {
                        sell = double.Parse(sellString, CultureInfo.InvariantCulture) * 1000; // Converting from 'ngàn đồng/lượng' to 'đồng/lượng'
                    }

                    if (!string.IsNullOrEmpty(buyString) && buyString != "-")
                    {
                        buy = double.Parse(buyString, CultureInfo.InvariantCulture) * 1000; // Converting from 'ngàn đồng/lượng' to 'đồng/lượng'
                    }

                    var goldPrice = new GoldPrice
                    {
                        Name = itemElement.Attribute("type")?.Value,
                        Key = $"{cityName}_{itemElement.Attribute("type")?.Value}", // Composite key for uniqueness
                        Sell = sell,
                        Buy = buy,
                        DateTime = DateTime.Now,
                    };

                    goldPrices.Add(goldPrice);
                }
            }
            return goldPrices;
        }
    }
}
