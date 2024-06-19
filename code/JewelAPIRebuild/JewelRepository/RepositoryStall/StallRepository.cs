using JewelBO;
using JewelDAO.DAOStall;


namespace JewelRepository.RepositoryStall
{
    public class StallRepository : IStallRepository
    {
        private readonly IStallDao _stallDao;
        public StallRepository(IStallDao stallDao)
        {
            _stallDao = stallDao;
        }
        public Stall AddStall(Stall stall)
        {
            return _stallDao.AddStall(stall);
        }

        public Stall GetStall(string stallId)
        {
            return _stallDao.GetStall(stallId);
        }

        public List<Stall> GetStalls()
        {
            return _stallDao.GetStalls();   
        }

        public bool RemoveStall(string stallId)
        {
            return _stallDao.RemoveStall(stallId);
        }

        public bool UpdateStall(Stall stall)
        {
            return (_stallDao.UpdateStall(stall));      
        }
    }
}
