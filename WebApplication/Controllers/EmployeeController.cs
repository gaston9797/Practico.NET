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
        private IBLEmployees _bl;

        public EmployeeController()
        {
            IDALEmployees dal = new DALEmployeesEF();
            _bl = new BLEmployees(dal);
        }

        public List<Shared.Entities.Employee> GetEmployees()
        {
            return _bl.GetAllEmployees();
        }

        public List<DataEmployee> GetDataEmployees()
        {
            List<Employee> employees = _bl.GetAllEmployees();
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
            _bl.AddEmployee(e);
        }

        public Shared.Entities.Employee GetEmployee(int Id)
        {
            return _bl.GetEmployee(Id);
        }

        public void UpdateEmployee(Shared.Entities.Employee e)
        {
            _bl.UpdateEmployee(e);
        }

        public void DeleteEmployee(int id)
        {
            _bl.DeleteEmployee(id);
        }
    }
}
