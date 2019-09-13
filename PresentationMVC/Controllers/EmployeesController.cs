using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared.Entities;

namespace PresentationMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private IBLEmployees _bl;

        public EmployeesController()
        {
            IDALEmployees dal = new DALEmployeesEF();
            _bl = new BLEmployees(dal);
        }
        // GET: Employees
        public ActionResult Index()
        {
            List<Models.Employee> lista = new List<Models.Employee>();
            _bl.GetAllEmployees().ToList().ForEach(x => {
                if (x.GetType() == typeof(FullTimeEmployee))
                {
                    lista.Add(new Models.Employee()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        StartDate = x.StartDate,
                        Type = 2
                    });
                }
                else {
                    lista.Add(new Models.Employee()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        StartDate = x.StartDate,
                        Type = 1
                    });
                }
            });

            return View(lista);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Models.Employee emp = new Models.Employee();
            Employee e = _bl.GetEmployee(id);
            if (e.GetType() == typeof(FullTimeEmployee))
            {
                FullTimeEmployee em = (FullTimeEmployee)e;
                emp.Id = em.Id;
                emp.Name = em.Name;
                emp.StartDate = em.StartDate;
                emp.Type = 2;
                emp.Salary = em.Salary;
            }
            else
            {
                PartTimeEmployee em = (PartTimeEmployee)e;
                emp.Id = em.Id;
                emp.Name = em.Name;
                emp.StartDate = em.StartDate;
                emp.Type = 2;
                emp.Salary = Convert.ToInt32(em.HourlyRate);
            }
            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (collection["Type"] == "1")
                {
                    PartTimeEmployee emp = new PartTimeEmployee();
                    emp.Name = collection["Name"];
                    emp.StartDate = DateTime.Parse(collection["StartDate"]);
                    emp.HourlyRate = Convert.ToInt32(collection["Salary"]);
                    _bl.AddEmployee(emp);
                }
                else
                {
                    if (collection["Type"] == "2")
                    {
                        FullTimeEmployee emp = new FullTimeEmployee();
                        emp.Name = collection["Name"];
                        emp.StartDate = DateTime.Parse(collection["StartDate"]);
                        emp.Salary = Convert.ToInt32(collection["Salary"]);
                        _bl.AddEmployee(emp);
                    }
                }
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
            
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Employee emp = new Models.Employee();
            Employee e = _bl.GetEmployee(id);
            if (e.GetType() == typeof(FullTimeEmployee))
            {
                FullTimeEmployee em = (FullTimeEmployee)e;
                emp.Id = em.Id;
                emp.Name = em.Name;
                emp.StartDate = em.StartDate;
                emp.Type = 2;
                emp.Salary = em.Salary;
            }
            else {
                PartTimeEmployee em = (PartTimeEmployee)e;
                emp.Id = em.Id;
                emp.Name = em.Name;
                emp.StartDate = em.StartDate;
                emp.Type = 2;
                emp.Salary = Convert.ToInt32(em.HourlyRate);
            }
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (collection["Type"] == "1")
                {
                    PartTimeEmployee emp = new PartTimeEmployee();
                    emp.Id = id;
                    emp.Name = collection["Name"];
                    emp.StartDate = DateTime.Parse(collection["StartDate"]);
                    emp.HourlyRate = Convert.ToDouble(collection["Salary"]);
                    _bl.UpdateEmployee(emp);
                }
                else
                {
                    if (collection["Type"] == "2")
                    {
                        FullTimeEmployee emp = new FullTimeEmployee();
                        emp.Id = id;
                        emp.Name = collection["Name"];
                        emp.StartDate = DateTime.Parse(collection["StartDate"]);
                        emp.Salary = Convert.ToInt32(collection["Salary"]);
                        _bl.UpdateEmployee(emp);
                    }
                }
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
            
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_bl.GetEmployee(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _bl.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
