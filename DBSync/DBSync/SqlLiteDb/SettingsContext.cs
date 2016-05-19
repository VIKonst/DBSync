using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.SqlLiteDb
{
    public class SettingsContext : DbContext
    {
        public SettingsContext()
           
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

       // public DbSet<Connection> Connections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureConnection(modelBuilder);


            SqliteCreateDatabaseIfNotExists<SettingsContext> c = new SqliteCreateDatabaseIfNotExists<SettingsContext>(modelBuilder);
            Database.SetInitializer(c);



        }

        private void ConfigureConnection(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>();
        }
    }
}
