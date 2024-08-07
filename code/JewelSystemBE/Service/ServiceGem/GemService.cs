﻿using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceGem
{
    public class GemService : IGemService
    {
        private readonly JewelDbContext _jewelDbContext;

        public GemService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }
        
        public Gem AddGem(Gem gem)
        {
            if (gem == null)
            {
                return null;
            }
            var existingGem = _jewelDbContext.Gems.Find(gem.GemId);
            if (existingGem != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Gems.Add(gem);
                _jewelDbContext.SaveChanges();
                return gem;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding gem: {ex.Message}");
                return null;
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
            if(gemId == null)
            { return false; }
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
            { return false; }
            Gem updatedGem = _jewelDbContext.Gems.Find(gem.GemId);
            if (updatedGem != null)
            {
                updatedGem.GemPrice = gem.GemPrice;
                updatedGem.GemName = gem.GemName;
                updatedGem.BuyPrice = gem.BuyPrice;
                updatedGem.GemCode = gem.GemCode;
                updatedGem.GemWeight = gem.GemWeight;
                updatedGem.Unit = gem.Unit;


                _jewelDbContext.Gems.Update(updatedGem);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
