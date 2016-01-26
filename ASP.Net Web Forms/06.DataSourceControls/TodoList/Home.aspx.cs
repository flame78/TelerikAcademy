using System;
using TodoList.Models;
using System.Linq;
using System.Web.ModelBinding;
using System.Collections.Generic;

namespace TodoList
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public ICollection<Category> ListViewCategories_GetData()
        {
            return dbContext.Categories.OrderBy(c => c.Name).Take(6).ToArray();
        }

        public ICollection<Todo> ListViewTodo_GetData(int categoryId)
        {
            var todos = dbContext.Todos.Where(t => t.CategoryID == categoryId).OrderBy(t => t.Title).Take(5).ToArray();
            return todos;
        }
    }
}