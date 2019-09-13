using BusinessLogicLayer;
using DataAccessLayer;
using Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiServices.Controllers
{
    public class EmployeeController : ApiController
    {
        private IBLEmployees _bl;

        public EmployeeController()
        {
            IDALEmployees dal = new DALEmployeesEF();
            _bl = new BLEmployees(dal);
        }
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var json = JsonConvert.SerializeObject(_bl.GetAllEmployees());
            return Ok(json);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var json = JsonConvert.SerializeObject(_bl.GetEmployee(id));
            return Ok(json);
        }

        // POST api/<controller>
        public void Post([FromBody]Shared.Entities.ApiEmployee emp)//Esto es cualquier cosa
        {
            if (emp.Type == 1)
            {
                Shared.Entities.PartTimeEmployee e = new Shared.Entities.PartTimeEmployee();
                e.Name = emp.Name;
                e.StartDate = emp.StartDate;
                e.HourlyRate = emp.Salary;
                _bl.AddEmployee(e);
            }
            else {
                if (emp.Type == 2) {
                    Shared.Entities.FullTimeEmployee e = new Shared.Entities.FullTimeEmployee();
                    e.Name = emp.Name;
                    e.StartDate = emp.StartDate;
                    e.Salary = emp.Salary;
                    _bl.AddEmployee(e);
                }
            }   
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Shared.Entities.ApiEmployee emp)
        {
            Shared.Entities.Employee empleado = _bl.GetEmployee(id);
            if (empleado.GetType() == typeof(Shared.Entities.FullTimeEmployee))
            {
                Shared.Entities.FullTimeEmployee e = new Shared.Entities.FullTimeEmployee();
                e.Id = empleado.Id;
                e.Name = emp.Name;
                e.StartDate = emp.StartDate;
                e.Salary = emp.Salary;
                _bl.UpdateEmployee(e);
            }
            else {
                if (empleado.GetType() == typeof(Shared.Entities.PartTimeEmployee))
                {
                    Shared.Entities.PartTimeEmployee e = new Shared.Entities.PartTimeEmployee();
                    e.Id = empleado.Id;
                    e.Name = emp.Name;
                    e.StartDate = emp.StartDate;
                    e.HourlyRate = emp.Salary;
                    _bl.UpdateEmployee(e);
                }
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _bl.DeleteEmployee(id);
        }
    }
}