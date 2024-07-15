

using JewelBO;

namespace JewelRepository.RepositoryStallEmployee
{
    public interface IStallEmployeeRepository
    {
        StallEmployee AddStallEmployee(StallEmployee stallEmployee);
        List<StallEmployee> GetStallEmployees();
        bool RemoveStallEmployee(string stallEmployeeId);
        bool UpdateStallEmployee(StallEmployee stallEmployee);
        StallEmployee GetStallEmployee(string stallEmployeeId);
    }
}
