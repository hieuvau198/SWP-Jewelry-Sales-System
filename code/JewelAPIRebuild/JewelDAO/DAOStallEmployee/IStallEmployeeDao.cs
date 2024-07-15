using JewelBO;

namespace JewelDAO.DAOStallEmployee
{
    public interface IStallEmployeeDao
    {
        StallEmployee AddStallEmployee(StallEmployee stallEmployee);
        List<StallEmployee> GetStallEmployees();
        bool RemoveStallEmployee(string stallEmployeeId);
        bool UpdateStallEmployee(StallEmployee stallEmployee);
        StallEmployee GetStallEmployee(string stallEmployeeId);
    }
}
