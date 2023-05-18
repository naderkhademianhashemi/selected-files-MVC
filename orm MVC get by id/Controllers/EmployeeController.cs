using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var employeeList = new List<Employee>();
            employeeList.Add(new Employee
            {
                EmployeeId = 101,
                FirstName = "Ali",
                LastName = "Rezaei",
                NationalCode = "5510"

            });

            employeeList.Add(new Employee
            {
                EmployeeId = 102,
                FirstName = "Maryam",
                LastName = "Rezaei",
                NationalCode = "8710"

            });

            employeeList.Add(new Employee
            {
                EmployeeId = 103,
                FirstName = "Nima",
                LastName = "Khodadadi",
                NationalCode = "8750"

            });
            return View(employeeList);
        }

        public ActionResult Get(int id)
        {
            //query in db

            var model = new Employee
            {
                EmployeeId = 103,
                FirstName = "Nima",
                LastName = "Khodadadi",
                NationalCode = "8750"

            };

            return View(model);
        }
    }
}