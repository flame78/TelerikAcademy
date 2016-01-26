using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using TodoList.Models;

namespace TodoList
{
    public partial class BasePage : Page
    {
        public TodoListDbContext dbContext;
         
        public BasePage()
        {
            dbContext = new TodoListDbContext();
        }
    }
}
