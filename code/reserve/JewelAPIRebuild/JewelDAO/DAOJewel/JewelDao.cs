using JewelBO;
using JewelDAL;
using Microsoft.EntityFrameworkCore;

namespace JewelDAO.DAOJewel
{
    public class JewelDao : IJewelDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public JewelDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddJewel(Jewel jewel)
        {
            if (jewel == null)
            {
                Console.WriteLine($"Null jewel");
                return false;
            }
            var existingJewel = _jewelDbContext.Jewels.Find(jewel.Id);
            if (existingJewel != null)
            {
                Console.WriteLine($"Existing jewel");
                return false;
            }

            using (var transaction = _jewelDbContext.Database.BeginTransaction())
            {
                try
                {
                    _jewelDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [jewel] ON");

                    _jewelDbContext.Jewels.Add(jewel);
                    _jewelDbContext.SaveChanges();

                    _jewelDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [jewel] OFF");

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding jewel: {ex.Message}");
                    return false;
                }
            }
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
