using BusinessLogicLayer;
using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers
{
    public class EmployeeController
    {
        private WebApplication.ServiceReference.IServiceEmployees service;

        public EmployeeController()
        {
            service = new WebApplication.ServiceReference.ServiceEmployeesClient();
        }

        public List<Shared.Entities.Employee> GetEmployees()
        {
            return service.GetAllEmployees();
        }

        public List<DataEmployee> GetDataEmployees()
        {
            List<Employee> employees = service.GetAllEmployees();
            List<DataEmployee> result = new List<DataEmployee>();
            employees.ToList().ForEach(x => {
                if (x.GetType() == typeof(FullTimeEmployee))
                {
                    DataEmployee emp = new DataEmployee();
                    emp.Id = x.Id;
                    emp.Name = x.Name;
                    emp.StartDate = x.StartDate;
                    emp.Type = "Full Time Employee";
                    result.Add(emp);
                }
                else {
                    DataEmployee emp = new DataEmployee();
                    emp.Id = x.Id;
                    emp.Name = x.Name;
                    emp.StartDate = x.StartDate;
                    emp.Type = "Part Time Employee";
                    result.Add(emp);
                }
            });
            return result;
        }


        public void SaveEmployee(Shared.Entities.Employee e)
        {
            service.AddEmployee(e);
        }

        public Shared.Entities.Employee GetEmployee(int Id)
        {
            return service.GetEmployee(Id);
        }

        public void UpdateEmployee(Shared.Entities.Employee e)
        {
            service.UpdateEmployee(e);
        }

        public void DeleteEmployee(int id)
        {
            service.DeleteEmployee(id);
        }
    }
}
