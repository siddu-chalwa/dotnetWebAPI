using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetupMVCwithExEmployeeManagement.Models
{
    //for dependecy injuction and unit testing we create EmployeeRepository interface   
    public class MockEmployeeRepository : EmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() { 
                new Employee(){ ID = 1, Name = "a", Department = "A", EmailID = "a@Agmail.com"},
                new Employee(){ ID = 2, Name = "aa", Department = "AA", EmailID = "a@AAgmail.com"},
                new Employee(){ ID = 3, Name = "aaa", Department = "AAA", EmailID = "a@AAAgmail.com"},
                new Employee(){ ID = 4, Name = "aaaa", Department = "AAAA", EmailID = "a@AAAAgmail.com"},
                new Employee(){ ID = 5, Name = "aaaaa", Department = "AAAA", EmailID = "a@AAAAgmail.com"}
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.ID == id);
        }
    }
}
