using dm.api.E_Models;
using dm.Api.DbContexts;

namespace dm.api.Services
{
    public class empRepo
    {
        private readonly EmpContext _context;

        public empRepo(EmpContext context )
        {
            _context = context;

        }

        public Employee AddEmp(EmpDto emp)
        {
            var _emp = new Employee()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Age = emp.Age,
                Salary = emp.Salary
            };

            _context.Employees.Add(_emp);
            _context.SaveChanges();
            return _emp;
        }

        public List<Employee> GetEmployees() => _context.Employees.ToList();

        public Employee GetEmployee(int id) => (_context.Employees.FirstOrDefault(e => e.Id == id));

        public bool EmpExist(int id)
        {
            if(!_context.Employees.Any(e => e.Id == id))
                return false;
            return true;
        }

        public void Updataing(int id , EmpDto emp)
        {
            
            var Oemp = _context.Employees.FirstOrDefault(e => e.Id == id); 
            Oemp.Salary = emp.Salary;
            Oemp.FirstName = emp.FirstName;
            Oemp.LastName = emp.LastName;
            Oemp.Age = emp.Age;

            _context.Employees.Add(Oemp);
            _context.SaveChanges();
        }

        public void Deleting(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            
        }
    }
}
