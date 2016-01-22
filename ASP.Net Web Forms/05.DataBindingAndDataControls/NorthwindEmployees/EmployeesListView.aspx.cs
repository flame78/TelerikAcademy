using NorthwindData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindEmployees
{
    public partial class EmployeesListView : System.Web.UI.Page
    {
        private NORTHWNDEntities northwindDbContext = new NORTHWNDEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employee> lvEmployees_GetData()
        {
            return northwindDbContext.Employees;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void lvEmployees_UpdateItem(int employeeId)
        {

            var item = northwindDbContext.Employees.Find(employeeId);

            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", employeeId));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                northwindDbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void lvEmployees_DeleteItem(int employeeId)
        {
            var item = northwindDbContext.Employees.Find(employeeId);
            northwindDbContext.Employees.Remove(item);
            northwindDbContext.SaveChanges();
        }

        protected void lvEmployees_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Clone")
            {
                var employee = northwindDbContext.Employees.Find(lvEmployees.DataKeys[e.Item.DisplayIndex].Value);

                var newEmployee = new Employee();
                northwindDbContext.Employees.Add(newEmployee);

                var sourceValues = northwindDbContext.Entry(employee).CurrentValues;

                northwindDbContext.Entry(newEmployee).CurrentValues.SetValues(sourceValues);

                northwindDbContext.SaveChanges();

                DataBind();
            }
        }
    }
}