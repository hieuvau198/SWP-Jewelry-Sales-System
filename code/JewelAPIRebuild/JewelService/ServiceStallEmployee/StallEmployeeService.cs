

using JewelBO;
using JewelRepository.RepositoryStallEmployee;

namespace JewelService.ServiceStallEmployee
{
    public class StallEmployeeService : IStallEmployeeService
    {
        private readonly IStallEmployeeRepository _employeeRepository;
        public StallEmployeeService(IStallEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public StallEmployee AddStallEmployee(StallEmployee stallEmployee)
        {
            return _employeeRepository.AddStallEmployee(stallEmployee);
        }

        public StallEmployee GetStallEmployee(string stallEmployeeId)
        {
            return _employeeRepository.GetStallEmployee(stallEmployeeId);
        }

        public List<StallEmployee> GetStallEmployees()
        {
            return _employeeRepository.GetStallEmployees();
        }

        public bool RemoveStallEmployee(string stallEmployeeId)
        {
            return _employeeRepository.RemoveStallEmployee(stallEmployeeId);
        }

        public bool UpdateStallEmployee(StallEmployee stallEmployee)
        {
            return _employeeRepository.UpdateStallEmployee(stallEmployee);
        }
    }
}
