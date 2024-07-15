using JewelBO;
using JewelDAO.DAOStallEmployee;

namespace JewelRepository.RepositoryStallEmployee
{
    public class StallEmployeeRepository : IStallEmployeeRepository
    {
        private readonly IStallEmployeeDao _stallEmployeeDao;
        public StallEmployeeRepository(IStallEmployeeDao stallEmployeeDao)
        {
            _stallEmployeeDao = stallEmployeeDao;
        }

        public StallEmployee AddStallEmployee(StallEmployee stallEmployee)
        {
            return _stallEmployeeDao.AddStallEmployee(stallEmployee);
        }

        public StallEmployee GetStallEmployee(string stallEmployeeId)
        {
            return _stallEmployeeDao.GetStallEmployee(stallEmployeeId);
        }

        public List<StallEmployee> GetStallEmployees()
        {
            return _stallEmployeeDao.GetStallEmployees();
        }

        public bool RemoveStallEmployee(string stallEmployeeId)
        {
            return _stallEmployeeDao.RemoveStallEmployee(stallEmployeeId);
        }

        public bool UpdateStallEmployee(StallEmployee stallEmployee)
        {
            return _stallEmployeeDao.UpdateStallEmployee(stallEmployee);
        }
    }
}
