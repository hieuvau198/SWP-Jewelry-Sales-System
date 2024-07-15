using JewelBO;


namespace JewelDAO.DAOStallEmployee
{
    public class StallEmployeeDao : IStallEmployeeDao
    {
        private readonly JewelDbContext _jewelDbContext;

        public StallEmployeeDao(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public StallEmployee AddStallEmployee(StallEmployee stallEmployee)
        {
            if (stallEmployee == null)
            {
                return null;
            }
            var existingStallEmployee = _jewelDbContext.StallEmployees.Find(stallEmployee.StallEmployeeId);
            if (existingStallEmployee != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.StallEmployees.Add(stallEmployee);
                _jewelDbContext.SaveChanges();
                return stallEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding stall employee: {ex.Message}");
                return null;
            }
        }

        public List<StallEmployee> GetStallEmployees()
        {
            return _jewelDbContext.StallEmployees.OrderByDescending(x => x.StallEmployeeId).ToList();
        }

        public bool RemoveStallEmployee(string stallEmployeeId)
        {
            if (stallEmployeeId == null)
            {
                return false;
            }
            StallEmployee stallEmployee = _jewelDbContext.StallEmployees.Find(stallEmployeeId);
            if (stallEmployee != null)
            {
                _jewelDbContext.StallEmployees.Remove(stallEmployee);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStallEmployee(StallEmployee stallEmployee)
        {
            if (stallEmployee == null)
            {
                return false;
            }
            StallEmployee updatedStallEmployee = _jewelDbContext.StallEmployees.Find(stallEmployee.StallEmployeeId);
            if (updatedStallEmployee != null)
            {
                updatedStallEmployee.StallId = stallEmployee.StallId;
                updatedStallEmployee.StallName = stallEmployee.StallName;
                updatedStallEmployee.EmployeeId = stallEmployee.EmployeeId;
                updatedStallEmployee.EmployeeFullname = stallEmployee.EmployeeFullname;
                updatedStallEmployee.Role = stallEmployee.Role;
                _jewelDbContext.StallEmployees.Update(updatedStallEmployee);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public StallEmployee GetStallEmployee(string stallEmployeeId)
        {
            return _jewelDbContext.StallEmployees.Find(stallEmployeeId);
        }
    }
}
