using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceStall
{
    public class StallService : IStallService
    {
        private readonly JewelDbContext _jewelDbContext;

        public StallService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public Stall AddStall(Stall stall)
        {
            if (stall == null)
            {
                return null;
            }
            var existingStall = _jewelDbContext.Stalls.Find(stall.StallId);
            if (existingStall != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Stalls.Add(stall);
                _jewelDbContext.SaveChanges();
                return stall;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding stall: {ex.Message}");
                return null;
            }
        }

        public List<Stall> GetStalls()
        {
            List<Stall> stalls = _jewelDbContext.Stalls.OrderByDescending(x => x.StallId).ToList();
            return stalls;
        }

        public bool RemoveStall(string stallId)
        {
            if (stallId == null)
            {
                return false;
            }
            Stall stall = _jewelDbContext.Stalls.Find(stallId);
            if (stall != null)
            {
                _jewelDbContext.Stalls.Remove(stall);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStall(Stall stall)
        {
            if (stall == null)
            {
                return false;
            }
            Stall updatedStall = _jewelDbContext.Stalls.Find(stall.StallId);
            if (updatedStall != null)
            {
                updatedStall.StallName = stall.StallName;
                updatedStall.StallDescription = stall.StallDescription;
                updatedStall.StallType = stall.StallType;
                updatedStall.UserId = stall.UserId;
                _jewelDbContext.Stalls.Update(updatedStall);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Stall GetStall(string stallId)
        {
            return _jewelDbContext.Stalls.Find(stallId);
        }
    }
}
