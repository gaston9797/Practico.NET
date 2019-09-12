using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;
using Shared.Entities;

namespace WebApplication.Employees
{
    public partial class AgregarEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["Id"];
                if (id != null && !id.Equals(""))
                {
                    EmployeeController EC = new EmployeeController();
                    Employee emp = EC.GetEmployee(Convert.ToInt32(id));
                    if (emp.GetType() == typeof(FullTimeEmployee))
                    {
                        FullTimeEmployee em = (FullTimeEmployee)emp;
                        Name.Text = em.Name;
                        StartDate.SelectedDate = em.StartDate;
                        RadioButtonType.SelectedValue = "Full Time Employee";
                        Salary.Text = em.Salary.ToString();
                        HourlyRate.Enabled = false;
                    }
                    else {
                        PartTimeEmployee em = (PartTimeEmployee)emp;
                        Name.Text = em.Name;
                        StartDate.SelectedDate = em.StartDate;
                        RadioButtonType.SelectedValue = "Part Time Employee";
                        HourlyRate.Text = em.HourlyRate.ToString();
                        Salary.Enabled = false;
                    }
                }
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees/ListEmployees.aspx");
        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            EmployeeController EC = new EmployeeController();
            string id = Request.Params["Id"];
            if (RadioButtonType.SelectedValue == "Full Time Employee")
            {
                FullTimeEmployee emp = new FullTimeEmployee();
                emp.Name = Name.Text;
                emp.Salary = Convert.ToInt32(Salary.Text);
                emp.StartDate = StartDate.SelectedDate;
                if (id != null && !id.Equals(""))
                {
                    emp.Id = Convert.ToInt32(id);
                    EC.UpdateEmployee(emp);
                }
                else
                {
                    EC.SaveEmployee(emp);
                }
            }
            if (RadioButtonType.SelectedValue == "Part Time Employee")
            {
                PartTimeEmployee emp = new PartTimeEmployee();
                emp.Name = Name.Text;
                emp.HourlyRate = Convert.ToInt32(HourlyRate.Text);
                emp.StartDate = StartDate.SelectedDate;
                if (id != null && !id.Equals(""))
                {
                    emp.Id = Convert.ToInt32(id);
                    EC.UpdateEmployee(emp);
                }
                else
                {
                    EC.SaveEmployee(emp);
                }
            }

            Response.Redirect("~/Employees/ListEmployees.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            EmployeeController EC = new EmployeeController();
            string id = Request.Params["Id"];
            if (id != null && !id.Equals(""))
            {
                EC.DeleteEmployee(Convert.ToInt32(id));
                Response.Redirect("~/Employees/ListEmployees.aspx");
            }
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonType.SelectedValue == "Full Time Employee") {
                HourlyRate.Enabled = false;
                Salary.Enabled = true;
            }
            if (RadioButtonType.SelectedValue == "Part Time Employee")
            {
                Salary.Enabled = false;
                HourlyRate.Enabled = true;
            }
        }
    }
}