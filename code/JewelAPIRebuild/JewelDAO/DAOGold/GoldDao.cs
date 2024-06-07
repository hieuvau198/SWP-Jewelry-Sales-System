using JewelBO;
using JewelDAL;

namespace JewelDAO.DAOGold
{
    public class GoldDao : IGoldDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public GoldDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }
        public bool AddGold(Gold gold)
        {
            if (gold == null)
            {
                return false;
            }
            var existingGold = _jewelDbContext.Golds.Find(gold.GoldId);
            if (existingGold != null)
            {
                return false;
            }
            try
            {
                _jewelDbContext.Golds.Add(gold);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding gold: {ex.Message}");
                return false;
            }
        }

        public List<Gold> GetGolds()
        {
            return _jewelDbContext.Golds.OrderByDescending(x => x.GoldId).ToList();
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
                updatedGold.GoldPrice = gold.GoldPrice;
                updatedGold.GoldName = gold.GoldName;
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
