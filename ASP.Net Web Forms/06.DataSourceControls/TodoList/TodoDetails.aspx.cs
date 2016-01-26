using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class TodoDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public TodoList.Models.Todo DetailsViewTodo_GetItem([QueryString("id")] int? todoId)
        {
            if (todoId == null)
            {
                Response.Redirect("~/home");
            }

            return dbContext.Todos.Find(todoId);
        }
    }
}