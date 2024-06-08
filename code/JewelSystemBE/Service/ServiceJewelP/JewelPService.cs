using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceJewelP
{
    public class JewelPService : IJewelPService
    {
        private readonly JewelDbContext _jewelDbContext;
        public JewelPService(JewelDbContext jewelDbContext)
        {
            _jewelDbContext = jewelDbContext;
        }
        public bool AddJewelP(JewelP jewelP)
        {
            if (jewelP == null)
            {  return false;}
            var existingJewelP = _jewelDbContext.JewelPs.Find(jewelP.Name);
            if(existingJewelP != null)
            {  return false; }

            _jewelDbContext.JewelPs.Add(jewelP);
            _jewelDbContext.SaveChanges();
            return true;

        }

        public List<JewelP> GetAll()
        {
            return _jewelDbContext.JewelPs.ToList();
        }

        public JewelP GetJewelP(string name)
        {
            return _jewelDbContext.JewelPs.Find(name);
        }
    }
}
