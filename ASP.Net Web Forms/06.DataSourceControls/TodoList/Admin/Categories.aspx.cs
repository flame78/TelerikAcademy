using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class Categories : BasePage
    {
        public IQueryable<TodoList.Models.Category> ListViewCategories_GetData()
        {
            return dbContext.Categories;
        }

        public void ListViewCategories_InsertItem()
        {
            var item = new TodoList.Models.Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(item);
                dbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int id)
        {
            TodoList.Models.Category item = null;
            item = dbContext.Categories.Find(id);
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int id)
        {
            dbContext.Categories.Remove(dbContext.Categories.Find(id));
            dbContext.SaveChanges();
        }
    }
}