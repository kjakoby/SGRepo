using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepo.GetAll()
                                                       join department in DepartmentRepo.GetAll()
                                                       on employee.DepartmentId equals department.DepartmentId
                                                       select new EmployeeListViewModel()
                                                       {
                                                           Name = employee.FirstName + " " + employee.LastName,
                                                           Department = department.DepartmentName,
                                                           Phone = employee.Phone,
                                                           EmployeeId = employee.EmployeeId,
                                                       };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();

            model.Departments = GetDepartmentSelectList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepo.Add(employee);

                return RedirectToAction("Index");
            }
            else
            {
                model.Departments = GetDepartmentSelectList();
                return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = EmployeeRepo.Get(id);

            var model = new EditEmployeeViewModel();
            model.FirstName = employee.FirstName;
            model.LastName = employee.LastName;
            model.DepartmentId = employee.DepartmentId;
            model.Phone = employee.Phone;
            model.EmployeeId = employee.EmployeeId;

            model.Departments = GetDepartmentSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.EmployeeId = model.EmployeeId;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepo.Edit(employee);

                return RedirectToAction("Index");
            }
            else
            {
                model.Departments = GetDepartmentSelectList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeRepo.Delete(id);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetDepartmentSelectList()
        {
            return (from department in DepartmentRepo.GetAll()
                    select new SelectListItem()
                    {
                        Text = department.DepartmentName,
                        Value = department.DepartmentId.ToString()
                    }).ToList();
        }
        
    }
}