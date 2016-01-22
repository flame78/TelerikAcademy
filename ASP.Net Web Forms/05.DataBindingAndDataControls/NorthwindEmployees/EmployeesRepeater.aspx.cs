using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace NorthwindEmployees
{
    public partial class EmployeesRepeater : System.Web.UI.Page
    {
        private NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            rpEmployees.DataSource = northwindDbContext.Employees.ToArray();
            DataBind();
        }
    }
}