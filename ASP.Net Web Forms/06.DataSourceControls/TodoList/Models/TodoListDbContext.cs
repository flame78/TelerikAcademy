using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Migrations;

namespace TodoList.Models
{
    public class TodoListDbContext : IdentityDbContext<ApplicationUser>
    {
        public TodoListDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoListDbContext, Configuration>());
        }

        public static TodoListDbContext Create()
        {
            return new TodoListDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Todo> Todos { get; set; }
    }
}
