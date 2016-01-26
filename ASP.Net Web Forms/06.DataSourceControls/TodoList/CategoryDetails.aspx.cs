using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.Models;

namespace TodoList
{
    public partial class CategoryDetails : BasePage
    {
        public TodoList.Models.Category category; 

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public ICollection<Todo> ListViewTodos_GetData([QueryString("id")] int? categoryId)
        {
            if (categoryId == null)
            {
                Response.Redirect("~/home");
            }

            category = dbContext.Categories.Find(categoryId);
            LabelCategoryName.Text = category.Name;

            return category.Todos;
        }
    }
}