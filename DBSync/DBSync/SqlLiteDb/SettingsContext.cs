using DBSync.SqlLiteDb.Entities;
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
            : base()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
      //      Database.Connection.ConnectionString = $"Data Source ={Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\DbSync\\dbSettings.sqlite";
        }

   
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>();
            modelBuilder.Entity<Setting>();

            SqliteCreateDatabaseIfNotExists<SettingsContext> initializer= new SqliteCreateDatabaseIfNotExists<SettingsContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }      
    }
}
