using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Employees
{
    public partial class ListEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees/AgregarEmployee.aspx");
        }

        protected void EmployeeGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = EmployeeGV.Rows[EmployeeGV.SelectedIndex].Cells[1].Text;
            Response.Redirect("~/Employees/AgregarEmployee.aspx?Id=" + id);
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
    }
}