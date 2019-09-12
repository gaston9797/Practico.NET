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

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            /*EmployeeController e = new EmployeeController();
            Employee em = new Employee();
            em.Name = Name.Text;
            em.StartDatee = Nombre.Text;
            p.Documento = Convert.ToInt32(Documento.Text);
            string id = Request.Params["Id"];
            if (id != null && !id.Equals(""))
            {
                p.Id = Convert.ToInt32(id);
                pc.UpdatePersona(p);
            }
            else
            {
                pc.SavePersona(p);
            }*/

            Response.Redirect("~/Employees/ListEmployees.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            /*PersonaController pc = new PersonaController();
            Persona p = new Persona();
            p.Apellido = Apellido.Text;
            p.Nombre = Nombre.Text;
            if (!Documento.Text.Equals(""))
            {
                p.Documento = Convert.ToInt32(Documento.Text);
            }
            string id = Request.Params["Id"];
            if (id != null && !id.Equals(""))
            {
                p.Id = Convert.ToInt32(id);
                pc.DeletePersona(p);
                Response.Redirect("~/Personas/ListPersonas.aspx");
            }*/
        }
    }
}