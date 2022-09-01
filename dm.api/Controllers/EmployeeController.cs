using dm.api.E_Models;
using dm.api.Services;
using Microsoft.AspNetCore.Mvc;


namespace dm.api.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {
        // private readonly IMapper _mapper;
        private readonly empRepo _empRepo;

        public EmployeeController(empRepo empRepo)
        {
            //_mapper = mapper ??
            //    throw new ArgumentNullException(nameof(mapper));


            _empRepo = empRepo ??
                throw new ArgumentNullException(nameof(empRepo));
        }

        [HttpGet]
        public ActionResult<Employee> GetEmps()
        {
            return Ok(_empRepo.GetEmployees());
        }

        [HttpGet("{empId}", Name = "GetEmp")]
        public IActionResult GetEmp(int empId)
        {
            if(!_empRepo.EmpExist(empId))
                return NotFound();

            return Ok(_empRepo.GetEmployee(empId));
        }

        [HttpPost]
        public IActionResult CreateEmp(EmpDto emp)
        {
            if (emp == null)
                return BadRequest();

            var _emp = _empRepo.AddEmp(emp);
            return CreatedAtRoute("GetEmp",
                new { _emp.Id },
                _emp);
        }

        [HttpPut("{empId}")]
        public IActionResult UpdateEmp(int empId, EmpDto emp)
        {
            if (!_empRepo.EmpExist(empId))
                return NotFound();

            _empRepo.Updataing(empId, emp);

            return CreatedAtRoute("GetEmp",
                new { empId },
                emp);
        }

        [HttpDelete("{empId}")]
        public IActionResult DeleteEmp(int empId)
        {
            if (!_empRepo.EmpExist(empId))
                return NotFound();

            _empRepo.Deleting(empId);
            return NoContent();

        }
    }
}
