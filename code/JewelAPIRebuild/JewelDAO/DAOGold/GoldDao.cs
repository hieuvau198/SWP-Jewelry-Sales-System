using JewelBO;
using System.Globalization;
using System.Xml.Linq;

namespace JewelDAO.DAOGold
{
    public class GoldDao : IGoldDao
    {
        private readonly JewelDbContext _jewelDbContext;
        private readonly HttpClient _httpClient;

        public GoldDao(JewelDbContext jewelDbContext, HttpClient httpClient)
        {
            this._jewelDbContext = jewelDbContext;
            _httpClient = httpClient;
        }
        public Gold AddGold(Gold gold)
        {
            if (gold == null)
            {
                return null;
            }
            var existingGold = _jewelDbContext.Golds.Find(gold.GoldId);
            if (existingGold != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Golds.Add(gold);
                _jewelDbContext.SaveChanges();
                return gold;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding gold: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Gold>> GetGolds()
        {

            List<Gold> golds = _jewelDbContext.Golds.OrderByDescending(x => x.GoldId).ToList() ?? new List<Gold>();

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
                        sell = double.Parse(sellString, CultureInfo.InvariantCulture) * 100000; // Converting from 'ngàn đồng/lượng' to 'đồng/lượng'
                    }

                    if (!string.IsNullOrEmpty(buyString) && buyString != "-")
                    {
                        buy = double.Parse(buyString, CultureInfo.InvariantCulture) * 100000; // Converting from 'ngàn đồng/lượng' to 'đồng/lượng'
                    }

                    var goldPrice = new GoldPrice
                    {
                        Name = itemElement.Attribute("type")?.Value,
                        Key = $"{cityName}_{itemElement.Attribute("type")?.Value}", // Composite key for uniqueness
                        Sell = sell,
                        Buy = buy,
                        DateTime = DateTime.Now,
                    };

                    Gold gold = golds.Find(x => x.GoldCode.Equals(goldPrice.Name));
                    if (gold != null)
                    {
                        gold.BuyPrice = goldPrice.Buy;
                        gold.SellPrice = goldPrice.Sell;
                        gold.Date = DateTime.Now;
                    }
                    UpdateGold(gold);
                }
            }


            return golds;

        }

        public bool RemoveGold(string goldId)
        {
            if (goldId == null)
            { return false; }
            Gold gold = _jewelDbContext.Golds.Find(goldId);
            if (gold != null)
            {
                _jewelDbContext.Golds.Remove(gold);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateGold(Gold gold)
        {
            if (gold == null)
            { return false; }
            Gold updatedGold = _jewelDbContext.Golds.Find(gold.GoldId);
            if (updatedGold != null)
            {
                updatedGold.GoldName = gold.GoldName;
                updatedGold.SellPrice = gold.SellPrice;
                updatedGold.BuyPrice = gold.BuyPrice;
                updatedGold.Date = gold.Date;
                updatedGold.GoldCode = gold.GoldCode;

                _jewelDbContext.Golds.Update(updatedGold);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Gold GetGold(string goldId)
        {
            return _jewelDbContext.Golds.Find(goldId);
        }
    }
}
