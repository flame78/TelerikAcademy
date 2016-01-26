using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.Models;

namespace TodoList.Admin
{
    public partial class Todos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<Todo> DetailsViewTodos_GetItem()
        {
                return dbContext.Todos;
        }

        public void DetailsViewTodos_InsertItem()
        {
            var item = new TodoList.Models.Todo();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.Todos.Add(item);
                dbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void DetailsViewTodos_UpdateItem(int id)
        {
            TodoList.Models.Todo item = null;
            item = dbContext.Todos.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.SaveChanges();

            }
        }
    }
}