using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceJewel
{
    public class JewelService : IJewelService
    {
        private readonly JewelDbContext _jewelDbContext;

        public JewelService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddJewel(Jewel jewel)
        {
            _jewelDbContext.Jewels.Add(jewel);
            _jewelDbContext.SaveChanges();
            return true;
        }

        public List<Jewel> GetJewels()
        {
            return _jewelDbContext.Jewels.OrderByDescending(x => x.Name).ToList();
        }

        public bool RemoveJewel(int jewelId)
        {
            Jewel jewel = _jewelDbContext.Jewels.Find(jewelId);
            _jewelDbContext.Jewels.Remove(jewel);
            _jewelDbContext.SaveChanges();
            return true;
        }

        public bool UpdateJewel(Jewel jewel)
        {
            _jewelDbContext.Jewels.Update(jewel);
            _jewelDbContext.SaveChanges();
            return true;
        }
    }
}
