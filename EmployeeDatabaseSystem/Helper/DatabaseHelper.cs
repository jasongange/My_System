using App.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDatabaseSystem.Helper
{
    public class DatabaseHelper
    {
        public static void AppDomainContextInitialize()
        {
            Database.SetInitializer(new AppDomainContextInitializer());
            var context = new AppDomainContext();

            //if (!context.Database.Exists())
            //{
            //    DatabaseHelper.UpdateDatabase();
            //}
            //else
            //{
            //    if (!context.Database.CompatibleWithModel(true))
            //    {
            //        DatabaseHelper.UpdateDatabase();
            //    }

            //    if (!context.Database.CompatibleWithModel(true))
            //    {
            //        throw new Exception("Database not updated.  Please contact your system administrator!");
            //    }
            //}
        }
        //private static void UpdateDatabase()
        //{
        //    try
        //    {
        //        var configuration = new Codebiz.Domain.ERP.Context.DbTrackerMigrations.DbTrackerConfiguration();
        //        var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
        //        migrator.Update();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("Error encountered {0}. Please contact your system administrator!", ex.Message));
        //    }
        //}
    }
}