using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace NorthwindEmployees
{
    public partial class EmployeesGridView : System.Web.UI.Page
    {
        public NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvEmployees.DataSource = northwindDbContext.Employees.ToArray();
            gvEmployees.DataBind();
        }
    }
}