namespace TodoList.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoList.Models.TodoListDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodoList.Models.TodoListDbContext context)
        {

            if (context.Todos.Any())
            {
                return;
            }
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var admin = new ApplicationUser { UserName = "admin", Email = "admin@a.com" };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var a = manager.Create(admin,"admin");

            var categories = new List<Category>() {
                    new Category { Name = "Home" }
                    };

            var todos = new List<Todo>()                {
                    new Todo() {
                        Title = "Clean",
                        Text = "Clean home",
                        LastChange = DateTime.Now,
                        Category = categories[0],
                        Owner = admin
                    },
                    new Todo() {
                        Title = "Code",
                        Text = "Write homework",
                        LastChange = DateTime.Now,
                        Category = categories[0],
                        Owner = admin
                    }
                };

            context.Todos.AddOrUpdate(todos.ToArray());
        }
    }
}
