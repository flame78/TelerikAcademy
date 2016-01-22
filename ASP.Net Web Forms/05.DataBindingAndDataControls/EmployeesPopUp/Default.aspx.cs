using NorthwindData;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesPopUp
{
    public partial class Default : System.Web.UI.Page
    {


        private NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Employee> lvEmployees_GetData()
        {
            return northwindDbContext.Employees;
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            var id = Request["__EVENTARGUMENT"];
            if (id != null && id != string.Empty)
            {
                var idInt = int.Parse(id);
                var data = northwindDbContext.Employees.ToList();
                dvEmployee.PageIndex = data.IndexOf(data.FirstOrDefault(em => em.EmployeeID == idInt));
                dvEmployee.DataSource = data;
                dvEmployee.DataBind();
                Label1.Visible = true;
            }
            else
            {
                Label1.Visible = false;
            }
        }
    }
}