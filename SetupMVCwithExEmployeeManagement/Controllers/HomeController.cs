using Microsoft.AspNetCore.Mvc;
using SetupMVCwithExEmployeeManagement.Models;
using SetupMVCwithExEmployeeManagement.ViewModels;

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
        
        public string Index()
        {
            return _employeeRepository.GetEmployee(5).Name;
        }
        //to request details https://localhost:44388/home/details/3
        public string details1(int id)
        {
            return _employeeRepository.GetEmployee(id).EmailID;
        }
        //to respect contentNegotiation return type need to be ObjectResult
        public ObjectResult details2(int id)
        {
            return new ObjectResult(_employeeRepository.GetEmployee(id));
        }
        //for displaying the data throught view(using css, html templete) we use viewResult
        /*
         * If the view folder is not created or the default files are not present the we get exception
         * InvalidOperationException: The view 'details3' was not found. The following locations were searched:
            /Views/Home/details3.cshtml
            /Views/Shared/details3.cshtml
            /Pages/Shared/details3.cshtml
         * so create the folder of view
         * */
         //by default the viewresult will search for the details3.cshtml in views folder
        public ViewResult details3(int id)
        {
            //return View(_employeeRepository.GetEmployee(id));

            //if want to call the file of other name then use the overloaded method of view
            //return View("OtherName");

            //if you want the view file from other location then use 
            //return View("tempFolder/Index.cshtml");

            //if you want the view from same views folder then
            //return View("../tempFolder/Index");

            /*
             * for passing the data to views, we have different ways
                viewdata: dictionary of weakly typed objects, use string key to store and retrive data
                viewbag: it is a wrapper for viewdata, dynamic typed, use property to store and retrive data
                strongly typed
             */

            Employee model = _employeeRepository.GetEmployee(id);

            ViewData["Employee"] = model;
            ViewData["PageTitle"] = "Employee Details: ";

            /*
             * disadvantage: at run time the type is defined, in details.cshtml we wont get intellisense, type casting is must if not string, won't get compile time error
             */

            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employee Details";
            /*
             * disadvantage: no intellisense, no compile time error
             */
            //return View();

            //return View(model);
            //in strongly typed here we are only passing the model but not the title so in order to pass this: crete ViewModels: it contains all the data a view needs
            /*
             * ViewModels also called as: data transfer objects: 
             */

            HomedetailsViewModels homedetailsViewModels = new HomedetailsViewModels()
            {
                employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details"
            };
            return View(homedetailsViewModels);
        }

    }
}
