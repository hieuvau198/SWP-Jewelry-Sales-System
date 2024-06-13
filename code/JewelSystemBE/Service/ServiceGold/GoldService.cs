using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceGold
{
    public class GoldService : IGoldService
    {
        private readonly JewelDbContext _jewelDbContext;

        public GoldService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
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

        public List<Gold> GetGolds()
        {
            return _jewelDbContext.Golds.OrderByDescending(x => x.GoldId).ToList();
        }

        public bool RemoveGold(string goldId)
        {
            if(goldId == null)
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
                if(gold.GoldName != null)
                {
                    updatedGold.GoldName = gold.GoldName;
                }
                if(gold.GoldPrice != null)
                {
                    updatedGold.GoldPrice = gold.GoldPrice;
                }
                
                _jewelDbContext.Golds.Update(updatedGold);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        Gold IGoldService.GetGold(string goldId)
        {
            return _jewelDbContext.Golds.Find(goldId);
        }
    }
}
