

using JewelBO;

namespace JewelService.ServiceStallEmployee
{
    public interface IStallEmployeeService
    {
        StallEmployee AddStallEmployee(StallEmployee stallEmployee);
        List<StallEmployee> GetStallEmployees();
        bool RemoveStallEmployee(string stallEmployeeId);
        bool UpdateStallEmployee(StallEmployee stallEmployee);
        StallEmployee GetStallEmployee(string stallEmployeeId);
    }
}
