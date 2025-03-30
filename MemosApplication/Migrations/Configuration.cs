namespace MemosApplication.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MemosApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MemosApplication.Models.MemoListsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MemosApplication.Models.MemoListsContext";
        }

        protected override void Seed(MemosApplication.Models.MemoListsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "admin",
                Roles = new List<Role>()
            };

            User user = new User()
            {
                Id = 2,
                UserName = "user",
                Password = "user",
                Roles = new List<Role>()
            };

            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>()
            };

            Role users = new Role()
            {
                Id = 2,
                RoleName = "Users",
                Users = new List<User>()
            };

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);
            user.Roles.Add(users);
            users.Users.Add(user);

            context.Users.AddOrUpdate(u => u.Id,new User[]{ admin, user });
            context.Roles.AddOrUpdate(r => r.Id, new Role[] { administrators, users });
        }
    }
}
