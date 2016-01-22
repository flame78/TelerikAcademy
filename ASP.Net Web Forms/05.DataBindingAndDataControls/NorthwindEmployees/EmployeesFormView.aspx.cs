using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployees
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        public NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = northwindDbContext.Employees.ToList();

            gvEmployees.DataSource = employees;
            fvEmployee.DataSource = employees;

            var id = Request["ID"];
            if (id != null)
            {
                try
                {
                    var idInt = int.Parse(id);
                    fvEmployee.PageIndex = employees.IndexOf(employees.FirstOrDefault(emp => emp.EmployeeID == idInt));
                    gvEmployees.Visible = false;
                    fvEmployee.Visible = true;

                }
                catch (Exception)
                {
                }
            }
            else
            {
                gvEmployees.Visible = true;
                fvEmployee.Visible = false;
            }

            DataBind();
        }

        protected void fvEmployee_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            fvEmployee.PageIndex = e.NewPageIndex;
            fvEmployee.DataBind();
        }
    }
}