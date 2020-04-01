using Microsoft.AspNetCore.Mvc;
using SetupMVCwithExEmployeeManagement.Models;
namespace SetupMVCwithExEmployeeManagement.Controllers
{
    //to retur the json data, homecontroller need to inherit Controller
    public class HomeController: Controller
    {
        private EmployeeRepository _employeeRepository;
        //constructor injuction
        public HomeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string Index(int id)
        {
            return _employeeRepository.GetEmployee(id).Name;
        }
        //to respect contentNegotiation return type need to be ObjectResult
        public ObjectResult details(int id)
        {
            return new ObjectResult(_employeeRepository.GetEmployee(id));
        }
    }
}
