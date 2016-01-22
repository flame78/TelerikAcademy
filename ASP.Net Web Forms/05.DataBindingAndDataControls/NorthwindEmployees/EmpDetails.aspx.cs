using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        public NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var data = northwindDbContext.Employees.ToList();

            try
            {
                var id = int.Parse(Request["id"]);
                dvEmployee.PageIndex = data.IndexOf(data.FirstOrDefault(em => em.EmployeeID == id));
            }
            catch (Exception)
            {
            }

            dvEmployee.DataSource = data;
            dvEmployee.DataBind();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/EmployeesGridView.aspx", true);
        }

        protected void dvEmployee_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dvEmployee.PageIndex = e.NewPageIndex;
            dvEmployee.DataBind();
        }
    }
}