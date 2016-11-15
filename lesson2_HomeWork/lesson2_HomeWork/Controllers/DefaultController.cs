using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lesson2_HomeWork.Models.Default;
using lesson2_HomeWork.Controllers.Filters;

namespace lesson2_HomeWork.Controllers
{

  [CustomAuthorizationFilter]
    public class DefaultController : Controller
    {
        private static IEnumerable<Employee> list;
        static DefaultController()
        {
            list = new List<Employee>
            {
                new Employee { Id = 1, Age = 30, Department = "IT", JobTitle = "Developer", Name = "David", Role = "Team Lead",Salary = 12000},
                new Employee { Id = 2, Age = 25, Department = "IT", JobTitle = "Developer", Name = "Sam", Role = "Developer", Salary = 110000},
                new Employee { Id = 3, Age = 35, Department = "IT", JobTitle = "Developer", Name = "Jack", Role = "Manager" , Salary = 125000},
                new Employee { Id = 4, Age = 23, Department = "IT", JobTitle = "Developer", Name = "Stepan", Role = "Developer", Salary = 100000}
            };
        }
        [HttpGet]
        [CustomExceptionFilter("Custom Message happend!!!")]
        public ActionResult List()
        {
            ViewBag.Title = "Сотрудники";
            ViewBag.Heading = "Список сотрудников ";
            ViewBag.DisplayDate = true;
            ViewBag.CurrentDate = DateTime.Now;
            return View(list);
        }
        [HttpGet]
        public ActionResult EmployeeInfo(int id)
        {
           try
            {
                var employee = list.FirstOrDefault(x => x.Id == id);
                ViewBag.Title = "Сотрудники";
                ViewBag.Heading = $"Полная информация о сотруднике {employee.Name}";
                return View(employee);
            }
            catch (Exception ex)
            {
                return RedirectToActionPermanent("Servererror", "Error");
            }
        }

        [HttpGet]
      public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ?????????
        public ActionResult CreateEmployee(Employee viewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            ((List<Employee>)list).Add(viewModel);

            return RedirectToAction("list");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = list.First(e => e.Id == id);
            ((List<Employee>)list).Remove(employee);
            //db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost] // НЕ РАБОТАЕТ
        public ActionResult RedactEmployee()
        {
            return RedirectToAction("CreateEmployee");
        }
    }
}
