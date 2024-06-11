using JewelBO;
using JewelDAL;

namespace JewelDAO.DAOGem
{
    public class GemDao : IGemDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public GemDao(JewelDbContext jewelDbContext)
        {
            _jewelDbContext = jewelDbContext;
        }

        public bool AddGem(Gem gem)
        {
            if (gem == null)
            {
                return false;
            }
            var existingGem = _jewelDbContext.Gems.Find(gem.GemId);
            if (existingGem != null)
            {
                return false;
            }
            try
            {
                _jewelDbContext.Gems.Add(gem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding gem: {ex.Message}");
                return false;
            }
        }

        public List<Gem> GetGems()
        {
            return _jewelDbContext.Gems.OrderByDescending(x => x.GemId).ToList();
        }

        public Gem GetGem(string gemId)
        {
            return _jewelDbContext.Gems.Find(gemId);
        }

        public bool RemoveGem(string gemId)
        {
            if (gemId == null)
            {
                return false;
            }
            Gem gem = _jewelDbContext.Gems.Find(gemId);
            if (gem != null)
            {
                _jewelDbContext.Gems.Remove(gem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateGem(Gem gem)
        {
            if (gem == null)
            {
                return false;
            }
            Gem updatedGem = _jewelDbContext.Gems.Find(gem.GemId);
            if (updatedGem != null)
            {
                updatedGem.GemPrice = gem.GemPrice;
                updatedGem.GemName = gem.GemName;
                _jewelDbContext.Gems.Update(updatedGem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
