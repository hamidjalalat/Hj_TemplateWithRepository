using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Models
{
    public class DataBaseContext:DbContext
    {
        static DataBaseContext()
        {
            // فقط به درد برنامه نويسان آنهم در زمان پياده سازی می خورد
            //اگر وجود داشت پاک میکنه واز اول می سازه
            //Database.SetInitializer
            //    (new DropCreateDatabaseAlways<DataBaseContext>());

            // فقط به درد برنامه نويسان آنهم در زمان پياده سازی می خورد
            //اگر تغییری روی مدل بدهیم پاک میکنه از اول می سازه
            Database.SetInitializer
                (new System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>());

            // به درد مشتری می خورد
            //اگر وجود نداشت می سازه
            //Database.SetInitializer
            //	(new CreateDatabaseIfNotExists<DataBaseContext>());
        }
        public DataBaseContext() : base()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(new Role.Configuration());
            //modelBuilder.Configurations.Add(new User.Configuration());
        }

    }
}